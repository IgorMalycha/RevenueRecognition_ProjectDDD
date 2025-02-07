using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class WrongPeselLengthException : RevenueRecognitionException
{
    public WrongPeselLengthException() : base("Pesel must consist 11 numbers.")
    {
    }
}