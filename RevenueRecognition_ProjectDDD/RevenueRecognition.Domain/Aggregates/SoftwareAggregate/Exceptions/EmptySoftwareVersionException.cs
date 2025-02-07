using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class EmptySoftwareVersionException : RevenueRecognitionException
{
    public EmptySoftwareVersionException() : base("Software Version can not be empty.")
    {
    }
}