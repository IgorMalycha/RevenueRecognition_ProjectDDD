namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

using RevenueRecognition.Shared.Abstractions.Exceptions;
public class EmptyAgreementIdException : RevenueRecognitionException
{
    public EmptyAgreementIdException() : base("Agreemenent Id can not be empty.")
    {
    }
}