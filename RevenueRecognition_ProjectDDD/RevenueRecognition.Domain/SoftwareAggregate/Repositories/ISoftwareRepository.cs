using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Repositories;

public interface ISoftwareRepository
{
    Task<Software> GetAsync(SoftwareId id);
    Task AddAsync(Software software);
    Task UpdateAsync(Software software);
    Task DeleteAsync(Software software);
}