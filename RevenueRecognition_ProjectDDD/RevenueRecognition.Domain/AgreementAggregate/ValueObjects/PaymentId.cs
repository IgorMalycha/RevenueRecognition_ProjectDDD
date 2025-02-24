using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.Exceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.ValueObjects;

public class PaymentId
{
    public Guid Value { get; }

    public PaymentId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyPaymentIdException();
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(PaymentId paymentId)
        => paymentId.Value;
        
    public static implicit operator PaymentId(Guid paymentId)
        => new(paymentId);
}