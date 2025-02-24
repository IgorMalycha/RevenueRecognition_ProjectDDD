using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

namespace RevenueRecognition.Domain.Entities.Factories;

public interface IDiscountFactorie
{
    Discount Create(DiscountId discountId, DiscountName name, DiscountValue value, DateTime startDate, DateTime endDate);
}