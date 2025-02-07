using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwareDescription
{
    public string Value { get; }

    public SoftwareDescription(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new EmptySofwareDescriptionException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(SoftwareDescription description)
        => description.Value;
    public static implicit operator SoftwareDescription(string description)
        => new(description);
}