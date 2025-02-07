using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.Exceptions;

public class WrongMoneyException : RevenueRecognitionException
{
    public WrongMoneyException() : base("Money can not be empty and less or equal 0.")
    {
    }
}