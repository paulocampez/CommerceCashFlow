using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Queries;

namespace CommerceCashFlow.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTransaction(CreateTransactionCommand command)
        {
            var transactionId = await _mediator.Send(command);
            return transactionId;
        }
    }
}
