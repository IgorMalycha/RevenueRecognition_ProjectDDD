using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

namespace RevenueRecognition.Domain.Entities.Factories;

public class DiscountFactorie : IDiscountFactorie
{
    public Discount Create(DiscountId discountId, DiscountName name, DiscountValue value, DateTime startDate, DateTime endDate)
    {
        return new Discount(discountId, name, value, startDate, endDate);
    }
}