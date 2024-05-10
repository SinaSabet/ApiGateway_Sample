using ApiGateway.Application.Dtos;
using Ocelot.Configuration.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Query
{
    public interface IQueryService
    {
        Task<List<FileRoute>> getServicesAsync_ForOcelot(string cachekey);
    }
}
