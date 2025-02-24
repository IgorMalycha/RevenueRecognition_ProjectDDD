using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities;

public class CompanyClient : Client
{
    private ClientName _companyName;
    private CompanyKrs _krs;

    public CompanyClient(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, ClientName companyName, CompanyKrs krs) : base(clientId, email, address, phoneNumber)
    {
        _companyName = companyName;
        _krs = krs;
    }
    
    
}