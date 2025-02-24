using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.ClientExceptions;

public class ClientWithEmailAlreadyExist : RevenueRecognitionException
{
    public ClientWithEmailAlreadyExist(string email) : base($"Client with email: '{email}' already exist.")
    {
    }
}