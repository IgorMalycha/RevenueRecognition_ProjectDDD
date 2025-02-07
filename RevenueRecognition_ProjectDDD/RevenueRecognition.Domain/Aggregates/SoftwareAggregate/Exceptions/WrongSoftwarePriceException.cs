using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class WrongSoftwarePriceException : RevenueRecognitionException
{
    public WrongSoftwarePriceException() : base("Software can not be empty and less or equals 0.")
    {
    }
}