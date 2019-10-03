using Matrimony.Database.Entities;
using Matrimony.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Database.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger<PortfolioRepository> _logger;
        public PortfolioRepository(ApiContext context, ILogger<PortfolioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateAsync(Portfolio portfolio)
        {
            try
            {
                _context.Entry<AppUser>(portfolio.User).State = EntityState.Unchanged;
                _context.Entry<PortfolioType>(portfolio.PortfolioType).State = EntityState.Unchanged;
                await _context.Portfolios.AddAsync(portfolio);
                await _context.SaveChangesAsync();
                if(portfolio.Id > 0)
                    return portfolio.Id;

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Porfolio Repository Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            if (id < 1)
                return null;

            try
            {
                var result = await _context.Portfolios.Include(p => p.PortfolioType).FirstOrDefaultAsync(p => p.Id == id);
                if (result != null)
                    return result;

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Portfolio Repository Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }
    }
}
