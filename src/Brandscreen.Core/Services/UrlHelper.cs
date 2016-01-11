using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;

namespace Brandscreen.Core.Services
{
    public class UrlHelper
    {
        /// <summary>
        /// Tests an url
        /// </summary>
        public static async Task<bool> IsValidUrl(string url)
        {
            try
            {
                var uri = new UriBuilder(url).Uri; // if uri does not specify a scheme, the scheme defaults to "http:"
                using (var fc = new FlurlClient(uri.AbsoluteUri))
                {
                    var response = await fc.AllowAnyHttpStatus()
                        .EnableCookies()
                        .WithTimeout(10)
                        .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.71 Safari/537.36")
                        .WithHeader("Range", "bytes=0-1")
                        .SendAsync(HttpMethod.Get)
                        .ConfigureAwait(false);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Normalizes an url
        /// </summary>
        public static string ToClearUrl(string url)
        {
            try
            {
                var uri = new UriBuilder(url).Uri; // if uri does not specify a scheme, the scheme defaults to "http:"
                return uri.AbsoluteUri; // removed port number if defaults to protocol e.g. http - 80, https - 443
            }
            catch
            {
                return url;
            }
        }
    }
}