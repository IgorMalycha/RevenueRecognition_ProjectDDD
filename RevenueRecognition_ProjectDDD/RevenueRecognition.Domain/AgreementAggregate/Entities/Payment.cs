using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.ValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public class Payment : AggreagateRoot<PaymentId>
{
    public PaymentId PaymentId { get; private set; }
    public Money _amount;
    public DateTime _paymentDate;

    public Payment(PaymentId paymentId, Money amount, DateTime paymentDate)
    {
        PaymentId = paymentId;
        _amount = amount;
        _paymentDate = paymentDate;
    }
    
}