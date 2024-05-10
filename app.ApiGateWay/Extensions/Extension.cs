using ApiGateway.Application.Query;
using Ocelot.DependencyInjection;

namespace app.ApiGateWay.Extensions
{
    public static class Extension
    {
        public static IServiceCollection RegisterApiGateway(this IServiceCollection services)
        {

          

           


            services.AddScoped<IQueryService, QueryService>();

            return services;
        }
   
    }
}
