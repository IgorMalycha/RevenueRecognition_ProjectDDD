using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

public class PaymentDateOutOfAgreementPeriod : RevenueRecognitionException
{
    public PaymentDateOutOfAgreementPeriod() : base("Payment can not be out of agreement period bounds.")
    {
    }
}