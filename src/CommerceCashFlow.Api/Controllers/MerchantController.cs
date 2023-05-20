using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Queries;

namespace CommerceCashFlow.Api.Controllers
{
    [ApiController]
    [Route("api/merchants")]
    public class MerchantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchant(int id)
        {
            var query = new GetMerchantQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] CreateMerchantCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMerchant), new { id = result.Id }, result);
        }
    }
}
