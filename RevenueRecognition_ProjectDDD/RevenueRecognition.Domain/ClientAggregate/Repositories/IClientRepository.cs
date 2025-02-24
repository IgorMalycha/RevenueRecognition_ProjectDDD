using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Repositories;

public interface IClientRepository
{
    Task<Client> GetAsync(ClientId clientIdd);
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(Client client);
}