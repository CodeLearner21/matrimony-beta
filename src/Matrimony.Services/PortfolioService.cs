using AutoMapper;
using Matrimony.Database.Entities;
using Matrimony.Database.Repository.Interfaces;
using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IUserRepository _userRepository;
        
        private readonly IMapper _mapper;
        private readonly ILogger<PortfolioService> _logger;
        public PortfolioService(IPortfolioRepository portfolioRepository, IResourceRepository resourceRepository, IUserRepository userRepository, IMapper mapper, ILogger<PortfolioService> logger)
        {
            _portfolioRepository = portfolioRepository;
            _resourceRepository = resourceRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> CreatePortfolio(CreatePortfolioDto createPortfolio)
        {
            try
            {                
                var porfolio = _mapper.Map<Portfolio>(createPortfolio);

                var selectedUser = await _userRepository.FindById(createPortfolio.UserId);
                var selectedPortfolioType = await _resourceRepository.GetPortFolioTypeByIdAsync(createPortfolio.PortfolioTypeId);

                porfolio.User = selectedUser;
                porfolio.PortfolioType = selectedPortfolioType;

                var result = await _portfolioRepository.CreateAsync(porfolio);
                if (result > 0)
                    return result;

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Poerfolio Service Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserPorfolioDto> GetPortfolioById(int id)
        {
            if (id < 1)
                return null;

            try
            {
                var result = await _portfolioRepository.GetByIdAsync(id);
                if (result == null)
                    return null;

                return _mapper.Map<UserPorfolioDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Portfolio Service Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserPorfolioDto> GetPortfolioByUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            try
            {
                var result = await _portfolioRepository.GetByUserIdAsync(userId);
                if (result == null)
                    return null;

                return _mapper.Map<UserPorfolioDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error - Portfolio Service Exception: " + ex.Message + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
    }
}
