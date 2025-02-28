﻿using Microsoft.Extensions.DependencyInjection;
using RevenueRecognition.Shared.Abstractions.Commands;

namespace RevenueRecognition.Shared.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ICommand>>();

        await handler.HandleAsync(command);
    }
}