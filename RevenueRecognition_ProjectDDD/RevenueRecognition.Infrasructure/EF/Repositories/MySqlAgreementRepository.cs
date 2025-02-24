using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

namespace RevenueRecognition.Application.Repositories;

internal sealed class MySqlAgreementRepository : IAgreementRepository
{
    private readonly DbSet<Agreement> _agreements;
    private readonly WriteDbContext _writeDbContext;

    public MySqlAgreementRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _agreements = context.Agreements;
    }

    public Task<Agreement> GetAsync(AgreementId id)
    {
        return _agreements.Include("_payments").SingleOrDefaultAsync(e => e.AgreementId == id);
    }

    public async Task AddAsync(Agreement agreement)
    {
        await _agreements.AddAsync(agreement);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Agreement agreement)
    {
        _agreements.Update(agreement);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Agreement agreement)
    {
        _agreements.Remove(agreement);
        await _writeDbContext.SaveChangesAsync();
    }
}