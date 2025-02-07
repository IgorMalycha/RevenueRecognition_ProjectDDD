using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.SofwareExceptions;

public class EmptySoftwareCategoryeException : RevenueRecognitionException
{
    public EmptySoftwareCategoryeException() : base("Software category can not be empty.")
    {
    }
}