using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;

namespace RevenueRecognition.Domain.Entities;

public class IndividualClient
{
    private ClientName _firstName;
    private ClientName _lastName;
    private ClientPesel _pesel;
    public bool IsDeleted { get; private set;  }

    public IndividualClient(ClientName firstName, ClientName lastName, ClientPesel pesel, bool isDeleted = false)
    {
        _firstName = firstName;
        _lastName = lastName;
        _pesel = pesel;
        IsDeleted = isDeleted;
    }
    
    
}