using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Factories;

public class ClientFactorie : IClientFactorie
{
    public CompanyClient Create(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber,
        ClientName companyName, CompanyKrs krs)
    {
        return new CompanyClient(clientId, email, address, phoneNumber, companyName, krs);
    }

    public IndividualClient Create(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, 
        ClientName firstName, ClientName lastName, ClientPesel pesel)
    {
        return new IndividualClient(clientId, email, address, phoneNumber, firstName, lastName, pesel);
    }
}