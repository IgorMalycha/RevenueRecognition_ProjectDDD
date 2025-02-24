using RevenueRecognition.Domain.Exeptions.ClientException;

namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record ClientPhoneNumber
{
    public string Value { get; }

    public ClientPhoneNumber(string value)
    {
        
        if (value.Length != 9)
        {
            throw new WrongPhoneNumberException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(ClientPhoneNumber clientPhoneNumber)
        => clientPhoneNumber.Value;
        
    public static implicit operator ClientPhoneNumber(string clientPhoneNumber)
        => new(clientPhoneNumber);
}