using Matrimony.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<int> CreatePortfolio(CreatePortfolioDto createPortfolio);
        Task<UserPorfolioDto> GetPortfolioById(int id);
    }
}
