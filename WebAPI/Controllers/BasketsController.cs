using Application.Features.Baskets.Command.CreateBasket;
using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Queries.GetByBrandIdBasket;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommand createBasketCommand)
        {
            CreateBasketDto result = await Mediator.Send(createBasketCommand);
            return Ok(result);
        }


        [HttpGet]
        [Route("{BrandId}")]
        public async Task<IActionResult> GetByBrandIdBasket([FromRoute] GetByBrandIdBasketQuery getByBrandIdBasketQuery)
        {
            GetListResponse<GetByBrandIdBasketDto> result = await Mediator.Send(getByBrandIdBasketQuery);
            return Ok(result);
        }

    }
}
