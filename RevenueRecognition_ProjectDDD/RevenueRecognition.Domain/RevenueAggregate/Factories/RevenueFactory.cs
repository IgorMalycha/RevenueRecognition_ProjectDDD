namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Factories;

public class RevenueFactory : IRevenueFactory
{
    public Revenue Create(decimal revenueAmount, DateTime recognizedDate, Guid revenueId)
    {
        return new Revenue(revenueAmount, recognizedDate, revenueId);
    }
}