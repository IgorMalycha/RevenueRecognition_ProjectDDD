using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.ClientCommands;

public record AddCompanyClient(Guid clientId, string email, ClientAddressWriteModel address, string phoneNumber,
    string companyName, string krs) : ICommand;

public record ClientAddressWriteModel(string country, string city, string address);
