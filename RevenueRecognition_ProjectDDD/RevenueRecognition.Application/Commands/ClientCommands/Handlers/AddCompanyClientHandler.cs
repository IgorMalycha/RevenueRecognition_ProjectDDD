using RevenueRecognition.Application.Exceptions.ClientExceptions;
using RevenueRecognition.Application.Services.ClientServices;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Factories;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands.Handlers;

internal sealed class AddCompanyClientHandler : ICommandHandler<AddCompanyClient>
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientFactorie _clientFactorie;
    private readonly IClientReadService _clientReadService;

    public AddCompanyClientHandler(IClientRepository clientRepository, IClientFactorie clientFactorie, IClientReadService clientReadService)
    {
        _clientRepository = clientRepository;
        _clientFactorie = clientFactorie;
        _clientReadService = clientReadService;
    }

    public async Task HandleAsync(AddCompanyClient command)
    {
        if (await _clientReadService.ExistsByEmailAsync(command.email))
        {
            throw new ClientWithEmailAlreadyExist(command.email);
        }

        if (await _clientReadService.ExistsByPhoneAsync(command.phoneNumber))
        {
            throw new ClientWithPhoneNumberAlreadyExist(command.phoneNumber);
        }

        if (await _clientReadService.ExistsByKrsAsync(command.krs))
        {
            throw new ClientWithKrsNumberAlreadyExist(command.krs);
        }
        
        var newClient = _clientFactorie.Create(command.clientId, command.email, new ClientAddress(command.address.country, command.address.city, command.address.address), 
            command.phoneNumber, command.companyName, command.krs);

        _clientRepository.AddAsync(newClient); 
    }
}