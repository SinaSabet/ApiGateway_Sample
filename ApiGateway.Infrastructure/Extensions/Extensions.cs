using ApiGateway.Domain.Repositories;
using ApiGateway.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Infrastructure.Extensions
{
    public static class Extensions
    {
        public  static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ApiGatewayContext, ApiGatewayContext>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            return services;
        }
    }
}
