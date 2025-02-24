using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Application.Repositories;

internal sealed class MySqlClientRepository : IClientRepository
{
    private readonly DbSet<Client> _clients;
    private readonly WriteDbContext _writeDbContext;

    public MySqlClientRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _clients = context.Clients;
    }
    public Task<Client> GetAsync(ClientId id)
    {
        return _clients.SingleOrDefaultAsync(e => e.ClientId == id);
    }

    public async Task AddAsync(Client client)
    {
        await _clients.AddAsync(client);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _clients.Update(client);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Client client)
    {
        _clients.Remove(client);
        await _writeDbContext.SaveChangesAsync();    
    }
}