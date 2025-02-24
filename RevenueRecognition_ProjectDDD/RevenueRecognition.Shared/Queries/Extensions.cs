using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Shared.Queries;

public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.Scan(e => e.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}