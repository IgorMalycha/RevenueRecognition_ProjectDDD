using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities.Events;

public record AgreementSigned(Agreement agreement) : IDomainEvent;
