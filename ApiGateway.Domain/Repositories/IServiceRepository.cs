using ApiGateway.Domain.Common;
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
        IUnitOfWork UnitOfWork { get; }

        Task<Service> GetServiceAsync(string id);
        Service AddService(Service service);
        void UpdateService(Service service);
    }
}
