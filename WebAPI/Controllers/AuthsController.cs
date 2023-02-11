using Application.Features.Auths.Command.EnableEmailAuthenticator;
using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.LoginWithGoogle;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Dtos;
using Core.Application.DTOs;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/auth/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        //WebAPIConfiguration bu bize ileride lazım olacaktır.
        private readonly WebAPIConfiguration _configuration;
        public AuthsController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }
        /// <summary>
        /// Kullanıcı Kaydetme işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = getIpAddress() };
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            setRefreshTokenCookie(registeredDto.RefreshToken);
            return Ok(registeredDto.AccessToken);
        }
        /// <summary>
        /// Kullanıcı Giriş işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = getIpAddress() };
            LoggedDto result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null) setRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
        /// <summary>
        /// Kullanıcı Google ile giriş işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LoginWithGoogle([FromBody] LoginWithGoogleDto loginWithGoogleDto)
        {
            LoginWithGoogleCommand loginWithGoogleCommand = new()
            { LoginWithGoogleDto = loginWithGoogleDto, IpAddrres = getIpAddress() };

            LoggedDto result = await Mediator.Send(loginWithGoogleCommand);

            if (result.RefreshToken is not null) setRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
        [HttpGet]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest(),
                VerifyEmailUrlPrefix = $"{_configuration.APIDomain}/Auths/EnableEmailAuthenticator"
            };
            await Mediator.Send(enableEmailAuthenticatorCommand);
            return Ok();
        }
        private void setRefreshTokenCookie(RefreshToken refreshToken)
        {
            CookieOptions options = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, options);
        }

    }
}
