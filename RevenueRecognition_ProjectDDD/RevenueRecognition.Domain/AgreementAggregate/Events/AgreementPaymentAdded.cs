using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities.Events;

public record AgreementPaymentAdded(Agreement agreement, Payment payment) : IDomainEvent;
