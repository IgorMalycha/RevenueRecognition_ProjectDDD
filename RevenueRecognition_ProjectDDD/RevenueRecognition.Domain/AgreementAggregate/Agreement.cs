using RevenueRecognition.Domain.Entities.Events;
using RevenueRecognition.Domain.Exeptions.AgreementExceptions;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public class Agreement : AggreagateRoot<AgreementId>
{
    public AgreementId AgreementId { get; private set; } //sprawdzić czy nie ma natularnego klucza zamiast zwykłego Id
    private AgreementPeriod _agreementPeriod;
    private AgreementActualizationYears _actualizationYears;
    private bool _isSigned;
    private AgreementPrice _agreemenentPrice;
    private readonly List<Payment> _payments = new();
    
    private SoftwareId _softwareId;
    private ClientId _clientId;
    private DiscountId _discountId;


    public Agreement(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears, bool isSigned, AgreementPrice agreemenentPrice, SoftwareId softwareId, ClientId clientId, AgreementId agreementId, DiscountId discountId)
    {
        _agreementPeriod = agreementPeriod;
        _actualizationYears = actualizationYears;
        _isSigned = isSigned;
        _agreemenentPrice = agreemenentPrice;
        _softwareId = softwareId;
        _clientId = clientId;
        AgreementId = agreementId;
        _discountId = discountId;
    }

    public void AddPayment(Payment payment)
    {
        if (_isSigned)
        {
            throw new AgreementAlreadyPaidException(AgreementId.Value.ToString());
        }

        if (payment._paymentDate < _agreementPeriod.BeginDate || payment._paymentDate > _agreementPeriod.EndDate)
        {
            throw new PaymentDateOutOfAgreementPeriod();
        }
        
        _payments.Add(payment);
        
        if (_payments.Sum(p => p._amount) >= _agreemenentPrice.Value)
        {
            _isSigned = true;
        }
        
        _payments.Add(payment);
        AddEvent(new AgreementPaymentAdded(this, payment));
    }
    
    
    
}
