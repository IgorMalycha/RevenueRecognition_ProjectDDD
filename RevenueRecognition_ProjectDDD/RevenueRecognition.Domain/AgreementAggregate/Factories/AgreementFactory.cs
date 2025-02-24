using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Repositories;

public class AgreementFactory : IAgreementFactory
{
    public Agreement CreateWithPayment(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears,
        AgreementPrice agreemenentPrice, SoftwareId softwareId, ClientId clientId, AgreementId agreementId, DiscountId discountId, 
        Payment payment)
    {
        bool isSigned = false;
        if (payment._amount == agreemenentPrice.Value)
        {
            isSigned = true;
        }
        
        var newAgreement = new Agreement(agreementPeriod, actualizationYears,isSigned , agreemenentPrice, softwareId, clientId, agreementId, discountId);
        newAgreement.AddPayment(payment);
        return newAgreement;
    }

    public Agreement Create(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears,
        AgreementPrice agreemenentPrice, SoftwareId softwareId, ClientId clientId, AgreementId agreementId, DiscountId discountId)
    {
        return new Agreement(agreementPeriod, actualizationYears, isSigned:false, agreemenentPrice, softwareId, clientId, agreementId, discountId);
    }
}