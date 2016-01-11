using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Brandscreen.Core.Services.Creatives;

namespace Brandscreen.WebApi.Models
{
    public class CreativeReviewViewModel
    {
        [Required]
        public int? CreativeVersion { get; set; }

        /// <summary>
        /// Empty for internal review, otherwise for exchange review.
        /// </summary>
        public int? PartnerId { get; set; }

        /// <summary>
        /// Approved, Reviewing, Ready, Rejected, or Canceled.
        /// </summary>
        [Required]
        [EnumDataType(typeof (CreativeReviewStatusEnum))]
        public string Status { get; set; }

        /// <summary>
        /// Reason(s) for rejection.
        /// </summary>
        public int[] RejectionReasonIds { get; set; }

        /// <summary>
        /// Raw infomation from exchange.
        /// </summary>
        public string ExchangeErrorString { get; set; }
    }

    public class CreativeReviewViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreativeReviewViewModel, CreativeReviewModifyOptions>()
                .ConstructUsing(context =>
                {
                    var creativeUuid = (Guid) context.Options.Items["creativeUuid"];
                    var retVal = new CreativeReviewModifyOptions {CreativeUuid = creativeUuid};
                    return retVal;
                })
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => Enum.Parse(typeof (CreativeReviewStatusEnum), src.Status, true)));
        }
    }
}