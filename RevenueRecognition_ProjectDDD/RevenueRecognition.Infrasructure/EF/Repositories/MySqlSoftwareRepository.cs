using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Application.Repositories;

internal sealed class MySqlSoftwareRepository : ISoftwareRepository
{
    private readonly DbSet<Software> _softwares;
    private readonly WriteDbContext _writeDbContext;

    public MySqlSoftwareRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _softwares = context.Softwares;
    }

    public Task<Software> GetAsync(SoftwareId id)
    {
        return _softwares.SingleOrDefaultAsync(e => e.SoftwareId == id);
    }

    public async Task AddAsync(Software software)
    {
        await _softwares.AddAsync(software);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Software software)
    {
        _softwares.Update(software);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Software software)
    {
        _softwares.Remove(software);
        await _writeDbContext.SaveChangesAsync();
    }
}