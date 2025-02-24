using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.ClientExceptions;

public class ClientWithPhoneNumberAlreadyExist : RevenueRecognitionException
{
    public ClientWithPhoneNumberAlreadyExist(string phoneNumber) : base($"Client with phone number: '{phoneNumber}' already exist.")
    {
    }
}