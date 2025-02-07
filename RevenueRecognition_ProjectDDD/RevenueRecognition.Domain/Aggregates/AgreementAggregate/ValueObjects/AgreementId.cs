using RevenueRecognition.Domain.Exeptions.AgreementExceptions;

namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public record AgreementId
{
    public Guid Value { get; }

    public AgreementId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyAgreementIdException();
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(AgreementId agreementId)
        => agreementId.Value;
        
    public static implicit operator AgreementId(Guid agreementId)
        => new(agreementId);
    
}