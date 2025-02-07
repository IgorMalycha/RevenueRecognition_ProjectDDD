using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.Exceptions;

public class EmptyPaymentIdException : RevenueRecognitionException
{
    public EmptyPaymentIdException() : base("Payment Id can not be empty.")
    {
    }
}