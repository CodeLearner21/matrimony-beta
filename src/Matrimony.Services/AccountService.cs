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
        private readonly IJwtFactory _jwtFactory;
        public AccountService(IUserRepository userRepository, IMapper mapper, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtFactory = jwtFactory;
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

        public async Task<Token> LoginUser(UserLoginDto userLogin)
        {
            if(!string.IsNullOrEmpty(userLogin.Email) && !string.IsNullOrEmpty(userLogin.Password))
            {
                // Confirm we have user with given email address
                var user = await _userRepository.FindByEmail(userLogin.Email);
                if(user != null)
                {
                    // Validate password
                    if(await _userRepository.CheckPassword(user, userLogin.Password))
                    {
                        Token token = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName);
                        return token;
                    }
                }
            }

            return null;
        }
    }
}
