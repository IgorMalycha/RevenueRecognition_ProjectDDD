using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Application.Models;

namespace RevenueRecognition.Application.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<AgreementReadModel>,
    IEntityTypeConfiguration<ClientReadModel>, IEntityTypeConfiguration<IndividualClientReadModel>,
    IEntityTypeConfiguration<CompanyClientReadModel>, IEntityTypeConfiguration<DiscountReadModel>,
    IEntityTypeConfiguration<PaymentReadModel>, IEntityTypeConfiguration<RevenueReadModel>,
    IEntityTypeConfiguration<SoftwareReadModel>
{
    public void Configure(EntityTypeBuilder<AgreementReadModel> builder)
    {
        builder.ToTable("Agreement");
        builder.HasKey(e => e.Id);
        builder.OwnsOne(e => e.AgreementPeriod, period =>
        {
            period.Property(d => d.BeginDate).IsRequired().HasColumnName("begin_date");
            period.Property(d => d.EndDate).IsRequired().HasColumnName("end_date");
        });

        builder.HasOne(e => e.Software);
        builder.HasOne(e => e.Client);
        builder.HasOne(e => e.Discount);
        builder.HasMany(e => e.Payments);
    }

    public void Configure(EntityTypeBuilder<ClientReadModel> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.Address, address =>
        {
            address.Property(a => a.Address).IsRequired().HasColumnName("address");
            address.Property(a => a.Country).IsRequired().HasColumnName("country");
            address.Property(a => a.City).IsRequired().HasColumnName("city");
        });

        builder.HasIndex(e => e.Email).IsUnique();

        builder.HasOne(e => e.CompanyClient);
        builder.HasOne(e => e.IndividualClient);
    }

    public void Configure(EntityTypeBuilder<IndividualClientReadModel> builder)
    {
        builder.ToTable("IndividualClient");
        builder.HasKey(e => e.Id);
        
        builder.HasIndex(e => e.Pesel).IsUnique();

        builder.HasMany(e => e.Agreements);
        builder.HasOne(e => e.Client);
    }

    public void Configure(EntityTypeBuilder<CompanyClientReadModel> builder)
    {
        builder.ToTable("CompanyClient");
        builder.HasKey(e => e.Id);
        
        builder.HasIndex(e => e.KrsNumber).IsUnique();
        
        builder.HasMany(e => e.Agreements);
        builder.HasOne(e => e.Client);
    }

    public void Configure(EntityTypeBuilder<DiscountReadModel> builder)
    {
        builder.ToTable("Discount");
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Agreements);
    }

    public void Configure(EntityTypeBuilder<PaymentReadModel> builder)
    {
        builder.ToTable("Payment");
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Agreement);
        builder.HasOne(e => e.Revenue);
    }

    public void Configure(EntityTypeBuilder<RevenueReadModel> builder)
    {
        builder.ToTable("Revenue");
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Payment);
    }

    public void Configure(EntityTypeBuilder<SoftwareReadModel> builder)
    {
        builder.ToTable("Software");
        builder.HasKey(e => e.Id);  
        
        builder.HasMany(e => e.Agreements);
    }
}