using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public class Software : AggreagateRoot<SoftwareId>
{
    public SoftwareId SoftwareId { get; private set;  }
    private SoftwareName _name;
    private SoftwareDescription _description;
    private SoftwareVersion _version;
    private SoftwareCategory _category;
    private SoftwarePrice _softwarePrice;

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