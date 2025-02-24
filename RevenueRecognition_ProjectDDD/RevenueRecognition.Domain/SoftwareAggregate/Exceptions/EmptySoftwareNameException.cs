using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class EmptySoftwareNameException : RevenueRecognitionException
{
    public EmptySoftwareNameException() : base("Software name can not be empty.")
    {
    }
}