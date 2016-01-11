using AutoMapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Mappings;
using Nito.AsyncEx.Synchronous;

namespace Brandscreen.WebApi.Models
{
    public class UserPatchViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }

        public string LanguageCode { get; set; }
    }

    public class UserPatchViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserPatchViewModel, User>()
                .ForMember(dst => dst.LanguageId, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.LanguageCode));
                    opt.ResolveUsing(result =>
                    {
                        var source = (UserPatchViewModel) result.Value;
                        var language = result.Context.Resolve<ILanguageService>().GetLanguageOrDefault(source.LanguageCode).WaitAndUnwrapException();
                        return language.LanguageId;
                    });
                })
                .ForAllMembers(opt => opt.Condition(ctx => !ctx.IsSourceValueNull)); // for partial updates
        }
    }
}