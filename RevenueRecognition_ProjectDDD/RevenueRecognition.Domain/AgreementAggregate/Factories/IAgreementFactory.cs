using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Repositories;

public interface IAgreementFactory
{
    Agreement Create(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears, AgreementPrice agreemenentPrice, SoftwareId softwareId, ClientId clientId, AgreementId agreementId, DiscountId discountId);
    
    Agreement CreateWithPayment(AgreementPeriod agreementPeriod, AgreementActualizationYears actualizationYears, AgreementPrice agreemenentPrice, SoftwareId softwareId, ClientId clientId, AgreementId agreementId, DiscountId discountId, Payment payment);
}