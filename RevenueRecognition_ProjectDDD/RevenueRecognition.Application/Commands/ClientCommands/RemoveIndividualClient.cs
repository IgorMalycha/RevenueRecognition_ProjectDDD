using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands;

public record RemoveIndividualClient(Guid clientId) : ICommand;
