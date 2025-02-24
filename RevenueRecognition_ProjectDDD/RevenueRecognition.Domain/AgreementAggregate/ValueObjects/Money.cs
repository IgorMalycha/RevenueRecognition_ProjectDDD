using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.Exceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.ValueObjects;

public class Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value <= 0)
        {
            throw new WrongMoneyException();
        }
        
        Value = value;
    }
    
    public static implicit operator decimal(Money money)
        => money.Value;
        
    public static implicit operator Money(decimal money)
        => new(money);
}