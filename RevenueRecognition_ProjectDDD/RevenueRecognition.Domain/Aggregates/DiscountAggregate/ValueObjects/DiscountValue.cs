using RevenueRecognition.Domain.Exeptions.DiscountExceptions;

namespace RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

public record DiscountValue
{
    public int Value { get; }

    public DiscountValue(int value)
    {
        if (value.Equals(null) || value <= 0)
        {
            throw new WrongDiscountException();
        }
        
        Value = value;
    }
    
    public static implicit operator int(DiscountValue discountValue)
        => discountValue.Value;
        
    public static implicit operator DiscountValue(int discountValue)
        => new(discountValue);
}
