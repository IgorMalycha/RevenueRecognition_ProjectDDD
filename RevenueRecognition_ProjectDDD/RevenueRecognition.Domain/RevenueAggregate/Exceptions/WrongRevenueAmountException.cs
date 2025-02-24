using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Exceptions;

public class WrongRevenueAmountException : RevenueRecognitionException
{
    public WrongRevenueAmountException() : base("Revenue amount can not be empty and less or equal 0.")
    {
    }
}