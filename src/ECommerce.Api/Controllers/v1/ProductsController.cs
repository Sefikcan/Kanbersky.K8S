using ECommerce.Application.DTO.Response;
using ECommerce.Application.Queries;
using Kanbersky.Common.Results.ApiResponses.Concrete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsController : KanberskyControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mediator"></param>
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Products Info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(List<ProductResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _mediator.Send(new GetProductsQuery());
            return ApiOk(response);
        }
    }
}
