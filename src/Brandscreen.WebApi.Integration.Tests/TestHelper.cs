using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Flurl.Http;
using Newtonsoft.Json;
using Nito.AsyncEx;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Integration.Tests
{
    public static class TestHelper
    {
        public static readonly string TokenUrl = HostServer.Url + "token";

        /// <summary>
        /// Super/System admin token
        /// </summary>
        public static AsyncLazy<string> Token = new AsyncLazy<string>(() => GetAccessTokenAsync("jwu@brandscreen.com", "abcd1234"));

        /// <summary>
        /// User token
        /// </summary>
        public static AsyncLazy<string> UserToken = new AsyncLazy<string>(() => GetAccessTokenAsync("ywong@brandscreen.com", "abcd1234"));

        public static async Task<string> GetAccessTokenAsync(string userName, string password)
        {
            var postData = new
            {
                grant_type = "password",
                username = userName,
                password = password
            };
            var response = await TokenUrl.PostUrlEncodedAsync(postData).ReceiveJson().ConfigureAwait(false);
            var accessToken = response.access_token;
            Console.WriteLine("retrieved access token {0}", accessToken);
            return accessToken;
        }

        public static void LoadDbData<TEntity>(this ILifetimeScope container, string suffix = null) where TEntity : class, IObjectState
        {
            var type = typeof (TEntity);
            var dataBase = type.Namespace.Substring(0, type.Namespace.IndexOf("Entities", StringComparison.Ordinal)).Replace(".", "");
            var table = string.IsNullOrEmpty(suffix) ? type.Name : $"{type.Name}-{suffix}";
            var path = $@"Data\{dataBase}\{table}.json";
            var json = File.ReadAllText(path).Trim('\r', '\n', ' ');
            var isArray = json.StartsWith("[");
            if (isArray)
            {
                var entities = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
                container.Resolve<IRepositoryAsync<TEntity>>().InsertRange(entities);
            }
            else
            {
                var entity = JsonConvert.DeserializeObject<TEntity>(json);
                container.Resolve<IRepositoryAsync<TEntity>>().Insert(entity);
            }
        }
    }
}