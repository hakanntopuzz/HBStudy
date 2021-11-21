using HBCase.ActionFilters;
using HBCase.Model.Commands.Product;
using HBCase.Model.Queries;
using HBCase.Model.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HBCase.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("List")]
        [ProducesResponseType(typeof(BaseResponseResult<ProductResult>), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        [ProducesResponseType(typeof(BaseResponseResult), 404)]
        public async Task<ActionResult<BaseResponseResult<ProductResult>>> GetProducts(string name, string categoryId)
        {
            var response = await _mediator.Send(new GetProductsQuery(name, categoryId));

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            if (response.Result.Count == 0)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseResult), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        [ValidationFilter]
        public async Task<ActionResult<BaseResponseResult>> CreateProduct(CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(BaseResponseResult<ProductResult>), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        [ProducesResponseType(typeof(BaseResponseResult), 404)]
        public async Task<ActionResult<BaseResponseResult<ProductResult>>> GetProduct(string id)
        {
            var response = await _mediator.Send(new GetProductQuery(id));

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            if (response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponseResult), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        public async Task<ActionResult<BaseResponseResult>> UpdateProduct(UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseResponseResult), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        public async Task<ActionResult<BaseResponseResult>> DeleteProduct(string id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
