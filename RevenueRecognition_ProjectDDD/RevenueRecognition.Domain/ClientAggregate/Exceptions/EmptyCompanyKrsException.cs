using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Domain.Exeptions.ClientException;

public class EmptyCompanyKrsException : RevenueRecognitionException
{
    public EmptyCompanyKrsException() : base("Company Krs number can not be empty.")
    {
    }
}