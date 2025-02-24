using RevenueRecognition.Application.Exceptions.AgreementExceptions;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.AgreementCommands.Handlers;

internal sealed class AddPaymentHandler : ICommandHandler<AddPayment>
{
    private readonly IAgreementRepository _agreementRepository;

    public AddPaymentHandler(IAgreementRepository agreementRepository)
    {
        _agreementRepository = agreementRepository;
    }

    public async Task HandleAsync(AddPayment command)
    {
        var agreement = await _agreementRepository.GetAsync(command.agreementId);

        if (agreement is null)
        {
            throw new AgreementNotFoundException(command.agreementId);
        }

        var payment = new Payment(command.paymentId, command.amount, command.PaymentDate);
        agreement.AddPayment(payment);

        await _agreementRepository.AddAsync(agreement);
    }
}