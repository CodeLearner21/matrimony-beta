using Matrimony.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Database.Repository.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<int> CreateAsync(Portfolio portfolio);
        Task<Portfolio> GetByIdAsync(int id);
    }
}
