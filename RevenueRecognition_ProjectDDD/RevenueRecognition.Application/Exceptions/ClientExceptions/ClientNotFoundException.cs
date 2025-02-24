using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Application.Exceptions.ClientExceptions;

public class ClientNotFoundException : RevenueRecognitionException
{
    public Guid Id { get; }
    public ClientNotFoundException(Guid id) : base($"Client with Id: '{id}' was not found")
        => Id = id;
}