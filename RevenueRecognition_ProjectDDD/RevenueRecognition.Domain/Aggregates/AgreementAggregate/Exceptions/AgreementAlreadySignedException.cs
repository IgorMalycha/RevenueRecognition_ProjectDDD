using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

public class AgreementAlreadySignedException : RevenueRecognitionException
{
    public AgreementAlreadySignedException(string id) : 
        base("Agreement with Id: "+id+"is already signed.")
    {
    }
}