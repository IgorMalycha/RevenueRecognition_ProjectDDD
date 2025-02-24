using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Factories;

public class SoftwareFactorie : ISoftwareFactorie
{
    public Software Create(SoftwareName name, SoftwareDescription description, SoftwareVersion version, SoftwareCategory category,
        SoftwarePrice softwarePrice, SoftwareId softwareId)
    {
        return new Software(name, description, version, category, softwarePrice, softwareId);
    }
}