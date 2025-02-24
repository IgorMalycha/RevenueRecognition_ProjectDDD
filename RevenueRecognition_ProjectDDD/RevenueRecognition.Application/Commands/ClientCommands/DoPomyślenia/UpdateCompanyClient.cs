using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands;

public record UpdateCompanyClient(Guid clientId, string email, ClientAddressWriteModel address, string phoneNumber,
    string companyName, string krs) : ICommand;
