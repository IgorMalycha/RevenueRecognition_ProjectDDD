using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Exceptions;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;

public class RevenueAmount
{
    public decimal Value { get; }

    public RevenueAmount(decimal value)
    {
        if (value <= 0)
        {
            throw new WrongRevenueAmountException();
        }
        
        Value = value;
    }
    
    public static implicit operator decimal(RevenueAmount revenueAmount)
        => revenueAmount.Value;
        
    public static implicit operator RevenueAmount(decimal revenueAmount)
        => new(revenueAmount);
}