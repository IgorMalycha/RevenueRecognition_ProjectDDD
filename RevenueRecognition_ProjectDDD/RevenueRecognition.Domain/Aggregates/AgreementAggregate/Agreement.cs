using RevenueRecognition.Domain.Exeptions.AgreementExceptions;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public class Agreement : AggreagateRoot<AgreementId>
{
    public AgreementId AgreementId { get; private set; }
    private AgreementPeriod _agreementPeriod;
    private AgreementActualizationYears _actualizationYears;
    private bool _isSigned;
    private bool _isPaid;
    private AgreementPrice _agreemenentPrice;
    private readonly List<Payment> _payments = new();

    private Software _software;
    private CompanyClient? CompanyClient;
    private IndividualClient? IndividualClient;


    public Agreement(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears, bool isSigned, bool isPaid, AgreementPrice agreemenentPrice, Software software, CompanyClient? companyClient, IndividualClient? individualClient, AgreementId agreementId)
    {
        _agreementPeriod = agreementPeriod;
        _actualizationYears = actualizationYears;
        _isSigned = isSigned;
        _isPaid = isPaid;
        _agreemenentPrice = agreemenentPrice;
        _software = software;
        CompanyClient = companyClient;
        IndividualClient = individualClient;
        AgreementId = agreementId;
    }

    public void AddPayment(Payment payment)
    {
        if (_isPaid)
        {
            throw new AgreementAlreadyPaidException(AgreementId.Value.ToString());
        }

        if (payment.PaymentDate < _agreementPeriod.BeginDate || payment.PaymentDate > _agreementPeriod.EndDate)
        {
            throw new PaymentDateOutOfAgreementPeriod();
        }
        
        _payments.Add(payment);
        if (_payments.Sum(p => p.Amount) >= _agreemenentPrice.Value)
        {
            _isPaid = true;
        }
    }

    public void SignAgreement()
    {
        if (_isSigned)
        {
            throw new AgreementAlreadySignedException(AgreementId.Value.ToString());
        }
        _isSigned = true;
    }
    
    
}
