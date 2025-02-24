using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Aggregates.RevenueAggregate.Exceptions;

public class EmptyRevenueIdException : RevenueRecognitionException
{
    public EmptyRevenueIdException() : base("Revenue Id can not be empty.")
    {
    }
}