using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

namespace RevenueRecognition.Domain.Entities.Repositories;

public interface IAgreementRepository
{
    Task<Agreement> GetAsync(AgreementId id);
    Task AddAsync(Agreement agreement);
    Task UpdateAsync(Agreement agreement);
    Task DeleteAsync(Agreement agreement);
}