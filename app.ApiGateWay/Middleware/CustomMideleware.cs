using ApiGateway.Application.Query;
using app.ApiGateWay.Extensions;
using Ocelot.Configuration;
using Ocelot.Configuration.Creator;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;
using System.ComponentModel.DataAnnotations;

namespace app.ApiGateWay.Middleware
{
    public class CustomMideleware
    {
        private readonly RequestDelegate _next;
        public CustomMideleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await CreateConfiguration(context, context.Request.Path.Value);
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 200;
               // await context.Response.WriteAsync(new ApiResult<System.Exception>(ex, ex.ValidationErrors, ex.ValidationWarnings, null).ToJson());
            }

        }

        public static async Task<IInternalConfiguration> CreateConfiguration(HttpContext context, string cacheKey)
        {



            var routes = await context.RequestServices.GetService<IQueryService>().getServicesAsync_ForOcelot(cacheKey);
          

            var ocelotConfiguration = new FileConfiguration
            {
                Routes = routes
            };
            var internalConfigCreator = context.RequestServices.GetService<IInternalConfigurationCreator>();
            var internalConfig = await internalConfigCreator.Create(ocelotConfiguration);
            //Configuration error, throw error message
            if (internalConfig.IsError)
            {
                ThrowToStopOcelotStarting(internalConfig);
            }

            var internalConfigRepo = context.RequestServices.GetService<IInternalConfigurationRepository>();
            internalConfigRepo.AddOrReplace(internalConfig.Data);
            return internalConfig.Data;
        }


        private static void ThrowToStopOcelotStarting(Response config)
        {
            throw new System.Exception($"Unable to start Ocelot, errors are: {string.Join(",", config.Errors.Select(x => x.ToString()))}");
        }

       


        //private static void ThrowToStopOcelotStarting(Response config)
        //{
        //    throw new System.Exception($"Unable to start Ocelot, errors are: {string.Join(",", config.Errors.Select(x => x.ToString()))}");
        //}

    }
}

