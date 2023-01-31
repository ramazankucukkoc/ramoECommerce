using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Dtos;
using Core.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        //WebAPIConfiguration bu bize ileride lazım olacaktır.
        private readonly WebAPIConfiguration _configuration;
        public AuthsController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = getIpAddress() };
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            return Ok(registeredDto.AccessToken);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = getIpAddress() };
            LoggedDto loggedDto = await Mediator.Send(loginCommand);
            return Ok(loggedDto.AccessToken);
        }

    }
}
