using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands;

public record UpdateIndividualClient(Guid clientId, string email, ClientAddressWriteModel address, string phoneNumber, 
    string firstName, string lastName, string pesel) : ICommand;
