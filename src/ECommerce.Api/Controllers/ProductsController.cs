using ECommerce.Application.Queries;
using Kanbersky.Common.Results.ApiResponses.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : KanberskyControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Products Info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _mediator.Send(new GetProductsQuery());
            return ApiOk(response);
        }
    }
}
