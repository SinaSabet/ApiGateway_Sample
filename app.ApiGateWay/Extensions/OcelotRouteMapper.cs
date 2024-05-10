using ApiGateway.Application.Dtos;
using Ocelot.Configuration.File;

namespace app.ApiGateWay.Extensions
{
    public static class OcelotRouteMapper
    {
  
        public static FileConfiguration MapDtoToConfiguration(this GetServicesQuery ocelotRouteDto)
        {
            if (ocelotRouteDto is null)
            {
                return null;
            }

            var file = new FileConfiguration();
            var routeList = new List<FileRoute>();
            routeList.Add(new FileRoute
            {
                DownstreamPathTemplate = ocelotRouteDto.DownstreamPathTemplate,
                DownstreamScheme = ocelotRouteDto.DownstreamScheme,
                UpstreamHttpMethod = ocelotRouteDto.UpstreamHttpMethod.ToList(),
                UpstreamPathTemplate = ocelotRouteDto.UpstreamPathTemplate
            });

            file.Routes = routeList;
            return file;
        }
    }
}
