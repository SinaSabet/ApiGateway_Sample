namespace app.ApiGateWay.Extensions
{
    public class OutputOcelotRouteDto
    {
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
