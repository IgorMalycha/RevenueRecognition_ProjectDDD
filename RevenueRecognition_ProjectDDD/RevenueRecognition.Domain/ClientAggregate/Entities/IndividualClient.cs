using RevenueRecognition.Domain.Entities.Events;
using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Domain.Entities;

public class IndividualClient : Client
{
    private ClientName _firstName;
    private ClientName _lastName;
    private ClientPesel _pesel;
    public bool IsDeleted { get; private set;  }

    public IndividualClient(ClientId clientId, ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber, ClientName firstName, ClientName lastName, ClientPesel pesel, bool isDeleted = false) : base(clientId, email, address, phoneNumber)
    {
        _firstName = firstName;
        _lastName = lastName;
        _pesel = pesel;
        IsDeleted = isDeleted;
    }

    public void DeleteIdividualClient()
    {
        IsDeleted = true;
        
        AddEvent(new IndividualClientRemove(this));
    }
    
}