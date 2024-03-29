﻿using Microsoft.AspNetCore.Mvc;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Services.Users;
using Ribbons.Users.Authentication.Models;

namespace Ribbons.Loyalty.Web.Controllers
{
    [Route("auth")]
    public abstract class AuthControllerBase : Controller
    {
        protected LoyaltyUser UserType { get; }
        protected IUserAuthenticator UserAuthenticator { get; }

        public AuthControllerBase(LoyaltyUser userType, IUserAuthenticator userAuthenticator)
        {
            UserType = userType;
            UserAuthenticator = userAuthenticator;
        }

        [Route("/")]
        [Route("login")]
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<LoginResponse> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            return await UserAuthenticator.LoginAsync(UserType, loginRequest, Response);
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await UserAuthenticator.LogoutAsync(UserType, Request, Response);

            return View();
        }

        [Route("password/recover")]
        [HttpGet]
        public async Task<IActionResult> RecoverPasswordAsync()
        {
            return View();
        }

        [Route("password/reset")]
        [HttpGet]
        public async Task<IActionResult> ResetPasswordAsync()
        {
            return View();
        }
    }
}