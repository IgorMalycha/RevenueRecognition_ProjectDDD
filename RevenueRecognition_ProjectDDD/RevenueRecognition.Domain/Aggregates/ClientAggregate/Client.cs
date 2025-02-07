using System.Diagnostics.Contracts;
using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities;

public abstract class Client : AggreagateRoot<ClientId>
{
    public ClientId clientId { get; private set; }
    protected ClientEmail _email;
    protected ClientAddress _address;
    protected ClientPhoneNumber _phoneNumber;

    protected readonly List<Agreement> _contracts = new();

    protected Client(ClientEmail email, ClientAddress address, ClientPhoneNumber phoneNumber)
    {
        _email = email;
        _address = address;
        _phoneNumber = phoneNumber;
    }

    //public abstract void MarkAsDeleted();

    // public void AddContract(Contract contract)
    // {
    //     var alreadyExists =
    //         _contracts.Any(c => c.Customer.Email == contract.Customer.Email 
    //                             && c.Software == contract.Software && c.ContractStatus != ContractStatus.Inactive);
    //
    //     if (alreadyExists)
    //         throw new CustomerContractAlreadyExistsException(Email, contract.Software.Name);
    //     
    //     _contracts.Add(contract);
    // }
    
    
}