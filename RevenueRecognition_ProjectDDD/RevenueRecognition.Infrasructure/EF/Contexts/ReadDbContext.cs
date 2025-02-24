using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Config;
using RevenueRecognition.Application.Models;

namespace RevenueRecognition.Application.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<ClientReadModel> Clients { get; set; }
    public DbSet<AgreementReadModel> Agreements { get; set; }
    public DbSet<IndividualClientReadModel> IndividualClients { get; set; }
    public DbSet<CompanyClientReadModel> CompanyClients { get; set; }
    public DbSet<DiscountReadModel> Discounts { get; set; }
    public DbSet<SoftwareReadModel> Softwares { get; set; }
    public DbSet<PaymentReadModel> Payments { get; set; }
    public DbSet<RevenueReadModel> Revenues { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("revenue");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<ClientReadModel>(configuration);
        modelBuilder.ApplyConfiguration<AgreementReadModel>(configuration);
        modelBuilder.ApplyConfiguration<IndividualClientReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CompanyClientReadModel>(configuration);
        modelBuilder.ApplyConfiguration<DiscountReadModel>(configuration);
        modelBuilder.ApplyConfiguration<SoftwareReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PaymentReadModel>(configuration);
        modelBuilder.ApplyConfiguration<RevenueReadModel>(configuration);

    }
}