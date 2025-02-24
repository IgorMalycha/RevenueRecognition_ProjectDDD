using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

public class EmptyAgreementActualizationYearsException : RevenueRecognitionException
{
    public EmptyAgreementActualizationYearsException() : base("Actualization years can not be empty.")
    {
    }
}