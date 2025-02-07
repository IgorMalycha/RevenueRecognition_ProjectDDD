using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public class Discount : AggreagateRoot<DiscountId>
{
    public DiscountId DiscountId { get; private set; }
    public DiscountName _name;
    //public DiscountOffer _offer;
    public DiscountValue _value;
    public DateTime _startDate;
    public DateTime _endDate;
    public bool _isActive;

    public Discount(DiscountId discountId, DiscountName name, DiscountValue value, DateTime startDate, DateTime endDate)
    {
        DiscountId = discountId;
        _name = name;
        _value = value;
        _startDate = startDate;
        _endDate = endDate;

        _isActive = _startDate < DateTime.Now && _endDate > DateTime.Now;
    }
}