using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Brandscreen.Core.Services.Campaigns;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using LinqKit;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Segments
{
    public interface ISegmentService : IDependency
    {
        Task<Segment> GetSegment(int id);
        Task<Segment> GetSegment(string rtbId);
        IQueryable<Segment> GetSegments();
        IQueryable<Segment> GetSegments(SegmentQueryOptions options);

        Task CreateSegment(Segment segment);
        Task UpdateSegment(Segment segment);
        Task DeleteSegment(int id);
    }

    public class SegmentService : ISegmentService
    {
        private readonly IRepositoryAsync<Segment> _segmentRepositoryAsync;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IClock _clock;

        private static readonly Expression<Func<Segment, bool>> PredicateNotDelete =
            x => !x.IsDeleted && (x.Advertiser == null || !x.Advertiser.IsDeleted) && (x.BuyerAccount == null || !x.BuyerAccount.IsDeleted);

        public SegmentService(IRepositoryAsync<Segment> segmentRepositoryAsync, IBrandscreenContext brandscreenContext, IClock clock)
        {
            _segmentRepositoryAsync = segmentRepositoryAsync;
            _brandscreenContext = brandscreenContext;
            _clock = clock;
        }

        public Task<Segment> GetSegment(int id)
        {
            return _segmentRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .Include(x => x.BuyerAccount)
                .Include(x => x.Advertiser)
                .FirstOrDefaultAsync(x => x.SegmentId == id);
        }

        public Task<Segment> GetSegment(string rtbId)
        {
            return _segmentRepositoryAsync.Queryable()
                .Where(PredicateNotDelete)
                .Include(x => x.BuyerAccount)
                .Include(x => x.Advertiser)
                .FirstOrDefaultAsync(x => x.RtbSegmentId == rtbId);
        }

        public IQueryable<Segment> GetSegments()
        {
            var source = _segmentRepositoryAsync.Queryable()
                .Where(PredicateNotDelete);
            return source.OrderBy(x => x.SegmentName);
        }

        public IQueryable<Segment> GetSegments(SegmentQueryOptions options)
        {
            var source = GetSegments();

            if (options.BuyerAccountIds.Count > 0 || options.UserIds.Count > 0)
            {
                var predicate = PredicateBuilder.False<Segment>();
                if (options.BuyerAccountIds.Count > 0)
                {
                    // filter by BuyerAccountId when user is AgencyAdministrator
                    predicate = predicate.Or(x => x.BuyerAccountId.HasValue && options.BuyerAccountIds.Contains(x.BuyerAccountId.Value));
                }
                if (options.UserIds.Count > 0)
                {
                    // filter by UserAdvertiserRoles when user is AgencyUser
                    predicate = predicate.Or(x => x.Advertiser.UserAdvertiserRoles.Any(r => options.UserIds.Contains(r.UserId)));
                }
                source = source.AsExpandable().Where(predicate);
            }

            if (options.AdvertiserUuid.HasValue)
            {
                source = source.Where(x => x.Advertiser.AdvertiserUuid == options.AdvertiserUuid.Value);
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.SegmentName.Contains(options.Text));
            }

            return source;
        }

        public Task CreateSegment(Segment segment)
        {
            segment.RtbSegmentId = IdentityValue.GenerateNewId();
            segment.SegmentStatusId = (int) CampaignStatusEnum.Pending;
            segment.UtcCreatedDateTime = _clock.UtcNow;
            _segmentRepositoryAsync.Insert(segment);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateSegment(Segment segment)
        {
            segment.UtcModifiedDateTime = _clock.UtcNow;
            _segmentRepositoryAsync.Update(segment);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteSegment(int id)
        {
            var segment = await GetSegment(id);
            segment.IsDeleted = true;
            segment.ThirdPartyIsDeleted = true;
            await UpdateSegment(segment);
        }
    }
}