using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Application.Models;
using RevenueRecognition.Application.Queries;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Application.Handlers;

internal sealed class GetCompanyRevenueHandler : IQueryHandler<GetCompanyRevenue, CompanyRevenueDto>
{
    private readonly DbSet<RevenueReadModel> _revenue;

    public GetCompanyRevenueHandler(ReadDbContext context)
    {
        _revenue = context.Revenues;
    }

    public async Task<CompanyRevenueDto> HandleAsync(GetCompanyRevenue query)
    {
        var totalRevenueAmount = await _revenue.Where(e => 
                e.RecognizedDate >= query.StartDate && e.RecognizedDate <= query.EndDate)
            .SumAsync(r => r.RevenueAmount);
        
        return new CompanyRevenueDto()
        {
            RevenueAmount = totalRevenueAmount,
        };
        
    }
}