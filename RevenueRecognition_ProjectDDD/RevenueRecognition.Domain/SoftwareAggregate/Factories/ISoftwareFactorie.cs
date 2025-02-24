using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Factories;

public interface ISoftwareFactorie
{
    Software Create(SoftwareName name, SoftwareDescription description, SoftwareVersion version,
        SoftwareCategory category, SoftwarePrice softwarePrice, SoftwareId softwareId);
}