using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class UserViewModel
    {
        public Guid UserId { get; set; } // UserID (Primary key)
        public string UserName { get; set; } // UserName
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string Mobile { get; set; } // Mobile
        public string Email { get; set; } // Email
        public int? LanguageId { get; set; } // LanguageID
        public int TimeSpanId { get; set; } // TimeSpanID
        public string Position { get; set; } // Position
    }

    public class UserViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}