using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

namespace RevenueRecognition.Domain.Entities;

public class CompanyClient : Client
{
    private ClientName _companyName;
    private CompanyKrs _krs;

    public CompanyClient(ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, ClientName companyName, CompanyKrs krs) : base(email, address, phoneNumber)
    {
        _companyName = companyName;
        _krs = krs;
    }
    
    
}