using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Application.Config;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

namespace RevenueRecognition.Application.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Agreement> Agreements { get; set; }
    public DbSet<IndividualClient> IndividualClients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Revenue> Revenues { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("revenue");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Client>(configuration);
        modelBuilder.ApplyConfiguration<Agreement>(configuration);
        modelBuilder.ApplyConfiguration<IndividualClient>(configuration);
        modelBuilder.ApplyConfiguration<CompanyClient>(configuration);
        modelBuilder.ApplyConfiguration<Discount>(configuration);
        modelBuilder.ApplyConfiguration<Software>(configuration);
        modelBuilder.ApplyConfiguration<Payment>(configuration);
        modelBuilder.ApplyConfiguration<Revenue>(configuration);
    }
    
}