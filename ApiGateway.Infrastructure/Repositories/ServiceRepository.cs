using ApiGateway.Domain.Common;
using ApiGateway.Domain.Entities;
using ApiGateway.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApiGatewayContext _context;

        public IUnitOfWork UnitOfWork => _context;
        public ServiceRepository(ApiGatewayContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Service> CreateServiceAsync(Service service)
        {
            var result = await _context.services.AddAsync(service);
            return result.Entity;
        }

        public async Task<Service> GetServiceAsync(string id)
        {
            var service = await _context.services.FindAsync(id);
            return service;
        }

        public void UpdateService(Service service)
        {
             _context.Entry(service).State = EntityState.Modified;

        }

        public Service AddService(Service service)
        {
            return _context.services.Add(service).Entity;
        }
    }
}
