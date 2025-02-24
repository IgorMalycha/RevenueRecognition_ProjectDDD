using Microsoft.Extensions.DependencyInjection;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Factories;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Policies;
using RevenueRecognition.Domain.Entities.Factories;
using RevenueRecognition.Domain.Entities.Policies;
using RevenueRecognition.Domain.Entities.Repositories;
using RevenueRecognition.Shared.Commands;

namespace RevenueRecognition.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();

        services.AddSingleton<IAgreementFactory, AgreementFactory>();
        services.AddSingleton<IClientFactorie, ClientFactorie>();
        services.AddSingleton<IDiscountFactorie, DiscountFactorie>();
        services.AddSingleton<IRevenueFactory, RevenueFactory>();
        services.AddSingleton<ISoftwareFactorie, SoftwareFactorie>();

        services.Scan(e => e.FromAssemblies(typeof(IAgreementPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IAgreementPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        services.Scan(e => e.FromAssemblies(typeof(IClientPolicie).Assembly)
            .AddClasses(c => c.AssignableTo<IClientPolicie>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        services.Scan(e => e.FromAssemblies(typeof(IDiscountPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IDiscountPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        services.Scan(e => e.FromAssemblies(typeof(IRevenuePolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IRevenuePolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        services.Scan(e => e.FromAssemblies(typeof(ISoftwarePolicy).Assembly)
            .AddClasses(c => c.AssignableTo<ISoftwarePolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        return services;
    }
}