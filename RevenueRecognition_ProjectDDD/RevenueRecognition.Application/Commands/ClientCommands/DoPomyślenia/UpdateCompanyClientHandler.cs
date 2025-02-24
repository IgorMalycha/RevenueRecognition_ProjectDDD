// using RevenueRecognition.Application.Exceptions.ClientExceptions;
// using RevenueRecognition.Application.Services.ClientServices;
// using RevenueRecognition.Domain.Entities.Repositories;
// using RevenueRecognition.Shared.Abstractions.Commands;
//
// namespace RevenueRecognition.Application.Commands.ClientCommands.Handlers;
//
// internal sealed class UpdateCompanyClientHandler : ICommandHandler<UpdateCompanyClient>
// {
//     private readonly IClientRepository _clientRepository;
//     private readonly IClientReadService _clientReadService;
//     public UpdateCompanyClientHandler(IClientRepository clientRepository)
//     {
//         _clientRepository = clientRepository;
//     }
//
//     public async Task HandleAsync(UpdateCompanyClient command)
//     {
//         
//         if (await _clientReadService.ExistsByEmailAsync(command.email))
//         {
//             throw new ClientWithEmailAlreadyExist(command.email);
//         }
//
//         if (await _clientReadService.ExistsByPhoneAsync(command.phoneNumber))
//         {
//             throw new ClientWithPhoneNumberAlreadyExist(command.phoneNumber);
//         }
//
//         if (await _clientReadService.ExistsByKrsAsync(command.krs))
//         {
//             throw new ClientWithKrsNumberAlreadyExist(command.krs);
//         }
//
//         this = command;
//     }
// }