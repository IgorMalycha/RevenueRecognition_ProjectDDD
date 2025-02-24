using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;

namespace RevenueRecognition.Domain.Entities.Repositories;

public interface IDiscountRepository
{
    Task<Discount> GetAsync(DiscountId id);
    Task AddAsync(Discount discount);
    Task UpdateAsync(Discount discount);
    Task DeleteAsync(Discount discount);
}