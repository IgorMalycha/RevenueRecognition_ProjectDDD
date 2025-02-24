using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class EmptyClientNameException : RevenueRecognitionException
{
    public EmptyClientNameException() : base("Clients name can not be empty.")
    {
    }
}