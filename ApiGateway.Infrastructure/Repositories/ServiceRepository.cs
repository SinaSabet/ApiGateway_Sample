using ApiGateway.Domain.Entities;
using ApiGateway.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        public Task<Service> CreateService(Service service)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetService(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateService(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
