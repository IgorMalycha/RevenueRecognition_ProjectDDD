using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Factories;

public interface IRevenueFactory
{
    Revenue Create(decimal revenueAmount, DateTime recognizedDate, Guid revenueId);
}