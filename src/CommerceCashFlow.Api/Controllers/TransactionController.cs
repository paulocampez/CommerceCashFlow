using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Application.Models;

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
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var transactionId = await _mediator.Send(command);
            return transactionId;
        }
        [HttpGet]
        public async Task<ActionResult<List<TransactionsViewModel>>> GetTransactions(Guid merchandId)
        {
            var query = new GetTransactionsQuery(merchandId);
            var transactionList = await _mediator.Send(query);
            return transactionList;
        }
    }
}
