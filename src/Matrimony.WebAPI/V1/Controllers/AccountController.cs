using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrimony.Dtos;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.WebAPI.V1.Controllers
{
    [Authorize]
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUp(UserRegisterDto userRegister)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.RegisterUser(userRegister);
            if(!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignIn(UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _accountService.LoginUser(userLogin);
            if (!string.IsNullOrWhiteSpace(token.AuthToken))
                return Ok(token);

            return BadRequest();
        }
    }
}