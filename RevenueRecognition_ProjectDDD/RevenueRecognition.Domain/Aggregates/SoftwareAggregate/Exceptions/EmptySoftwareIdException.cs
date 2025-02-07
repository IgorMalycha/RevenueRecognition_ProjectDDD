using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class EmptySoftwareIdException : RevenueRecognitionException
{
    public EmptySoftwareIdException() : base("Software Id can not be empty.")
    {
    }
}