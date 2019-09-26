using Matrimony.Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Database.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(AppUser user, string password);
        Task<bool> CheckPassword(AppUser user, string password);
        Task<AppUser> FindByEmail(string email);
        Task<AppUser> FindByName(string userName);
    }
}
