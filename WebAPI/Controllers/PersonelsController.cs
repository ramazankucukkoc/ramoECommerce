using Application.Features.Personels.Command.CreatePersonel;
using Application.Features.Personels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePersonelCommand createPersonelCommand)
        {
            CreatePersonelDto result = await Mediator.Send(createPersonelCommand);
            return Ok(result);
        }

    }
}
