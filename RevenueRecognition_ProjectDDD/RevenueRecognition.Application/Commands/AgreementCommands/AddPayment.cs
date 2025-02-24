using System.Windows.Input;
using ICommand = RevenueRecognition.Shared.Abstractions.Commands.ICommand;

namespace RevenueRecognition.Application.Commands.AgreementCommands;

public record AddPayment(Guid agreementId, Guid paymentId, decimal amount, DateTime PaymentDate) : ICommand;
