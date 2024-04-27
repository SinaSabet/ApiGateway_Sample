using ApiGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> GetService(string id);
        Task<Service> CreateService(Service service);
        Task<bool> UpdateService(Service service);
    }
}
