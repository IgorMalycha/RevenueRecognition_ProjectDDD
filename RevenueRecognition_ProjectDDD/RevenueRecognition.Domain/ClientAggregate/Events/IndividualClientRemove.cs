using RevenueRecognition.Shared.Abstractions.Domain;

namespace RevenueRecognition.Domain.Entities.Events;

public class IndividualClientRemove(Client client) : IDomainEvent;
