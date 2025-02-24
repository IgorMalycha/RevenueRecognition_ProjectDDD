using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities.Factories;

public interface IClientFactorie
{
    CompanyClient Create(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, 
        ClientName companyName, CompanyKrs krs);
    
    IndividualClient Create(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, 
        ClientName firstName, ClientName lastName, ClientPesel pesel);
}