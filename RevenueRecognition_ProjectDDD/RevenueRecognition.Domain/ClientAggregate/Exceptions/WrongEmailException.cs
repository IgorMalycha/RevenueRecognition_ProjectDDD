using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class WrongEmailException : RevenueRecognitionException
{
    public WrongEmailException() : base("Wrong format of email.")
    {
    }
}