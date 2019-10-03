using Matrimony.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Database.Repository.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<PortfolioType>> GetPortfolioTypesAsync();
        Task<PortfolioType> GetPortFolioTypeByIdAsync(int id);
    }
}
