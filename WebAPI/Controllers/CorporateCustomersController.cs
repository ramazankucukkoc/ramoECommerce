using Application.Features.CorporateCustomers.Command.CreateCorporateCustomer;
using Application.Features.CorporateCustomers.Command.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Command.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CorporateCustomersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
        {
            CreateCorporateCustomerDto result = await Mediator.Send(createCorporateCustomerCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
        {
            DeleteCorporateCustomerDto result = await Mediator.Send(deleteCorporateCustomerCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
        {
            UpdateCorporateDto result = await Mediator.Send(updateCorporateCustomerCommand);
            return Ok(result);
        }

    }
}
