using HBCase.ActionFilters;
using HBCase.Model.Commands.Category;
using HBCase.Model.Entities;
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
    public class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseResult), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        [ValidationFilter]
        public async Task<ActionResult<BaseResponseResult>> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(BaseResponseResult<CategoryResult>), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        [ProducesResponseType(typeof(BaseResponseResult), 404)]
        public async Task<ActionResult<BaseResponseResult<CategoryResult>>> GetCategory(string id)
        {
            var response = await _mediator.Send(new GetCategoryQuery(id));

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            if(response.Result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponseResult), 200)]
        [ProducesResponseType(typeof(BaseResponseResult), 400)]
        public async Task<ActionResult<BaseResponseResult>> UpdateCategory(UpdateCategoryCommand command)
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
        public async Task<ActionResult<BaseResponseResult>> DeleteCategory(string id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand(id));

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}