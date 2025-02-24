using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwareVersion
{
    public string Value { get; }

    public SoftwareVersion(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new EmptySoftwareVersionException();
        }
        // if (Regex.IsMatch(value, @".\..\.."))
        //     throw new InvalidAttributeException(nameof(SoftwareVersion), "in the format of 'x.x.x'");
        
        Value = value;
    }
    
    public static implicit operator string(SoftwareVersion version)
        => version.Value;
    public static implicit operator SoftwareVersion(string version)
        => new(version);
}