using RevenueRecognition.Application.Exceptions.AgreementExceptions;
using RevenueRecognition.Application.Exceptions.ClientExceptions;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.AgreementCommands.Handlers;

internal sealed class CreateAgreementHandler : ICommandHandler<CreateAgreement>
{
    private readonly IAgreementRepository _agreementRepository;
    private readonly ISoftwareRepository _softwareRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IAgreementFactory _agreementFactory;
    
    
    public CreateAgreementHandler(IAgreementRepository agreementRepository, ISoftwareRepository softwareRepository, IClientRepository clientRepository, IAgreementFactory agreementFactory)
    {
        _agreementRepository = agreementRepository;
        _softwareRepository = softwareRepository;
        _clientRepository = clientRepository;
        _agreementFactory = agreementFactory;
    }

    public async Task HandleAsync(CreateAgreement command)
    {
        var software = await _softwareRepository.GetAsync(command.softwareId);

        if (software is null)
        {
            throw new SoftwareNotFoundException(command.softwareId);
        }

        var client = await _clientRepository.GetAsync(command.clientId);

        if (client is null)
        {
            throw new ClientNotFoundException(command.clientId);
        }

        var newAgreement = _agreementFactory.CreateWithPayment(new AgreementPeriod(command.agreementPeriod.startDate, command.agreementPeriod.EnDate), 
            new AgreementActualizationYears(command.actualizationYears), command.agreemenentPrice, command.softwareId, command.clientId, command.agreementId, command.discountId,
            new Payment(command.payment.id, command.payment.amount, command.payment.paymentDate));

        await _agreementRepository.AddAsync(newAgreement);

    }
}