using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.DiscountExceptions;

public class WrongDiscountException : RevenueRecognitionException
{
    public WrongDiscountException() : base("Discount can not be empty and less or equal 0.")
    {
    }
}