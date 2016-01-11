using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class SegmentListViewModel
    {
        public int SegmentId { get; set; } // SegmentID (Primary key)
        public string RtbSegmentId { get; set; } // RtbSegmentID
        public string SegmentName { get; set; } // SegmentName
        public int SegmentTypeId { get; set; } // SegmentTypeID
        public int SegmentStatusId { get; set; } // SegmentStatusID
        public DateTime UtcCreatedDateTime { get; set; } // UtcCreatedDateTime
        public DateTime UtcModifiedDateTime { get; set; } // UtcModifiedDateTime
    }

    public class SegmentListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Segment, SegmentListViewModel>();
        }
    }
}