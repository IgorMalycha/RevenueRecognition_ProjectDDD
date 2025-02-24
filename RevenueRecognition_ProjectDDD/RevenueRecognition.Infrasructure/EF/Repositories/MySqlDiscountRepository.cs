using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Application.Repositories;

internal sealed class MySqlDiscountRepository : IDiscountRepository
{
    private readonly DbSet<Discount> _discounts;
    private readonly WriteDbContext _writeDbContext;

    public MySqlDiscountRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _discounts = context.Discounts;
    }
    public Task<Discount> GetAsync(DiscountId id)
    {
        return _discounts.SingleOrDefaultAsync(e => e.DiscountId == id);
    }

    public async Task AddAsync(Discount discount)
    {
        await _discounts.AddAsync(discount);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Discount discount)
    {
        _discounts.Update(discount);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Discount discount)
    {
        _discounts.Remove(discount);
        await _writeDbContext.SaveChangesAsync();    
    }
}