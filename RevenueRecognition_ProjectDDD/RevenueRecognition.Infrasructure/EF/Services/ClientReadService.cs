using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Contexts;
using RevenueRecognition.Application.Models;
using RevenueRecognition.Application.Services.ClientServices;

namespace RevenueRecognition.Application.Services;

internal sealed class ClientReadService : IClientReadService
{
    private readonly DbSet<ClientReadModel> _client;

    public ClientReadService(ReadDbContext context)
    {
        _client = context.Clients;
    }
    public async Task<bool> ExistsByPeselAsync(string pesel)
    {
        return await _client.AnyAsync(e => e.IndividualClient.Pesel == pesel);
    }

    public async Task<bool> ExistsByPhoneAsync(string phoneNumber)
    {
        return await _client.AnyAsync(e => e.PhoneNumber == phoneNumber);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _client.AnyAsync(e => e.Email == email);
    }

    public async Task<bool> ExistsByKrsAsync(string krsNumber)
    {
        return await _client.AnyAsync(e => e.CompanyClient.KrsNumber == krsNumber);
    }
}