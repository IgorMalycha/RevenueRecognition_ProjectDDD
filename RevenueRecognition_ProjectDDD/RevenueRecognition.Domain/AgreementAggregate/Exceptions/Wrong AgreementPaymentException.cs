using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

public class WrongAgreementPaymentException : RevenueRecognitionException
{
    public WrongAgreementPaymentException() : base("Payment can not be empty and less or equal 0.")
    {
    }
}