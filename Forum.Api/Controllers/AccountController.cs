﻿using Forum.Api.Infrastructure.Configurations;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Forum.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : ApplicationControllerBase
    {
        private readonly JwtAuthOptions _jwtAuthOptions;
        private readonly IAccountService _accountService;

        public AccountController(IOptions<JwtAuthOptions> jwtAuthOptions, IAccountService accountService)
        {
            _accountService = accountService;
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authOptions = (_jwtAuthOptions.Token, _jwtAuthOptions.Audience, _jwtAuthOptions.Issuer);

            var jwtToken = await _accountService.LoginUserAsync(userLoginDto, authOptions);

            return Ok(new { AccessToken = jwtToken });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isRegistered = await _accountService.RegisterUserAsync(userRegisterDto);

            return CreatedAtAction(nameof(Register), new { registrationSucceded = isRegistered });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
