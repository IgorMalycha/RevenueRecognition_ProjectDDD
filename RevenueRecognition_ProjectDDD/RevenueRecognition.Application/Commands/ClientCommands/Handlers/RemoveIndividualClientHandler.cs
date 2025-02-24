using RevenueRecognition.Application.Exceptions.ClientExceptions;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands.Handlers;

internal sealed class RemoveIndividualClientHandler : ICommandHandler<RemoveIndividualClient>
{
    private readonly IClientRepository _clientRepository;

    public RemoveIndividualClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task HandleAsync(RemoveIndividualClient command)
    {
        Client client = await _clientRepository.GetAsync(command.clientId);
        
        if (client is null)
        {
            throw new ClientNotFoundException(command.clientId);
        }
            
        await _clientRepository.UpdateAsync(client);
    }
}