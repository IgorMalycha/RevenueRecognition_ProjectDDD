using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Application.Models;
using RevenueRecognition.Application.Queries;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Application.Handlers;

internal sealed class GetProductRevenueHandler : IQueryHandler<GetProductRevenue, ProductRevenueDto>
{
    private readonly DbSet<RevenueReadModel> _revenue;
    private readonly DbSet<SoftwareReadModel> _software;

    public GetProductRevenueHandler(ReadDbContext context)
    {
        _revenue = context.Revenues;
        _software = context.Softwares;
    }
    public async Task<ProductRevenueDto> HandleAsync(GetProductRevenue query)
    {
        var totalRevenueForSoftware = await _revenue
            .Where(r => r.Payment.Agreement.Software.Id == query.Id)
            .SumAsync(r => r.RevenueAmount);

        var softwareName = await _software.Where(e => e.Id == query.Id).Select(e => e.Name).FirstOrDefaultAsync();
        var softwareCategory = await _software.Where(e => e.Id == query.Id).Select(e => e.Category).FirstOrDefaultAsync();
        
        
        return new ProductRevenueDto()
        {
            Category = softwareCategory,
            Name = softwareName,
            RevenueAmount = totalRevenueForSoftware
        };
    }
}