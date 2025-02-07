using RevenueRecognition.Domain.Exeptions.ClientException;

namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record ClientName
{
    public string Value { get; }

    public ClientName(string value)
    {
        
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyClientNameException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(ClientName clientName)
        => clientName.Value;
        
    public static implicit operator ClientName(string clientName)
        => new(clientName);
}