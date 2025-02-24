using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Application.Commands.AgreementCommands;
using RevenueRecognition.Shared.Abstractions.Commands;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Api.Controllers;

public class AgreementsController : BaseCotroller
{

    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public AgreementsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> AddAgreement(CreateAgreement command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Created();
    }
    
    [HttpPost("agreement/{agreementId:guid}/payments")]
    public async Task<IActionResult> AddPayment(Guid agreementId,[FromBody] AddPayment command)
    {
        command = command with { agreementId = agreementId };
        await _commandDispatcher.DispatchAsync(command);
        return Created();
    }
    
}