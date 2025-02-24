using RevenueRecognition.Domain.Exeptions.AgreementExceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public record AgreementPrice
{
    public decimal Value { get; }

    public AgreementPrice(decimal value)
    {
        if (value <= 0)
        {
            throw new WrongAgreementPaymentException();
        }
        
        Value = value;
    }
    
    public static implicit operator decimal(AgreementPrice agreementPrice)
        => agreementPrice.Value;
        
    public static implicit operator AgreementPrice(decimal agreementPayment)
        => new(agreementPayment);
}