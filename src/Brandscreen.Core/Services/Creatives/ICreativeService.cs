using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Brandscreen.Core.FileSystems;
using Brandscreen.Core.MiniBuss;
using Brandscreen.Core.MiniBuss.Messages;
using Brandscreen.Core.Services.Brands;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Core.Services.Creatives.Html5;
using Brandscreen.Core.Services.Creatives.Swiffy;
using Brandscreen.Core.Services.Creatives.Vast;
using Brandscreen.Core.Services.ScreenCaptures;
using Brandscreen.Core.Settings;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using Castle.Core.Logging;
using Flurl.Http;
using ImageResizer;
using LinqKit;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Softwarekueche.MimeTypeDetective;
using SwfDotNet.IO;

namespace Brandscreen.Core.Services.Creatives
{
    public interface ICreativeService : IDependency
    {
        Task<Creative> GetCreative(Guid id);
        IQueryable<Creative> GetCreatives();
        IQueryable<Creative> GetCreatives(CreativeQueryOptions options);

        Task<Creative> CreateCreative(CreativeCreateOptions options);
        Task<Creative> CreateCreative(CreativeDoohCreateOptions options);
        Task<Creative> CreateCreative(CreativeDoohVideoCreateOptions options);
        Task<Creative> CreateCreative(CreativeDoohVideoUrlCreateOptions options);
        Task<Creative> CreateCreative(CreativeVastCreateOptions options);
        Task<Creative> CreateCreative(CreativeSwiffyCreateOptions options);
        Task<Creative> CreateCreative(CreativeHtml5CreateOptions options);
        Task<Creative> CreateCreative(CreativeAdTagCreateOptions options);
        Task UpdateCreative(CreativeUpdateOptions options);
        Task DeleteCreative(Guid id);

        IQueryable<CreativeParameter> GetCreativeParameters(Guid id);

        IQueryable<CreativeReview> GetCreativeReviews(Guid id);
        Task CreateOrUpdateCreativeReview(CreativeReviewModifyOptions options);
    }

    public class CreativeService : ICreativeService
    {
        private readonly IServiceBus _serviceBus;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IRepositoryAsync<Creative> _creativeRepositoryAsync;
        private readonly IRepositoryAsync<CreativeParameter> _creativeParameterRepositoryAsync;
        private readonly IRepositoryAsync<CreativeReview> _creativeReviewRepositoryAsync;
        private readonly IRepositoryAsync<CreativeReviewRejection> _creativeReviewRejectionRepositoryAsync;
        private readonly IAdTagTemplateService _adTagTemplateService;
        private readonly ICreativeSizeService _creativeSizeService;
        private readonly IBrandService _brandService;
        private readonly IAmazonService _amazonService;
        private readonly IVastParser _vastParser;
        private readonly ISwiffyParser _swiffyParser;
        private readonly IHtml5Service _html5Service;
        private readonly IHtml5Parser _html5Parser;
        private readonly IScreenCaptureService _screenCaptureService;
        private readonly IAppDataFolderRoot _appDataFolderRoot;
        private readonly IClock _clock;
        private readonly IAmazonSettings _amazonSettings;
        private readonly ICreativeSettings _creativeSettings;

        private static readonly Expression<Func<Creative, bool>> PredicateNotDelete =
            x => !x.IsDeleted && !x.AdvertiserProduct.IsDeleted && !x.AdvertiserProduct.Advertiser.IsDeleted && !x.BuyerAccount.IsDeleted;

        public CreativeService(IServiceBus serviceBus,
            IBrandscreenContext brandscreenContext,
            IRepositoryAsync<Creative> creativeRepositoryAsync,
            IRepositoryAsync<CreativeParameter> creativeParameterRepositoryAsync,
            IRepositoryAsync<CreativeReview> creativeReviewRepositoryAsync,
            IRepositoryAsync<CreativeReviewRejection> creativeReviewRejectionRepositoryAsync,
            IAdTagTemplateService adTagTemplateService,
            ICreativeSizeService creativeSizeService,
            IBrandService brandService,
            IAmazonService amazonService,
            IVastParser vastParser,
            ISwiffyParser swiffyParser,
            IHtml5Service html5Service,
            IHtml5Parser html5Parser,
            IScreenCaptureService screenCaptureService,
            IAppDataFolderRoot appDataFolderRoot,
            IClock clock,
            IAmazonSettings amazonSettings,
            ICreativeSettings creativeSettings)
        {
            _serviceBus = serviceBus;
            _brandscreenContext = brandscreenContext;
            _creativeRepositoryAsync = creativeRepositoryAsync;
            _creativeParameterRepositoryAsync = creativeParameterRepositoryAsync;
            _creativeReviewRepositoryAsync = creativeReviewRepositoryAsync;
            _creativeReviewRejectionRepositoryAsync = creativeReviewRejectionRepositoryAsync;
            _adTagTemplateService = adTagTemplateService;
            _creativeSizeService = creativeSizeService;
            _brandService = brandService;
            _amazonService = amazonService;
            _vastParser = vastParser;
            _swiffyParser = swiffyParser;
            _html5Service = html5Service;
            _html5Parser = html5Parser;
            _screenCaptureService = screenCaptureService;
            _appDataFolderRoot = appDataFolderRoot;
            _clock = clock;
            _amazonSettings = amazonSettings;
            _creativeSettings = creativeSettings;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public Task<Creative> GetCreative(Guid id)
        {
            return _creativeRepositoryAsync.Queryable()
                .Include(x => x.CreativeFile)
                .Include(x => x.CreativeSize)
                .Include(x => x.AdTagTemplate)
                .Include(x => x.AdvertiserProduct)
                .Where(PredicateNotDelete)
                .FirstOrDefaultAsync(x => x.CreativeUuid == id);
        }

        public IQueryable<Creative> GetCreatives()
        {
            var source = _creativeRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .OrderBy(x => x.CreativeName);
            return source;
        }

        public IQueryable<Creative> GetCreatives(CreativeQueryOptions options)
        {
            var source = GetCreatives();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<Creative>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => options.BuyerAccountIds.Contains(x.BuyerAccountId));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.AdvertiserProduct.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.AdvertiserUuid.HasValue)
            {
                source = source.Where(x => x.AdvertiserProduct.Advertiser.AdvertiserUuid == options.AdvertiserUuid.Value);
            }

            if (options.BrandUuid.HasValue)
            {
                source = source.Where(x => x.AdvertiserProduct.AdvertiserProductUuid == options.BrandUuid.Value);
            }

            if (options.StrategyUuid.HasValue)
            {
                source = source.Where(x => x.Placements.Any(placement => !placement.IsDeleted && placement.PlacementStatusId != (int) CampaignStatusEnum.Deleted && placement.AdGroup.AdGroupUuid == options.StrategyUuid.Value));
            }

            if (options.MediaTypeId.HasValue)
            {
                source = source.Where(x => x.AdTagTemplate.MediaTypeId == options.MediaTypeId.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.CreativeName.Contains(options.Text));
            }

            return source;
        }

        public async Task<Creative> CreateCreative(CreativeCreateOptions options)
        {
            // creative size
            var adTagTemplate = await _adTagTemplateService.GetAdTagTemplate(options.AdTagTemplateId);
            var mediaSize = options.CreativeType == CreativeTypeEnum.Image ? GetImageSize(options.FileData) : GetFlashSize(options.FileData);
            var creativeSize = await _creativeSizeService.GetCreativeSize(new CreativeSizeQueryOptions
            {
                Width = mediaSize.Item1,
                Height = mediaSize.Item2,
                Discrepancy = _creativeSettings.MediaSizeDiscrepancy,
                MediaTypeId = adTagTemplate.MediaTypeId
            });
            if (creativeSize == null) throw new BrandscreenException("Uploaded media file has incorrect size.");

            // creative file
            var creativeUuid = IdentityValue.GenerateNewId();
            var fileExtension = Path.GetExtension(options.FileName);
            var fileName = $"{creativeUuid}{fileExtension}";
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creativeFile = new CreativeFile
            {
                ObjectState = ObjectState.Added,
                FileName = fileName,
                BuyerAccountId = brand.BuyerAccountId,
                FileSize = options.FileData.Length,
                FileExtension = fileExtension,
                Width = mediaSize.Item1,
                Height = mediaSize.Item2,
                CreatedDateTime = _clock.UtcNow.ToLocalTime(),
                UtcCreatedDateTime = _clock.UtcNow,
                UtcModifiedDateTime = _clock.UtcNow,
                RelativePath = $"{brand.BuyerAccountId}/{brand.AdvertiserProductId}"
            };

            // creative
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                BuyerAccountId = brand.BuyerAccountId,
                AdvertiserProductId = brand.AdvertiserProductId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                CreativeFileId = creativeFile.CreativeFileId,
                CreativeFile = creativeFile,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = options.LanguageId,
                BeaconUrl = options.ImpressionUrl,
                CreativeTypeId = (int) options.CreativeType,
                CreativeStatusId = (int) CreativeStatusEnum.Live
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // set click url
            await SetCreativeClickUrl(creative, options.ClickUrl);

            // upload to s3
            var path = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{fileName}";
            await _amazonService.PutObject(options.FileData, _amazonSettings.BucketCreative, path, options.FileType, null);
            creative.FbImageUrl = (new UriBuilder(_amazonSettings.BucketCreativeUrl) {Path = path}).ToString(); // set image url

            // thumbnail
            if (options.CreativeType == CreativeTypeEnum.Image)
            {
                var thumbnail = await GenerateThumbnail(options.FileData, _creativeSettings.ThumbnailWidth, _creativeSettings.ThumbnailHeight, "png");
                var thumbnailPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creative.CreativeUuid}_{_creativeSettings.ThumbnailWidth}x{_creativeSettings.ThumbnailHeight}.png";
                await _amazonService.PutObject(thumbnail, _amazonSettings.BucketCreative, thumbnailPath, "image/png", null);
                creative.ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.Generated;
            }
            else
            {
                // msmq
                _serviceBus.Send(new GenerateCreativeThumbnailEvent
                {
                    CreativeUuids = new[] {creative.CreativeUuid},
                    BuyerAccountId = creative.BuyerAccountId,
                    InitiatingUserId = options.UserId,
                    IsThirdParty = new[] {false},
                    Attempt = 0
                }, noThrowServiceNotAvailableException: true);
            }

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeDoohCreateOptions options)
        {
            // creative size
            var creativeSize = await _creativeSizeService.GetCreativeSize(options.CreativeSizeId);
            var imageSize = GetImageSize(options.FileData);
            if (creativeSize.Width != imageSize.Item1 || creativeSize.Height != imageSize.Item2)
            {
                throw new BrandscreenException("Uploaded image has incorrect size.");
            }

            // creative file
            var creativeUuid = IdentityValue.GenerateNewId();
            var fileExtension = Path.GetExtension(options.FileName);
            var fileName = $"{creativeUuid}{fileExtension}";
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creativeFile = new CreativeFile
            {
                ObjectState = ObjectState.Added,
                FileName = fileName,
                BuyerAccountId = brand.BuyerAccountId,
                FileSize = options.FileData.Length,
                FileExtension = fileExtension,
                Width = imageSize.Item1,
                Height = imageSize.Item2,
                CreatedDateTime = _clock.UtcNow.ToLocalTime(),
                UtcCreatedDateTime = _clock.UtcNow,
                UtcModifiedDateTime = _clock.UtcNow,
                RelativePath = string.Empty
            };

            // creative
            var adTagTemplate = await _adTagTemplateService.GetDoohAdTagTemplate();
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                AdvertiserProductId = brand.AdvertiserProductId,
                BuyerAccountId = brand.BuyerAccountId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                CreativeFileId = creativeFile.CreativeFileId,
                CreativeFile = creativeFile,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = 255, // note: hardcoded 255 - English
                CreativeTypeId = (int) CreativeTypeEnum.Dooh,
                CreativeStatusId = (int) CreativeStatusEnum.Live
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // upload to s3
            var path = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{fileName}";
            await _amazonService.PutObject(options.FileData, _amazonSettings.BucketCreative, path, options.FileType, null);
            creative.FbImageUrl = (new UriBuilder(_amazonSettings.BucketCreativeUrl) {Path = path}).ToString(); // set image url

            // preview
            var preview = await GenerateThumbnail(options.FileData, _creativeSettings.DoohPreviewWidth, _creativeSettings.DoohPreviewHeight, format: null); // keep original formal
            var previewPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/preview_{fileName}";
            await _amazonService.PutObject(preview, _amazonSettings.BucketCreative, previewPath, options.FileType, null);

            // thumbnail
            var thumbnail = await GenerateThumbnail(options.FileData, _creativeSettings.ThumbnailWidth, _creativeSettings.ThumbnailHeight, "png");
            var thumbnailPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creative.CreativeUuid}_{_creativeSettings.ThumbnailWidth}x{_creativeSettings.ThumbnailHeight}.png";
            await _amazonService.PutObject(thumbnail, _amazonSettings.BucketCreative, thumbnailPath, "image/png", null);
            creative.ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.Generated;

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeDoohVideoCreateOptions options)
        {
            // creative file
            var creativeSize = await _creativeSizeService.GetCreativeSize(options.CreativeSizeId);
            var creativeUuid = IdentityValue.GenerateNewId();
            var fileExtension = Path.GetExtension(options.FileName);
            var fileName = $"{creativeUuid}{fileExtension}";
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creativeFile = new CreativeFile
            {
                ObjectState = ObjectState.Added,
                FileName = fileName,
                BuyerAccountId = brand.BuyerAccountId,
                FileSize = options.FileData.Length,
                FileExtension = fileExtension,
                Width = creativeSize.Width,
                Height = creativeSize.Height,
                CreatedDateTime = _clock.UtcNow.ToLocalTime(),
                UtcCreatedDateTime = _clock.UtcNow,
                UtcModifiedDateTime = _clock.UtcNow,
                RelativePath = string.Empty
            };

            // creative
            var adTagTemplate = await _adTagTemplateService.GetDoohAdTagTemplate();
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                AdvertiserProductId = brand.AdvertiserProductId,
                BuyerAccountId = brand.BuyerAccountId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                CreativeFileId = creativeFile.CreativeFileId,
                CreativeFile = creativeFile,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = 255, // note: hardcoded 255 - English
                CreativeTypeId = (int) CreativeTypeEnum.Dooh,
                CreativeStatusId = (int) CreativeStatusEnum.Live,
                ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.UsesGeneric
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // upload to s3
            var path = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{fileName}";
            await _amazonService.PutObject(options.FileData, _amazonSettings.BucketCreative, path, options.FileType, null);
            creative.VideoSpecUrl = (new UriBuilder(_amazonSettings.BucketCreativeUrl) {Path = path}).ToString(); // set video url

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeDoohVideoUrlCreateOptions options)
        {
            // creative
            var creativeSize = await _creativeSizeService.GetCreativeSize(options.CreativeSizeId);
            var creativeUuid = IdentityValue.GenerateNewId();
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var adTagTemplate = await _adTagTemplateService.GetDoohAdTagTemplate();
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                AdvertiserProductId = brand.AdvertiserProductId,
                BuyerAccountId = brand.BuyerAccountId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = 255, // note: hardcoded 255 - English
                CreativeTypeId = (int) CreativeTypeEnum.Dooh,
                CreativeStatusId = (int) CreativeStatusEnum.Live,
                ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.UsesGeneric,
                VideoSpecUrl = options.VideoUrl
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeVastCreateOptions options)
        {
            // creative
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var adTagTemplate = await _adTagTemplateService.GetVastAdTagTemplate();
            var creativeSize = await _creativeSizeService.GetVideoCreativeSize();
            var creative = new Creative
            {
                CreativeUuid = IdentityValue.GenerateNewId(),
                CreativeName = options.CreativeName,
                AdvertiserProductId = brand.AdvertiserProductId,
                BuyerAccountId = brand.BuyerAccountId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = options.LanguageId,
                CreativeTypeId = (int) CreativeTypeEnum.Video,
                CreativeStatusId = (int) CreativeStatusEnum.Live,
                ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.UsesGeneric,
                ExpandableDirectionId = (int) options.Direction,
                VideoSpecUrl = options.VastUrl,
                AdTag = options.VastXml
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // set click url
            await SetCreativeClickUrl(creative, options.ClickUrl);

            // creative parameters
            var creativeParameters = await _vastParser.Parse(options.VastUrl, options.VastXml);
            foreach (var creativeParameter in creativeParameters)
            {
                AddCreativeParameter(creative, creativeParameter.Key, creativeParameter.Value);
            }

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeSwiffyCreateOptions options)
        {
            // swiffy
            string html;
            using (var ms = new MemoryStream(options.FileData))
            using (var sr = new StreamReader(ms))
            {
                html = await sr.ReadToEndAsync();
            }
            var swiffyParseResult = await _swiffyParser.Parse(html);
            if (!swiffyParseResult.Success) throw new BrandscreenException($"Uploaded swiffy file has error: {swiffyParseResult.Error}.");

            // creative size
            var adTagTemplate = await _adTagTemplateService.GetSwiffyAdTagTemplate();
            var creativeSize = await _creativeSizeService.GetCreativeSize(new CreativeSizeQueryOptions
            {
                Width = swiffyParseResult.Width,
                Height = swiffyParseResult.Height,
                Discrepancy = _creativeSettings.MediaSizeDiscrepancy,
                MediaTypeId = adTagTemplate.MediaTypeId
            });
            if (creativeSize == null) throw new BrandscreenException("Uploaded swiffy file has incorrect size.");

            // creative file
            var creativeUuid = IdentityValue.GenerateNewId();
            var fileExtension = Path.GetExtension(options.FileName);
            var fileName = $"{creativeUuid}{fileExtension}";
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creativeFile = new CreativeFile
            {
                ObjectState = ObjectState.Added,
                FileName = fileName,
                BuyerAccountId = brand.BuyerAccountId,
                FileSize = options.FileData.Length,
                FileExtension = fileExtension,
                Width = swiffyParseResult.Width,
                Height = swiffyParseResult.Height,
                CreatedDateTime = _clock.UtcNow.ToLocalTime(),
                UtcCreatedDateTime = _clock.UtcNow,
                UtcModifiedDateTime = _clock.UtcNow,
                RelativePath = $"{brand.BuyerAccountId}/{brand.AdvertiserProductId}"
            };

            // creative
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                BuyerAccountId = brand.BuyerAccountId,
                AdvertiserProductId = brand.AdvertiserProductId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                CreativeFileId = creativeFile.CreativeFileId,
                CreativeFile = creativeFile,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = options.LanguageId,
                BeaconUrl = options.ImpressionUrl,
                CreativeTypeId = (int) CreativeTypeEnum.Html5,
                CreativeStatusId = (int) CreativeStatusEnum.Live
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // set click url
            await SetCreativeClickUrl(creative, options.ClickUrl);

            // upload html to s3
            var path = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{fileName}";
            await _amazonService.PutObject(options.FileData, _amazonSettings.BucketCreative, path, options.FileType, null);

            // upload swiffy js to s3
            var swiffyPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creativeUuid}.js";
            var swiffyData = Encoding.UTF8.GetBytes(swiffyParseResult.Object);
            await _amazonService.PutObject(swiffyData, _amazonSettings.BucketCreative, swiffyPath, "application/javascript", null);

            // creative parameters
            AddCreativeParameter(creative, "SWIFFY_RUNTIME_SRC", swiffyParseResult.Runtime);
            AddCreativeParameter(creative, "WIDTH", swiffyParseResult.Width.ToString());
            AddCreativeParameter(creative, "HEIGHT", swiffyParseResult.Height.ToString());
            AddCreativeParameter(creative, "SWIFFY_OBJECT_SRC", (new UriBuilder(_amazonSettings.BucketCreativeUrl) {Path = swiffyPath}).ToString());

            // thumbnail
            var htmlCapture = await _screenCaptureService.Capture(html, swiffyParseResult.Width, swiffyParseResult.Height, "png");
            var thumbnail = await GenerateThumbnail(htmlCapture, _creativeSettings.ThumbnailWidth, _creativeSettings.ThumbnailHeight, "png");
            var thumbnailPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creative.CreativeUuid}_{_creativeSettings.ThumbnailWidth}x{_creativeSettings.ThumbnailHeight}.png";
            await _amazonService.PutObject(thumbnail, _amazonSettings.BucketCreative, thumbnailPath, "image/png", null);
            creative.ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.Generated;

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeHtml5CreateOptions options)
        {
            // path
            var creativeUuid = IdentityValue.GenerateNewId();
            var extractPath = Path.Combine(_appDataFolderRoot.RootFolder, "Creatives", creativeUuid);
            if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true); // empty folder

            // extract and parse
            var extractResult = await _html5Service.Extract(options.FileData, extractPath);
            if (!extractResult.Success) throw new BrandscreenException($"failed to extract file: {extractResult.Error}.");
            var html = File.ReadAllText(Path.Combine(extractResult.BasePath, extractResult.HtmlPath));
            var parseResult = await _html5Parser.Parse(html);
            if (!parseResult.Success) throw new BrandscreenException($"failed to parse html: {parseResult.Error}.");

            // creative size
            var adTagTemplate = await _adTagTemplateService.GetHtml5AdTagTemplate();
            var creativeSize = await _creativeSizeService.GetCreativeSize(new CreativeSizeQueryOptions
            {
                Width = parseResult.Width,
                Height = parseResult.Height,
                Discrepancy = _creativeSettings.MediaSizeDiscrepancy,
                MediaTypeId = adTagTemplate.MediaTypeId
            });
            if (creativeSize == null) throw new BrandscreenException("Uploaded html file has incorrect size.");

            // creative file
            var fileExtension = Path.GetExtension(options.FileName);
            var fileName = $"{creativeUuid}{fileExtension}";
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creativeFile = new CreativeFile
            {
                ObjectState = ObjectState.Added,
                FileName = fileName,
                BuyerAccountId = brand.BuyerAccountId,
                FileSize = options.FileData.Length,
                FileExtension = fileExtension,
                Width = parseResult.Width,
                Height = parseResult.Height,
                CreatedDateTime = _clock.UtcNow.ToLocalTime(),
                UtcCreatedDateTime = _clock.UtcNow,
                UtcModifiedDateTime = _clock.UtcNow,
                RelativePath = $"{brand.BuyerAccountId}/{brand.AdvertiserProductId}"
            };

            // creative
            var creative = new Creative
            {
                CreativeUuid = creativeUuid,
                CreativeName = options.CreativeName,
                BuyerAccountId = brand.BuyerAccountId,
                AdvertiserProductId = brand.AdvertiserProductId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                CreativeFileId = creativeFile.CreativeFileId,
                CreativeFile = creativeFile,
                AdTagTemplateId = adTagTemplate.AdTagTemplateId,
                LanguageId = options.LanguageId,
                BeaconUrl = options.ImpressionUrl,
                CreativeTypeId = (int) CreativeTypeEnum.Html5,
                CreativeStatusId = (int) CreativeStatusEnum.Live
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // set click url
            await SetCreativeClickUrl(creative, options.ClickUrl);

            // upload zip to s3
            var path = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{fileName}";
            await _amazonService.PutObject(options.FileData, _amazonSettings.BucketCreative, path, options.FileType, null);

            // upload extract html to s3
            var basePath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creativeUuid}";
            var htmlData = Encoding.UTF8.GetBytes(parseResult.Html);
            var htmlS3Path = $"{basePath}/{extractResult.HtmlPath}";
            await _amazonService.PutObject(htmlData, _amazonSettings.BucketCreative, htmlS3Path, "text/html", null);

            // upload extract other files to s3
            foreach (var filePath in extractResult.OtherPaths)
            {
                var fileInfo = new FileInfo(Path.Combine(extractResult.BasePath, filePath));
                var mineType = fileInfo.ToUri().GetMimeType();
                var fileData = File.ReadAllBytes(fileInfo.FullName);
                var s3Path = $"{basePath}/{filePath}";
                await _amazonService.PutObject(fileData, _amazonSettings.BucketCreative, s3Path, mineType, null);
            }

            // creative parameters
            AddCreativeParameter(creative, "WIDTH", parseResult.Width.ToString());
            AddCreativeParameter(creative, "HEIGHT", parseResult.Height.ToString());
            AddCreativeParameter(creative, "HTML_URL", (new UriBuilder(_amazonSettings.BucketCreativeUrl) {Path = htmlS3Path}).ToString());

            // thumbnail
            var htmlPath = Path.Combine(extractResult.BasePath, extractResult.HtmlPath);
            var htmlCapture = await _screenCaptureService.CaptureByFile(htmlPath, parseResult.Width, parseResult.Height, "png");
            var thumbnail = await GenerateThumbnail(htmlCapture, _creativeSettings.ThumbnailWidth, _creativeSettings.ThumbnailHeight, "png");
            var thumbnailPath = $"{creative.BuyerAccountId}/{brand.AdvertiserId}/{brand.AdvertiserProductId}/{creative.CreativeUuid}_{_creativeSettings.ThumbnailWidth}x{_creativeSettings.ThumbnailHeight}.png";
            await _amazonService.PutObject(thumbnail, _amazonSettings.BucketCreative, thumbnailPath, "image/png", null);
            creative.ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.Generated;

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            // clean up
            if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);

            return creative;
        }

        public async Task<Creative> CreateCreative(CreativeAdTagCreateOptions options)
        {
            // ad tag
            var creativeParameters = await _adTagTemplateService.Parse(options.AdTagTemplateId, options.AdTag);
            if (creativeParameters == null || creativeParameters.Count == 0) throw new BrandscreenException("The specified ad tag is invalid.");

            // creative size
            var creativeSize = await _creativeSizeService.GetCreativeSize(options.CreativeSizeId);
            ApplySpecialAdTagCreativeSize(options.AdTagTemplateId, creativeSize, creativeParameters);
            if (!ValidateAdTagCreativeSize(creativeSize, creativeParameters)) throw new BrandscreenException("Uploaded ad tag does not match specified creative size.");

            // creative
            var brand = await _brandService.GetBrand(options.BrandUuid);
            var creative = new Creative
            {
                CreativeUuid = IdentityValue.GenerateNewId(),
                CreativeName = options.CreativeName,
                AdvertiserProductId = brand.AdvertiserProductId,
                BuyerAccountId = brand.BuyerAccountId,
                CreativeSizeId = creativeSize.CreativeSizeId,
                AdTagTemplateId = options.AdTagTemplateId,
                LanguageId = options.LanguageId,
                CreativeTypeId = (int) CreativeTypeEnum.Flash, // set to flash type as per the UI logic
                CreativeStatusId = (int) CreativeStatusEnum.Live,
                ThumbnailStatusId = (int) CreativeThumbnailStatusEnum.UsesGeneric,
                AdTag = options.AdTag
            };
            await EnsureUniqueCreativeName(creative); // ensure unique name

            // set click url
            await SetCreativeClickUrl(creative, options.ClickUrl);

            // creative parameters
            foreach (var creativeParameter in creativeParameters)
            {
                AddCreativeParameter(creative, creativeParameter.Key, creativeParameter.Value);
            }

            // save
            _creativeRepositoryAsync.Insert(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);

            return creative;
        }

        public async Task UpdateCreative(CreativeUpdateOptions options)
        {
            var creative = options.NewCreative;
            creative.UtcModifiedDateTime = _clock.UtcNow;
            creative.CreativeReviews.Clear(); // reset creative approval
            await EnsureUniqueCreativeName(creative); // ensure unique name

            if (!string.IsNullOrEmpty(options.ClickUrl))
            {
                // set click url
                await SetCreativeClickUrl(creative, options.ClickUrl);
            }

            // save
            _creativeRepositoryAsync.Update(creative);
            await _brandscreenContext.SaveChangesAsync();

            // msmq
            _serviceBus.Send(new CreativeMongoUpdateEvent
            {
                CreativeId = creative.CreativeId,
                BuyerAccountId = creative.BuyerAccountId,
                InitiatingUserId = options.UserId
            }, noThrowServiceNotAvailableException: true);
        }

        public async Task DeleteCreative(Guid id)
        {
            var creative = await _creativeRepositoryAsync.Queryable()
                .Include(x => x.Placements)
                .Include(x => x.CreativeFile)
                .Include(x => x.CreativeFile.Creatives)
                .FirstAsync(x => x.CreativeUuid == id);

            // creative file: make sure no other creative sharing the same creative file
            if (creative.CreativeFile != null &&
                creative.CreativeFile.Creatives.All(x => x.CreativeId != creative.CreativeId && x.IsDeleted))
            {
                creative.CreativeFile.IsDeleted = true;
            }

            // placements
            foreach (var placement in creative.Placements)
            {
                placement.IsDeleted = true;
                placement.PlacementStatusId = (int) CampaignStatusEnum.Deleted;
            }

            // save
            creative.IsDeleted = true;
            creative.UtcModifiedDateTime = _clock.UtcNow;
            _creativeRepositoryAsync.Update(creative);
            await _brandscreenContext.SaveChangesAsync();
        }

        public IQueryable<CreativeParameter> GetCreativeParameters(Guid id)
        {
            return _creativeParameterRepositoryAsync.Queryable()
                .Where(x => x.Creative.CreativeUuid == id)
                .OrderBy(x => x.CreativeParameterKey);
        }

        public IQueryable<CreativeReview> GetCreativeReviews(Guid id)
        {
            return _creativeReviewRepositoryAsync.Queryable()
                .Where(x => x.Creative.CreativeUuid == id);
        }

        public async Task CreateOrUpdateCreativeReview(CreativeReviewModifyOptions options)
        {
            var reviews = await _creativeReviewRepositoryAsync.Queryable()
                .Where(x => x.Creative.CreativeUuid == options.CreativeUuid)
                .ToListAsync();

            var internalReview = reviews.FirstOrDefault(x => x.PartnerId == 0);
            if (internalReview == null && options.PartnerId != 0) throw new BrandscreenException("Cannot create exchange review prior to internal review.");

            var review = reviews.FirstOrDefault(x => x.PartnerId == options.PartnerId);

            // cancel
            if (options.Status == CreativeReviewStatusEnum.Canceled && review != null)
            {
                await _creativeReviewRepositoryAsync.DeleteAsync(review.CreativeId, review.PartnerId);
                await _brandscreenContext.SaveChangesAsync();
                return; // save and return
            }

            // create or update
            var creative = await GetCreative(options.CreativeUuid);
            if (review != null)
            {
                review.ObjectState = ObjectState.Modified;
            }
            else
            {
                review = new CreativeReview
                {
                    ObjectState = ObjectState.Added,
                    PartnerId = options.PartnerId,
                    CreativeId = creative.CreativeId
                };
            }
            review.ExchangeErrorString = options.ExchangeErrorString;
            review.CreativeReviewStatusId = (int) options.Status;
            review.UtcModifiedDateTime = _clock.UtcNow;
            _creativeReviewRepositoryAsync.InsertOrUpdateGraph(review);

            // reject
            if (options.Status == CreativeReviewStatusEnum.Rejected)
            {
                // delete all existing rejections
                var rejections = await _creativeReviewRejectionRepositoryAsync.Queryable()
                    .Where(x => x.CreativeId == creative.CreativeId && x.PartnerId == options.PartnerId)
                    .ToListAsync();
                rejections.ForEach(rejection => _creativeReviewRejectionRepositoryAsync.Delete(rejection));

                // create new rejections
                foreach (var rejectionReasonId in options.RejectionReasonIds)
                {
                    _creativeReviewRejectionRepositoryAsync.Insert(new CreativeReviewRejection
                    {
                        CreativeId = creative.CreativeId,
                        PartnerId = options.PartnerId,
                        RejectionReasonId = rejectionReasonId
                    });
                }
            }

            // save
            await _brandscreenContext.SaveChangesAsync();

            if (_creativeSettings.SendingRejectionEmail && options.Status == CreativeReviewStatusEnum.Rejected)
            {
                // msmq
                _serviceBus.Send(new CreativeRejectionReceivedEvent
                {
                    CreativeId = creative.CreativeId,
                    PartnerId = options.PartnerId,
                    ReasonIds = options.RejectionReasonIds
                }, noThrowServiceNotAvailableException: true);
            }
        }

        private static Tuple<int, int> GetImageSize(byte[] image)
        {
            var imgInfo = ImageBuilder.Current.LoadImageInfo(image, null);
            return new Tuple<int, int>((int) imgInfo["source.width"], (int) imgInfo["source.height"]);
        }

        private static Tuple<int, int> GetFlashSize(byte[] flash)
        {
            using (var ms = new MemoryStream(flash))
            {
                var swf = new SwfReader(ms).ReadSwf();
                return new Tuple<int, int>(swf.Header.Width, swf.Header.Height);
            }
        }

        private async Task SetCreativeClickUrl(Creative creative, string clickUrl)
        {
            clickUrl = clickUrl.TrimEnd('?', '/'); // remove trailing slash and empty query
            var uri = new UriBuilder(clickUrl).Uri; // if uri does not specify a scheme, the scheme defaults to "http:"
            clickUrl = uri.AbsoluteUri;
            var clickThroughUrl = clickUrl;
            string clickTrackerUrl = null;

            using (var fc = new FlurlClient(clickUrl))
            {
                try
                {
                    var result = await fc.AllowAnyHttpStatus().GetAsync();
                    creative.UrlValidated = result.IsSuccessStatusCode;

                    // handle redirect
                    if (result.IsSuccessStatusCode)
                    {
                        var isRedirect = (0 != Uri.Compare(uri,
                            result.RequestMessage.RequestUri,
                            UriComponents.HostAndPort | UriComponents.PathAndQuery,
                            UriFormat.SafeUnescaped,
                            StringComparison.OrdinalIgnoreCase));
                        if (isRedirect)
                        {
                            clickTrackerUrl = clickUrl;
                            clickThroughUrl = result.RequestMessage.RequestUri.AbsoluteUri;
                        }
                    }
                }
                catch (Exception ex)
                {
                    creative.UrlValidated = false;
                    Logger.WarnFormat(ex, "unable to validate url {0}", clickUrl);
                }
            }

            creative.ClickThroughUrl = clickThroughUrl;
            creative.ClickTrackerUrl = clickTrackerUrl;
        }

        private async Task<byte[]> GenerateThumbnail(byte[] image, int maxWidth, int maxHeight, string format)
        {
            var resizeSetting = new ResizeSettings {MaxWidth = maxWidth, MaxHeight = maxHeight};
            if (!string.IsNullOrEmpty(format)) resizeSetting.Format = format;
            using (var ms = new MemoryStream())
            {
                await Task.Run(() => { ImageBuilder.Current.Build(image, ms, resizeSetting); }).ConfigureAwait(false);
                return ms.ToArray();
            }
        }

        private void AddCreativeParameter(Creative creative, string key, string value)
        {
            creative.CreativeParameters.Add(new CreativeParameter
            {
                ObjectState = ObjectState.Added,
                CreativeId = creative.CreativeId,
                Creative = creative,
                CreativeParameterKey = key,
                CreativeParameterValue = value
            });
        }

        private async Task EnsureUniqueCreativeName(Creative creative)
        {
            while (true)
            {
                var creativeWithSameName = await _creativeRepositoryAsync.Queryable()
                    .Where(PredicateNotDelete)
                    .Where(x => x.CreativeName == creative.CreativeName && x.AdvertiserProductId == creative.AdvertiserProductId)
                    .FirstOrDefaultAsync();

                if (creativeWithSameName == null) return; // no duplication: new creative
                if (creativeWithSameName.CreativeId == creative.CreativeId) return; // no duplication: existing creative

                // change name: appending num at the end
                var match = Regex.Match(creative.CreativeName, @"\s\((\d+)\)$", RegexOptions.Compiled);
                if (match.Success)
                {
                    var num = int.Parse(match.Groups[1].Value);
                    creative.CreativeName = Regex.Replace(creative.CreativeName, @"\s\((\d+)\)$", $" ({++num})", RegexOptions.Compiled);
                }
                else
                {
                    creative.CreativeName = creative.CreativeName.TrimEnd() + " (1)";
                }
            }
        }

        private void ApplySpecialAdTagCreativeSize(int adTagTemplateId, CreativeSize creativeSize, IDictionary<string, string> creativeParameters)
        {
            // special for Ozone Media 54
            const int ozoneMediaIframeTemplateId = 54;
            if (adTagTemplateId == ozoneMediaIframeTemplateId)
            {
                if (!creativeParameters.ContainsKey("WIDTH") && creativeSize.Width != null)
                {
                    creativeParameters["WIDTH"] = creativeSize.Width.Value.ToString();
                }
                if (!creativeParameters.ContainsKey("HEIGHT") && creativeSize.Height != null)
                {
                    creativeParameters["HEIGHT"] = creativeSize.Height.Value.ToString();
                }
            }
        }

        private bool ValidateAdTagCreativeSize(CreativeSize creativeSize, IDictionary<string, string> creativeParameters)
        {
            // looking for width & height
            var width = creativeParameters.ContainsKey("WIDTH") ? int.Parse(creativeParameters["WIDTH"]) : 0;
            if (width == 0) width = creativeParameters.ContainsKey("ZEDO_WIDTH") ? int.Parse(creativeParameters["ZEDO_WIDTH"]) : 0;
            var height = creativeParameters.ContainsKey("HEIGHT") ? int.Parse(creativeParameters["HEIGHT"]) : 0;
            if (height == 0) height = creativeParameters.ContainsKey("ZEDO_HEIGHT") ? int.Parse(creativeParameters["ZEDO_HEIGHT"]) : 0;

            // if size defined, it must match specified creative size
            return (width <= 0 || width == creativeSize.Width) && (height <= 0 || height == creativeSize.Height);
        }
    }
}