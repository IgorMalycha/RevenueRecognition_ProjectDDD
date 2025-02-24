using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Repositories;

public interface IRevenueRepository
{
    Task<Revenue> GetAsync(RevenueId id);
    Task AddAsync(Revenue agreement);
    Task UpdateAsync(Revenue agreement);
    Task DeleteAsync(Revenue agreement);
}