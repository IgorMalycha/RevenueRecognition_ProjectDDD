using RevenueRecognition.Domain.Exeptions.ClientException;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record ClientId
{
    public Guid Value { get; }

    public ClientId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyClientIdException();
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(ClientId clientId)
        => clientId.Value;
        
    public static implicit operator ClientId(Guid clientId)
        => new(clientId);
}