using RevenueRecognition.Domain.Exeptions.ClientException;

namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record ClientPesel
{
    public string Value { get; }

    public ClientPesel(string value)
    {

        if (value.Length != 11)
        {
            throw new WrongPeselLengthException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(ClientPesel clientPesel)
        => clientPesel.Value;
        
    public static implicit operator ClientPesel(string clientPesel)
        => new(clientPesel);
}