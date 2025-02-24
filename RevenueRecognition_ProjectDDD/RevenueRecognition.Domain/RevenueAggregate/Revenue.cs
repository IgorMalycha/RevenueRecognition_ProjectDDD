using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate;

public class Revenue : AggreagateRoot<Revenue>
{
    public RevenueId RevenueId { get; private set; }
    private RevenueAmount _revenueAmount;
    private DateTime _recognizedDate;


    public Revenue(RevenueAmount revenueAmount, DateTime recognizedDate, RevenueId revenueId)
    {
        _revenueAmount = revenueAmount;
        _recognizedDate = recognizedDate;
        RevenueId = revenueId;
    }
}