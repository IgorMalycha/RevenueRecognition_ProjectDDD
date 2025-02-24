using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class EmptySofwareDescriptionException : RevenueRecognitionException
{
    public EmptySofwareDescriptionException() : base("Software description can not be empty.")
    {
    }
}