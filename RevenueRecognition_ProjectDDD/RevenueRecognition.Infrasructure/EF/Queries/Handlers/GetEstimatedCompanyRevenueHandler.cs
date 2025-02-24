using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Application.Models;
using RevenueRecognition.Application.Queries;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Application.Handlers;

internal sealed class GetEstimatedCompanyRevenueHandler : IQueryHandler<GetEstimatedCompanyRevenue, EstimatedCompanyRevenueDto>
{
    private readonly DbSet<AgreementReadModel> _agreement;

    public GetEstimatedCompanyRevenueHandler(ReadDbContext context)
    {
        _agreement = context.Agreements;
    }
    public async Task<EstimatedCompanyRevenueDto> HandleAsync(GetEstimatedCompanyRevenue query)
    {
        var estimatedRevenue = await _agreement.SumAsync(e => e.Price);

        return new EstimatedCompanyRevenueDto()
        {
            RevenueAmount = estimatedRevenue
        };
    }
}