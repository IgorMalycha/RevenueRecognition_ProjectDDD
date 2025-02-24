using RevenueRecognition.Application.Exceptions.ClientExceptions;
using RevenueRecognition.Application.Services.ClientServices;
using RevenueRecognition.Domain.Entities.Factories;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands.Handlers;

internal sealed class AddIndividualClientHandler : ICommandHandler<AddIndividualClient>
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientFactorie _clientFactorie;
    private readonly IClientReadService _clientReadService;

    public AddIndividualClientHandler(IClientRepository clientRepository, IClientFactorie clientFactorie, IClientReadService clientReadService)
    {
        _clientRepository = clientRepository;
        _clientFactorie = clientFactorie;
        _clientReadService = clientReadService;
    }

    public async Task HandleAsync(AddIndividualClient command)
    {
        if (await _clientReadService.ExistsByEmailAsync(command.email))
        {
            throw new ClientWithEmailAlreadyExist(command.email);
        }

        if (await _clientReadService.ExistsByPhoneAsync(command.phoneNumber))
        {
            throw new ClientWithPhoneNumberAlreadyExist(command.phoneNumber);
        }

        if (await _clientReadService.ExistsByPeselAsync(command.pesel))
        {
            throw new ClientWithPeselAlreadyExist(command.pesel);
        }
        
        var newClient = _clientFactorie.Create(command.clientId, command.email, new ClientAddress(command.address.country, command.address.city, command.address.address), 
            command.phoneNumber, command.firstName, command.lastName, command.pesel);

        _clientRepository.AddAsync(newClient); 
    }
}