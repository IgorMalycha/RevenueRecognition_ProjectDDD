using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.ClientExceptions;

public class ClientWithPeselAlreadyExist : RevenueRecognitionException
{
    public ClientWithPeselAlreadyExist(string pesel) : base($"Client with pesel: '{pesel}' already exist.")
    {
    }
}