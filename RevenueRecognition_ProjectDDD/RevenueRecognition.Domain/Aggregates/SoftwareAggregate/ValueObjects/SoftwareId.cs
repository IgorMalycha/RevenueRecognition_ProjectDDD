using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwareId
{
    public Guid Value { get; }

    public SoftwareId(Guid value)
    {
        if (value == Guid.Empty)
        {
            //dać jako argument software Id do exception
            throw new EmptySoftwareIdException();
        }
        
        Value = value;
    }
    
    
    public static implicit operator Guid(SoftwareId softwareId)
        => softwareId.Value;
    public static implicit operator SoftwareId(Guid softwareId)
        => new(softwareId);
}