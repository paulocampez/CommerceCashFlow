using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommerceCashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
    {
            _mediator = mediator;
    }

    [HttpGet("{reportId}")]
    public async Task<ActionResult<Report>> GetReport(string reportId)
    {
        var query = new GetReportQuery(reportId);
        var report = await _mediator.Send(query);
        if (report == null)
        {
            return NotFound();
        }
        return Ok(report);
    }
    }
}
