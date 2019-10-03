using AutoMapper;
using Matrimony.Database.Entities;
using Matrimony.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Create(AppUser user, string password)
        {
            string randomUserName = null;

            do
            {
                Random generator = new Random();
                String r = generator.Next(0, 999999).ToString("D6");
                randomUserName = "KGJ" + r.ToString();
            }
            while (string.IsNullOrWhiteSpace(randomUserName) || await FindByName(randomUserName) != null);

            user.UserName = randomUserName;

            var identityResult = await _userManager.CreateAsync(user, password);

            return identityResult;
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<AppUser> FindByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser> FindByName(string userName)
        {
            return  await _userManager.FindByNameAsync(userName);
        }

        public async Task<AppUser> FindById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

    }
}
