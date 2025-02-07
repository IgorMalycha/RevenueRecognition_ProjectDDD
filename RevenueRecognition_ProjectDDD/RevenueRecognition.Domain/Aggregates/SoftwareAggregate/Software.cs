using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public class Software : AggreagateRoot<SoftwareId>
{
    public SoftwareId SoftwareId { get; private set;  }
    public SoftwareName _name;
    public SoftwareDescription _description;
    public SoftwareVersion _version;
    public SoftwareCategory _category;
    public SoftwarePrice _softwarePrice;

    public Software(SoftwareName name, SoftwareDescription description, SoftwareVersion version, SoftwareCategory category, SoftwarePrice softwarePrice, SoftwareId softwareId)
    {
        _name = name;
        _description = description;
        _version = version;
        _category = category;
        _softwarePrice = softwarePrice;
        SoftwareId = softwareId;
    }
}