using ApiGateway.Application.Dtos;
using ApiGateway.Domain.Entities;
using ApiGateway.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Commands.CreateService
{
    public class CreateServiceCommandHandler(IServiceRepository serviceRepository, IDistributedCache  distributedCache) : IRequestHandler<CreateServiceCommand, ResponseDto<bool>>
    {
        private readonly IServiceRepository _serviceRepository = serviceRepository;
        private readonly IDistributedCache _cache= distributedCache;
        public async Task<ResponseDto<bool>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.ServiceName, request.DownstreamPathTemplate, request.DownstreamScheme, request.UpstreamPathTemplate, request.UpstreamHttpMethod, request.Host, request.Port);
            _serviceRepository.AddService(service);
            var result = await _serviceRepository.UnitOfWork.SaveEntitiesAsync();

            if (result)
            {
                _cache.Remove("services");
                return new ResponseDto<bool>()
                {
                    Code = 200,
                    Data = result,
                    IsSuccess = true,
                    Message = "Service Added"
                };
            }

            throw new Exception("add service Error");
        }
    }
}
