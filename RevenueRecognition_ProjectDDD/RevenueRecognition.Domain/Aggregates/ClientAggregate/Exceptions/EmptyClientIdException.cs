using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class EmptyClientIdException : RevenueRecognitionException
{
    public EmptyClientIdException() : base("Clients Id can not be empty.")
    {
    }
}