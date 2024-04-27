using ApiGateway.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Domain.Entities
{
    public class Service: BaseEntity
    {
        public string ServiceName { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public Service()
        {
            
        }

        public Service(string serviceName, string downstreamPathTemplate, string downstreamScheme, string upstreamPathTemplate, List<string> upstreamHttpMethod, string host, int port)
        {
            ServiceName = serviceName;
            DownstreamPathTemplate = downstreamPathTemplate;
            DownstreamScheme = downstreamScheme;
            UpstreamPathTemplate = upstreamPathTemplate;
            UpstreamHttpMethod = upstreamHttpMethod;
            Host = host;
            Port = port;
        }
    }
}
