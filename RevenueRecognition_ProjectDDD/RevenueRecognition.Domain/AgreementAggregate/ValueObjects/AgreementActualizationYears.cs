using RevenueRecognition.Domain.Enums;
using RevenueRecognition.Domain.Exeptions.AgreementExceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public record AgreementActualizationYears
{
    public AgreementActualizationYearsOptions Value { get; }

    public AgreementActualizationYears(AgreementActualizationYearsOptions value)
    {
        if (value.Equals(null))
        {
            throw new EmptyAgreementActualizationYearsException();
        }
        
        Value = value;
    }
    
    // public static implicit operator int(AgreementActualizationYearsOptions agreementActualizationYears)
    //     => agreementActualizationYears.;
    //     
    // public static implicit operator AgreementActualizationYears(int agreementActualizationYears)
    //     => new(agreementActualizationYears);
}