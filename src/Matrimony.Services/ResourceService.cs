using AutoMapper;
using Matrimony.Database.Repository.Interfaces;
using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrimony.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ResourceService> _logger;        

        public ResourceService(IResourceRepository resourceRepository, IMapper mapper, ILogger<ResourceService> logger)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PortfolioTypeDto>> GetPortfolioTypes()
        {
            try
            {
                var portfolioTypes = await _resourceRepository.GetPortfolioTypesAsync();
                if (portfolioTypes == null)
                    return null;

                var allTypes = _mapper.Map<IEnumerable<PortfolioTypeDto>>(portfolioTypes);

                return allTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Resource Service Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
    }
}
