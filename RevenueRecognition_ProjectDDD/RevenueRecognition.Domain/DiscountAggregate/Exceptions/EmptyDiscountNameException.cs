using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.DiscountExceptions;

public class EmptyDiscountNameException : RevenueRecognitionException
{
    public EmptyDiscountNameException() : base("Discount name can not be empty.")
    {
    }
}