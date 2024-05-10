using ApiGateway.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Commands.CreateService
{
    public class CreateServiceCommand:IRequest<ResponseDto<bool>>
    {
        public string ServiceName { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
