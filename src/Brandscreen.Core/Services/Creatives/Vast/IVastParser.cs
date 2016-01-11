using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Brandscreen.Core.Settings;
using Brandscreen.Framework;
using Castle.Core.Logging;

namespace Brandscreen.Core.Services.Creatives.Vast
{
    public interface IVastParser : IDependency
    {
        Task<IDictionary<string, string>> Parse(string url, string xml);
    }

    public class VastParser : IVastParser
    {
        private readonly IVastService _vastService;
        private readonly ICreativeSettings _creativeSettings;

        public VastParser(IVastService vastService, ICreativeSettings creativeSettings)
        {
            _vastService = vastService;
            _creativeSettings = creativeSettings;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public async Task<IDictionary<string, string>> Parse(string url, string xml)
        {
            // macro replacements
            for (var index = 0; index < _creativeSettings.VastUrlMacroReplacements.Count; index += 2)
            {
                var pattern = Regex.Escape(_creativeSettings.VastUrlMacroReplacements[index]);
                var replacement = _creativeSettings.VastUrlMacroReplacements[index + 1];
                url = Regex.Replace(url, pattern, replacement, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }

            // init params
            var vast = await Deserialize(xml).ConfigureAwait(false);
            var parameters = new Dictionary<string, string>
            {
                {"VAST_URI", url},
                {"VAST_VERSION", vast.version},
                {"VAST_WRAPPER", IsWrapper(vast).ToString()}
            };

            // process
            while (true)
            {
                ProcessCompanionParamers(vast, parameters);
                ProcessMediaFileParamers(vast, parameters);
                ProcessDurationParamers(vast, parameters);
                ProcessLinearityParameters(vast, parameters);

                // stop process if not a wrapper
                if (!IsWrapper(vast)) break;

                // unwrap
                var unwrap = await Unwrap(url, vast).ConfigureAwait(false);
                url = unwrap.Item1;
                vast = unwrap.Item2;
            }

            if (parameters.Count == 3)
            {
                // note: there is nothing can be parsed except the first three parameters
                throw new BrandscreenException("Vast content is failed to parse.");
            }

            return parameters;
        }

        private bool IsWrapper(VAST vast)
        {
            return vast.Ad[0].Item is VASTADWrapper;
        }

        private async Task<Tuple<string, VAST>> Unwrap(string url, VAST vast)
        {
            var wrapperUrl = ((VASTADWrapper) vast.Ad[0].Item).VASTAdTagURI;
            var xml = await _vastService.Download(wrapperUrl).ConfigureAwait(false);
            var vastValidationResult = await _vastService.Validate(xml).ConfigureAwait(false);
            if (!vastValidationResult.Success)
            {
                Logger.Warn($"{url} contains invalid wrapped vast content at {wrapperUrl} with error {vastValidationResult.Error} with content {xml}.");
                throw new BrandscreenException($"Wrapped vast content is invalid at {wrapperUrl} with error {vastValidationResult.Error}.");
            }
            vast = await Deserialize(xml).ConfigureAwait(false);
            return new Tuple<string, VAST>(wrapperUrl, vast);
        }

        private async Task<VAST> Deserialize(string xml)
        {
            var vast = await _vastService.Deserialize(xml).ConfigureAwait(false);
            if (vast.Ad == null || vast.Ad.Length != 1) throw new BrandscreenException("Vast tag must contain only one ad.");

            return vast;
        }

        private void ProcessDurationParamers(VAST vast, IDictionary<string, string> parameters)
        {
            if (IsWrapper(vast)) return;

            var creatives = ((VASTADInLine) vast.Ad[0].Item).Creatives;
            if (creatives == null || creatives.Length == 0) return;

            foreach (var creativeLinear in creatives.Select(x => x.Item).OfType<VASTADInLineCreativeLinear>())
            {
                var duration = creativeLinear.Duration - new DateTime();
                parameters["DURATION"] = duration.TotalSeconds.ToString("00");
            }
        }

        private void ProcessMediaFileParamers(VAST vast, IDictionary<string, string> parameters)
        {
            if (IsWrapper(vast)) return;

            var creatives = ((VASTADInLine) vast.Ad[0].Item).Creatives;
            if (creatives == null || creatives.Length == 0) return;

            var i = 1;
            foreach (var mediaFile in creatives.Select(x => x.Item).OfType<VASTADInLineCreativeLinear>().SelectMany(x => x.MediaFiles))
            {
                var type = mediaFile.type.ToLower();
                var width = Convert.ToInt32(mediaFile.width);
                var height = Convert.ToInt32(mediaFile.height);
                var bitrate = Convert.ToInt32(mediaFile.bitrate);
                var delivery = mediaFile.delivery.ToString();
                var url = mediaFile.Value.Trim();

                parameters.Add("MEDIA_FILE_DELIVERY_" + i, delivery);
                parameters.Add("MEDIA_FILE_MIME_TYPE_" + i, type);
                parameters.Add("MEDIA_FILE_BITRATE_" + i, bitrate.ToString());
                parameters.Add("MEDIA_FILE_HEIGHT_" + i, height.ToString());
                parameters.Add("MEDIA_FILE_WIDTH_" + i, width.ToString());
                parameters.Add("MEDIA_FILE_URL_" + i, url);
                if (!string.IsNullOrEmpty(mediaFile.apiFramework))
                {
                    parameters.Add("MEDIA_FILE_APIFRAMEWORK_" + i, mediaFile.apiFramework);
                }

                i++;
            }
        }

        private void ProcessCompanionParamers(VAST vast, IDictionary<string, string> parameters)
        {
            var companions = new List<Companion_type>();

            if (IsWrapper(vast))
            {
                var creatives = ((VASTADWrapper) vast.Ad[0].Item).Creatives;
                foreach (var companionTypes in creatives.Select(vastadWrapperCreative => vastadWrapperCreative.Item)
                    .OfType<VASTADWrapperCreativeCompanionAds>()
                    .Where(companionAds => companionAds.Companion != null)
                    .Select(companionAds => companionAds.Companion))
                {
                    companions.AddRange(companionTypes);
                }
            }
            else
            {
                var creatives = ((VASTADInLine) vast.Ad[0].Item).Creatives;
                foreach (var companionTypes in creatives.Select(vastadInLineCreative => vastadInLineCreative.Item)
                    .OfType<VASTADInLineCreativeCompanionAds>()
                    .Where(companionAds => companionAds.Companion != null)
                    .Select(companionAds => companionAds.Companion))
                {
                    companions.AddRange(companionTypes);
                }
            }

            if (companions.Count == 0) return;

            foreach (var companionType in companions)
            {
                if (companionType.ItemElementName != ItemChoiceType.StaticResource) continue;

                var staticResource = (Companion_typeStaticResource) companionType.Item;
                if (!staticResource.creativeType.Contains("flash") && !staticResource.creativeType.Contains("image")) continue;

                var type = staticResource.creativeType.Replace("application/x-shockwave-flash", "FLASH").Replace("image/jpeg", "IMAGE").Replace("image/gif", "IMAGE");
                var prefix = $"COMPANION_{companionType.width}x{companionType.height}_{type}";
                parameters[$"{prefix}_URL"] = companionType.CompanionClickThrough;
                parameters[$"{prefix}_APIFRAMEWORK"] = companionType.apiFramework ?? string.Empty;
                parameters[$"{prefix}_EXPANDED_WIDTH"] = companionType.expandedWidth ?? string.Empty;
                parameters[$"{prefix}_EXPANDED_HEIGHT"] = companionType.expandedHeight ?? string.Empty;
                parameters[$"{prefix}_CLICK_URL"] = staticResource.Value;
                parameters[$"{prefix}_MIME_TYPE"] = staticResource.creativeType;
            }
        }

        private void ProcessLinearityParameters(VAST vast, IDictionary<string, string> parameters)
        {
            if (IsWrapper(vast)) return;

            var creatives = ((VASTADInLine) vast.Ad[0].Item).Creatives;
            if (creatives == null || creatives.Length == 0) return;

            if (creatives.Any(x => x.Item is VASTADInLineCreativeLinear))
            {
                parameters["LINEARITY"] = "Linear";
                return;
            }

            if (creatives.Any(x => x.Item is VASTADInLineCreativeNonLinearAds))
            {
                parameters["LINEARITY"] = "NonLinear";
                return;
            }

            throw new BrandscreenException("Vast tag must contain linearity info.");
        }
    }
}