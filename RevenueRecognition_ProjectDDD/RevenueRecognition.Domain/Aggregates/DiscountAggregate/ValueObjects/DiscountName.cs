using RevenueRecognition.Domain.Exeptions.DiscountExceptions;

namespace RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

public record DiscountName
{
    public string Value { get; }

    public DiscountName(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new EmptyDiscountNameException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(DiscountName name)
        => name.Value;
    public static implicit operator DiscountName(string name)
        => new(name);
}