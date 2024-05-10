using ApiGateway.Application.Dtos;
using ApiGateway.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Ocelot.Configuration.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Query
{
    public class QueryService(ApiGatewayContext context, IDistributedCache distributedCache) : IQueryService
    {
        private readonly ApiGatewayContext _db = context;
        private readonly IDistributedCache _cache = distributedCache;

      

        public async Task<List<FileRoute>> getServicesAsync_ForOcelot(string cachekey)
        {
            var services_cache = await _cache.GetAsync(cachekey);
            if (services_cache != null)
            {
                var cachedData = Encoding.UTF8.GetString(services_cache);
                var servicesList = JsonConvert.DeserializeObject<List<FileRoute>>(cachedData);
                return servicesList;
            }


            var services = await _db.services.Select(x => new FileRoute()
            {
                DownstreamPathTemplate = x.DownstreamPathTemplate,
                DownstreamScheme = x.DownstreamScheme,
                DownstreamHostAndPorts = new List<FileHostAndPort>
                {
                    new FileHostAndPort
                    {
                        Host = x.Host,
                        Port = x.Port,
                    }
                },
                ServiceName = x.ServiceName,
                UpstreamHttpMethod = x.UpstreamHttpMethod,
                UpstreamPathTemplate = x.UpstreamPathTemplate
            }).ToListAsync();

            var cacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) // نیم ساعت بعد از زمان فعلی
            };

            await _cache.SetAsync(cachekey, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(services)), cacheOptions);
            return services;


        }
    }
}
