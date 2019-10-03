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
    public class ResourceRepository : IResourceRepository
    {
        private readonly ApiContext _context;
        private ILogger<ResourceRepository> _logger;
        public ResourceRepository(ApiContext context, ILogger<ResourceRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<PortfolioType>> GetPortfolioTypesAsync()
        {
            try
            {
                var allPortfolioTypes = await _context.PortfolioTypes.ToListAsync();
                if (allPortfolioTypes != null)
                    return allPortfolioTypes;

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Database Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }            
        }

        public async Task<PortfolioType> GetPortFolioTypeByIdAsync(int id)
        {
            try
            {
                var result = await _context.PortfolioTypes.FindAsync(id);
                if (result != null)
                    return result;

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Portfoliotype Repository Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
    }
}
