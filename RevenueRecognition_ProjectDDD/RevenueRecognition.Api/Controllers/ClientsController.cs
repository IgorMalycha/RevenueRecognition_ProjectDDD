using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Application.Commands.ClientCommands;
using RevenueRecognition.Shared.Abstractions.Commands;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Api.Controllers;


public class ClientsController : BaseCotroller
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public ClientsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }
    
    
    [HttpPost("companyClient")]
    public async Task<IActionResult> AddCompanyClient(AddCompanyClient command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Created();
    }
    
    [HttpPost("individualClient")]
    public async Task<IActionResult> AddIndividualClient(AddIndividualClient command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Created();
    }
    
    [HttpDelete("companyClient/{individualClientId:guid}")]
    public async Task<IActionResult> RemoveIndividualClient([FromRoute] RemoveIndividualClient command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Created();
    }
}