using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Repositories;


namespace RevenueRecognition.Application.Repositories;

internal sealed class MySqlRevenueRepository : IRevenueRepository
{
    private readonly DbSet<Revenue> _revenues;
    private readonly WriteDbContext _writeDbContext;

    public MySqlRevenueRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _revenues = context.Revenues;
    }

    public Task<Revenue> GetAsync(RevenueId id)
    {
        return _revenues.SingleOrDefaultAsync(e => e.RevenueId == id);
    }

    public async Task AddAsync(Revenue revenue)
    {
        await _revenues.AddAsync(revenue);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Revenue revenue)
    {
        _revenues.Update(revenue);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Revenue revenue)
    {
        _revenues.Remove(revenue);
        await _writeDbContext.SaveChangesAsync();
    }
}