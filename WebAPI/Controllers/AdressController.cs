using Application.Features.Addresss.Command.CreateAddress;
using Application.Features.Addresss.Command.DeleteAddress;
using Application.Features.Addresss.Command.UpdateAddress;
using Application.Features.Addresss.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdressController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddressCommand)
        {
            CreateAddressDto result = await Mediator.Send(createAddressCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAddressCommand deleteAddressCommand)
        {
            DeleteAddressDto result = await Mediator.Send(deleteAddressCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            UpdateAddressDto result = await Mediator.Send(updateAddressCommand);
            return Ok(result);
        }

    }
}
