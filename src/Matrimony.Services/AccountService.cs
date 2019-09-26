using AutoMapper;
using Matrimony.Database.Entities;
using Matrimony.Database.Repository.Interfaces;
using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AccountService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDto userRegister)
        {
            try
            {
                var appUser = _mapper.Map<AppUser>(userRegister);
                var result = await _userRepository.Create(appUser, userRegister.Password);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
