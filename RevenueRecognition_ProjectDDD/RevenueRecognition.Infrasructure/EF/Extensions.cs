using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RevenueRecognition.Application.Repositories;
using RevenueRecognition.Application.Services;
using RevenueRecognition.Application.Services.ClientServices;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Repositories;
using RevenueRecognition.Domain.Entities.Repositories;

namespace RevenueRecognition.Application.EF;

internal static class Extensions
{
    public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAgreementRepository, MySqlAgreementRepository>();
        services.AddScoped<IClientRepository, MySqlClientRepository>();
        services.AddScoped<IDiscountRepository, MySqlDiscountRepository>();
        services.AddScoped<IRevenueRepository, MySqlRevenueRepository>();
        services.AddScoped<ISoftwareRepository, MySqlSoftwareRepository>();
        services.AddScoped<IClientReadService, ClientReadService>();
            
        // var options = configuration.GetOptions<MySqlOptions>("MySql");
        // services.AddDbContext<ReadDbContext>(ctx => 
        //     ctx.UseNpgsql(options.ConnectionString));
        // services.AddDbContext<WriteDbContext>(ctx => 
        //     ctx.UseNpgsql(options.ConnectionString));

        return services;
    }

}