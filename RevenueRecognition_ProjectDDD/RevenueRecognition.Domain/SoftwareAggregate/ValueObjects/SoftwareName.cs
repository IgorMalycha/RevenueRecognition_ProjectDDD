using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwareName
{
    public string Value { get; }

    public SoftwareName(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new EmptySoftwareNameException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(SoftwareName name)
        => name.Value;
    public static implicit operator SoftwareName(string name)
        => new(name);
}