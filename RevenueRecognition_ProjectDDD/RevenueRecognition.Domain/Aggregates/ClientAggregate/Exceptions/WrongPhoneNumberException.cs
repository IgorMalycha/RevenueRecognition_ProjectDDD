using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class WrongPhoneNumberException : RevenueRecognitionException
{
    public WrongPhoneNumberException() : base("Wrong format of phone number.")
    {
    }
}