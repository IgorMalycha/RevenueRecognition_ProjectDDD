using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.AgreementExceptions;

public class AgreementNotFoundException : RevenueRecognitionException
{
    public Guid Id { get; }
    public AgreementNotFoundException(Guid id) : base($"Agreement with Id: '{id}' was not found")
        => Id = id;
}