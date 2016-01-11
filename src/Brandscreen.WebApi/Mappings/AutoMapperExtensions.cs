using AutoMapper;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Mappings
{
    public static class AutoMapperExtensions
    {
        public static T Map<T>(this IMappingEngine mapping, object source, IPagination pagination)
        {
            return mapping.Map<T>(source, opts =>
            {
                opts.Items.Add("PageNumber", pagination.PageNumber);
                opts.Items.Add("PageSize", pagination.PageSize);
            });
        }

        public static T Resolve<T>(this ResolutionContext resolutionContext)
        {
            var type = typeof (T);
            return (T) resolutionContext.Options.ServiceCtor(type);
        }
    }
}