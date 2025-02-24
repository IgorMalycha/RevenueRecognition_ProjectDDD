using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Exceptions;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;

public record RevenueId
{
    public Guid Value { get; }

    public RevenueId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyRevenueIdException();
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(RevenueId revenueId)
        => revenueId.Value;
        
    public static implicit operator RevenueId(Guid revenueId)
        => new(revenueId);
}