using Matrimony.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(UserRegisterDto userRegister);
    }
}
