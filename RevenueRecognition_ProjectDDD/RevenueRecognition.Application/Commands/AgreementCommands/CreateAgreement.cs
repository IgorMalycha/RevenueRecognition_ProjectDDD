using RevenueRecognition.Domain.Enums;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Application.Commands.AgreementCommands;

public record CreateAgreement(AgreementPeriodWriteModel agreementPeriod, AgreementActualizationYearsOptions actualizationYears,
    decimal agreemenentPrice, Guid softwareId, Guid clientId, Guid agreementId, Guid discountId,
    PaymentWriteModel payment) : ICommand;

public record AgreementPeriodWriteModel(DateTime startDate, DateTime EnDate);

public record PaymentWriteModel(Guid id, decimal amount, DateTime paymentDate);
