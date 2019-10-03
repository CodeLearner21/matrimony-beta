using Matrimony.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Services.Interfaces
{
    public interface IResourceService
    {
        Task<IEnumerable<PortfolioTypeDto>> GetPortfolioTypes();
    }
}
