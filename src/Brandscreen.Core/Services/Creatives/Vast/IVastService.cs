using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Flurl.Http;

namespace Brandscreen.Core.Services.Creatives.Vast
{
    public interface IVastService : IDependency
    {
        Task<string> Download(string url);
        Task<VastValidationResult> Validate(string xml);
        Task<VAST> Deserialize(string xml);
    }

    public class VastService : IVastService
    {
        private readonly ICacheManager _cacheManager;

        public VastService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public async Task<string> Download(string url)
        {
            var uri = new UriBuilder(url).Uri; // if uri does not specify a scheme, the scheme defaults to "http:"
            using (var fc = new FlurlClient(uri.AbsoluteUri))
            {
                try
                {
                    return await fc.AllowAnyHttpStatus().GetStringAsync();
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<VastValidationResult> Validate(string xml)
        {
            var isValidate = true;
            string error = null;

            var xmlReaderSettings = GetXmlReaderSettings();
            xmlReaderSettings.ValidationEventHandler += (sender, args) =>
            {
                isValidate = false;
                error = args.Message;
            };

            try
            {
                using (var sr = new StringReader(xml))
                using (var xr = XmlReader.Create(sr, xmlReaderSettings))
                {
                    while (await xr.ReadAsync())
                    {
                        // ValidationEventHandler will be triggered if there is any error 
                        if (!isValidate) return new VastValidationResult(false, error);
                    }
                }

                return new VastValidationResult(true);
            }
            catch (Exception ex)
            {
                return new VastValidationResult(false, ex.Message);
            }
        }

        public Task<VAST> Deserialize(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof (VAST));
            return Task.Run(() =>
            {
                using (var stringReader = new StringReader(xml))
                using (var xmlReader = XmlReader.Create(stringReader))
                {
                    var vast = (VAST) xmlSerializer.Deserialize(xmlReader);
                    return vast;
                }
            });
        }

        private XmlReaderSettings GetXmlReaderSettings()
        {
            // configure the xmlreader validation to use inline schema.
            var xmlReaderSettings = new XmlReaderSettings {ValidationType = ValidationType.Schema, Async = true};
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // configure schema
            using (var sr = new StringReader(GetVastSchema()))
            using (var xr = XmlReader.Create(sr))
            {
                xmlReaderSettings.Schemas.Add(null, xr);
            }

            return xmlReaderSettings;
        }

        private string GetVastSchema()
        {
            return _cacheManager.Get("vast_2.0.1.xsd", context =>
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brandscreen.Core.Services.Creatives.Vast.vast_2.0.1.xsd"))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            });
        }
    }
}