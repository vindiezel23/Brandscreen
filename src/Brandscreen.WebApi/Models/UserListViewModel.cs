using System;
using AutoMapper;
using Brandscreen.Entities;

namespace Brandscreen.WebApi.Models
{
    public class UserListViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserListViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserListViewModel>();
        }
    }
}