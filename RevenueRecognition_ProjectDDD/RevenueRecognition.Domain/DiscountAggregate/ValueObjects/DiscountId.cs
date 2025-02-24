using RevenueRecognition.Domain.Exeptions.DiscountExceptions;

namespace RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

public record DiscountId
{
    public Guid Value { get; }

    public DiscountId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyDiscountIdException();
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(DiscountId discountId)
        => discountId.Value;
        
    public static implicit operator DiscountId(Guid discountId)
        => new(discountId);
}