namespace RevenueRecognition.Shared.Abstractions.Exceptions;

public abstract class RevenueRecognitionException : Exception
{
    protected RevenueRecognitionException(string message) : base(message)
    {
        
    }
}
