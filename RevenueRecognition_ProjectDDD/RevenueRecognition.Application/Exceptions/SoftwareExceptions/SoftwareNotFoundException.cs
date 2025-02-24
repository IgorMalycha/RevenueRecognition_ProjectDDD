using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.AgreementExceptions;

public class SoftwareNotFoundException : RevenueRecognitionException
{
    public Guid Id { get; }
    public SoftwareNotFoundException(Guid id) : base($"Software with Id: '{id}' was not found")
        => Id = id;
}