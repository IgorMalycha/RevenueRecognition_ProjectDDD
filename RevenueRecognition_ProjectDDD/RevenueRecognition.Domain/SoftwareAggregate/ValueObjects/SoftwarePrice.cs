using RevenueRecognition.Domain.Exeptions.SofwareExceptions;

namespace RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

public record SoftwarePrice
{
    public decimal Value { get; }

    public SoftwarePrice(decimal value)
    {
        if (value <= 0)
        {
            throw new WrongSoftwarePriceException();
        }
        
        Value = value;
    }
    
    public static implicit operator decimal(SoftwarePrice softwarePrice)
        => softwarePrice.Value;
        
    public static implicit operator SoftwarePrice(decimal softwarePrice)
        => new(softwarePrice);
}