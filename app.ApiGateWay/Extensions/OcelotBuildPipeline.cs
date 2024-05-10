using Ocelot.Middleware;

namespace app.ApiGateWay.Extensions
{
    public static class OcelotBuildPipeline
    {
        public static IApplicationBuilder UseOcelotBuildPipeline(this IApplicationBuilder builder)
        {
            builder.UseOcelotBuildPipeline(new OcelotPipelineConfiguration());
            return builder;
        }

        public static IApplicationBuilder UseOcelotBuildPipeline(this IApplicationBuilder builder, OcelotPipelineConfiguration pipelineConfiguration)
        {
            builder.BuildOcelotPipeline(pipelineConfiguration);
            return builder;
        }
    }
}
