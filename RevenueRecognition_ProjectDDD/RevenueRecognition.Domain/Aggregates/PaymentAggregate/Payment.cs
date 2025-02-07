using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.ValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public class Payment : AggreagateRoot<PaymentId>
{
    public PaymentId PaymentId { get; private set; }
    public Agreement Agreement;
    public Money Amount;
    public DateTime PaymentDate;

    public Payment(PaymentId paymentId, Agreement agreement, Money amount, DateTime paymentDate)
    {
        PaymentId = paymentId;
        Agreement = agreement;
        Amount = amount;
        PaymentDate = paymentDate;
    }
    
}