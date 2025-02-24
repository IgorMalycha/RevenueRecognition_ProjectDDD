using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwareCategory
{
    public string Value { get; }

    public SoftwareCategory(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            throw new EmptySoftwareCategoryeException();
        }
        
        Value = value;
    }
    
    public static implicit operator string(SoftwareCategory category)
        => category.Value;
    public static implicit operator SoftwareCategory(string category)
        => new(category);
}