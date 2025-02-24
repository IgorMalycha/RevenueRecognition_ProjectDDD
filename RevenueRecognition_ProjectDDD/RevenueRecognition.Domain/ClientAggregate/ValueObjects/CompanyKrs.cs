using RevenueRecognition.Domain.Exeptions.ClientException;

namespace RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

public record CompanyKrs
{
    public string Value { get; }
    
    public CompanyKrs(string value)
    {
        
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyCompanyKrsException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(CompanyKrs companyKrs)
        => companyKrs.Value;
        
    public static implicit operator CompanyKrs(string companyKrs)
        => new(companyKrs);
}