using System.Text.RegularExpressions;
using RevenueRecognition.Domain.Exeptions.ClientException;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record ClientEmail
{
    public string Value { get; }

    public ClientEmail(string value)
    {
        
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        if (string.IsNullOrWhiteSpace(value) || Regex.IsMatch(value, pattern))
        {
            throw new WrongEmailException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(ClientEmail clientEmail)
        => clientEmail.Value;
        
    public static implicit operator ClientEmail(string clientEmail)
        => new(clientEmail);
}