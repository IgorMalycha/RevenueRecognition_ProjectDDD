using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.AgreementExceptions;

public class AgreementAlreadyPaidException : RevenueRecognitionException
{
    public AgreementAlreadyPaidException(string id) : 
        base("Agreement with Id: "+id+"is already paid.")
    {
    }
}