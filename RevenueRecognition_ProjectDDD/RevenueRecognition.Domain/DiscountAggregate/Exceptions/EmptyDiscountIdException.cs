using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.DiscountExceptions;

public class EmptyDiscountIdException : RevenueRecognitionException
{
    public EmptyDiscountIdException() : base("Discount Id can not be empty.")
    {
    }
}