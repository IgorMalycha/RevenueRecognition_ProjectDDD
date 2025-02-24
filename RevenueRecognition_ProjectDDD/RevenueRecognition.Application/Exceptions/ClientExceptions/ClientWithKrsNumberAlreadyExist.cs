using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.ClientExceptions;

public class ClientWithKrsNumberAlreadyExist : RevenueRecognitionException
{
    public ClientWithKrsNumberAlreadyExist(string krsNumber) : base($"Client with krs number: '{krsNumber}' already exist.")
    {
    }
}