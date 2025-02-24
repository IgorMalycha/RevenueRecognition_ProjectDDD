using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Application.Commands.AgreementCommands;
using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Application.Queries;
using RevenueRecognition.Shared.Abstractions.Commands;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Api.Controllers;

public class RevenuesController : BaseCotroller
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public RevenuesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpGet]
    public async Task<ActionResult<CompanyRevenueDto>> GetCompanyRevenue(GetCompanyRevenue query)
    {
        var result = await _queryDispatcher.DispatchAsync(query);
        return OkOrNotFound(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<EstimatedCompanyRevenueDto>> GetEstimatedCompanyRevenue(GetEstimatedCompanyRevenue query)
    {
        var result = await _queryDispatcher.DispatchAsync(query);
        return OkOrNotFound(result);
    }
    
    [HttpGet("product/{productId:guid}")]
    public async Task<ActionResult<ProductRevenueDto>> GetProductRevenue([FromRoute] GetProductRevenue query)
    {
        var result = await _queryDispatcher.DispatchAsync(query);
        return OkOrNotFound(result);
    }
}