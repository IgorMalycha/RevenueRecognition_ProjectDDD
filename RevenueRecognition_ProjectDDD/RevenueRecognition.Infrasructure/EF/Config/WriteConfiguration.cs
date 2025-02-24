using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate;
using RevenueRecognition.Domain.Aggregates.RevenueAggregate.Entities;
using RevenueRecognition.Domain.Entities;
using RevenueRecognition.Domain.Enums;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;
using RevenueRecognition.Domain.ValueObjects.AgreementValueObjects.ValueObjects;
using RevenueRecognition.Domain.ValueObjects.ClientValueObjects;
using RevenueRecognition.Domain.ValueObjects.DiscountValueObject;
using RevenueRecognition.Domain.ValueObjects.SoftwareValueObjects;

namespace RevenueRecognition.Application.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Agreement>,
    IEntityTypeConfiguration<Client>, IEntityTypeConfiguration<IndividualClient>,
    IEntityTypeConfiguration<CompanyClient>, IEntityTypeConfiguration<Discount>,
    IEntityTypeConfiguration<Payment>, IEntityTypeConfiguration<Revenue>,
    IEntityTypeConfiguration<Software>
{
    public void Configure(EntityTypeBuilder<Agreement> builder)
    {
        builder.ToTable("Agreement");
        builder.HasKey(e => e.AgreementId);

        var agreementIdConverter = new ValueConverter<AgreementId, Guid>(id => id.Value, id => new AgreementId(id));
        var agreementPriceConverter = new ValueConverter<AgreementPrice, decimal>(p => p.Value, p => new AgreementPrice(p));
        var actualizationYearsConverter = new ValueConverter<AgreementActualizationYears, int>(y => (int)y.Value, y => new AgreementActualizationYears((AgreementActualizationYearsOptions)y));
        var softwareIdConverter = new ValueConverter<SoftwareId, Guid>(id => id.Value, id => new SoftwareId(id));
        var clientIdConverter = new ValueConverter<ClientId, Guid>(id => id.Value, id => new ClientId(id));
        var discountIdConverter = new ValueConverter<DiscountId, Guid>(id => id.Value, id => new DiscountId(id));

        builder.Property(typeof(AgreementId), "_agreementId")
            .HasConversion(agreementIdConverter)
            .HasColumnName("AgreementId");

        builder.Property(typeof(DateTime), "_agreementPeriod_BeginDate")
            .HasColumnName("AgreementPeriod_BeginDate");

        builder.Property(typeof(DateTime), "_agreementPeriod_EndDate")
            .HasColumnName("AgreementPeriod_EndDate");

        builder.Property(typeof(AgreementActualizationYears), "_actualizationYears")
            .HasConversion(actualizationYearsConverter)
            .HasColumnName("ActualizationYears");

        builder.Property(typeof(AgreementPrice), "_agreementPrice")
            .HasConversion(agreementPriceConverter)
            .HasColumnName("Price");

        builder.Property(typeof(SoftwareId), "_softwareId")
            .HasConversion(softwareIdConverter)
            .HasColumnName("SoftwareId");

        builder.Property(typeof(ClientId), "_clientId")
            .HasConversion(clientIdConverter)
            .HasColumnName("ClientId");

        builder.Property(typeof(DiscountId), "_discountId")
            .HasConversion(discountIdConverter)
            .HasColumnName("DiscountId");

        builder.HasMany(typeof(Payment), "_payments")
            .WithOne()
            .HasForeignKey("AgreementId")
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void Configure(EntityTypeBuilder<Client> builder)
    {
        var clientIdConverter = new ValueConverter<ClientId, Guid>(id => id.Value, id => new ClientId(id));
        var emailConverter = new ValueConverter<ClientEmail, string>(e => e.Value, e => new ClientEmail(e));
        var phoneNumberConverter = new ValueConverter<ClientPhoneNumber, string>(p => p.Value, p => new ClientPhoneNumber(p));
        
        builder.Property(typeof(string), "_address_Country")
            .HasColumnName("Address_Country");

        builder.Property(typeof(string), "_address_City")
            .HasColumnName("Address_City");

        builder.Property(typeof(string), "_address_Address")
            .HasColumnName("Address_Address");
        
        builder.ToTable("Client");
        builder.HasKey(e => e.ClientId);

        builder.Property(typeof(ClientId), "_clientId")
            .HasConversion(clientIdConverter)
            .HasColumnName("Id");

        builder.Property(typeof(ClientEmail), "_email")
            .HasConversion(emailConverter)
            .HasColumnName("Email");

        builder.Property(typeof(ClientPhoneNumber), "_phoneNumber")
            .HasConversion(phoneNumberConverter)
            .HasColumnName("PhoneNumber");
    }

    public void Configure(EntityTypeBuilder<IndividualClient> builder)
    {
        var firstNameConverter = new ValueConverter<ClientName, string>(n => n.Value, n => new ClientName(n));
        var lastNameConverter = new ValueConverter<ClientName, string>(n => n.Value, n => new ClientName(n));
        var peselConverter = new ValueConverter<ClientPesel, string>(p => p.Value, p => new ClientPesel(p));

        builder.ToTable("IndividualClient");

        builder.Property(typeof(ClientName), "_firstName")
            .HasConversion(firstNameConverter)
            .HasColumnName("FirstName");

        builder.Property(typeof(ClientName), "_lastName")
            .HasConversion(lastNameConverter)
            .HasColumnName("LastName");

        builder.Property(typeof(ClientPesel), "_pesel")
            .HasConversion(peselConverter)
            .HasColumnName("Pesel");

        builder.Property(i => i.IsDeleted)
            .HasColumnName("IsDeleted");
    }

    public void Configure(EntityTypeBuilder<CompanyClient> builder)
    {
        var companyNameConverter = new ValueConverter<ClientName, string>(n => n.Value, n => new ClientName(n));
        var krsConverter = new ValueConverter<CompanyKrs, string>(k => k.Value, k => new CompanyKrs(k));

        builder.ToTable("CompanyClient");

        builder.Property(typeof(ClientName), "_companyName")
            .HasConversion(companyNameConverter)
            .HasColumnName("Name");

        builder.Property(typeof(CompanyKrs), "_krs")
            .HasConversion(krsConverter)
            .HasColumnName("KRS");
    }

    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        var discountIdConverter = new ValueConverter<DiscountId, Guid>(id => id.Value, id => new DiscountId(id));
        var discountNameConverter = new ValueConverter<DiscountName, string>(a => a.Value, a => new DiscountName(a));
        var discountValueConverter = new ValueConverter<DiscountValue, int>(a => a.Value, a => new DiscountValue(a));

        builder.ToTable("Discount");
        builder.HasKey(e => e.DiscountId);

        builder.Property(typeof(DiscountId), "_discountId")
            .HasConversion(discountIdConverter)
            .HasColumnName("Id");
        
        builder.Property(typeof(DiscountName), "_discountName")
            .HasConversion(discountNameConverter)
            .HasColumnName("Name");
        
        builder.Property(typeof(DiscountValue), "_discountValue")
            .HasConversion(discountValueConverter)
            .HasColumnName("Value");
    }

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        var paymentIdConverter = new ValueConverter<PaymentId, Guid>(id => id.Value, id => new PaymentId(id));
        var moneyConverter = new ValueConverter<Money, decimal>(m => m.Value, m => new Money(m));

        builder.ToTable("Payment");
        builder.HasKey(e => e.PaymentId);

        builder.Property(typeof(PaymentId), "_paymentId")
            .HasConversion(paymentIdConverter)
            .HasColumnName("Id");

        builder.Property(typeof(Money), "_amount")
            .HasConversion(moneyConverter)
            .HasColumnName("Amount");

        builder.Property(p => p._paymentDate)
            .HasColumnType("datetime")
            .HasColumnName("PaymentDate");
    }

    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        var revenueIdConverter = new ValueConverter<RevenueId, Guid>(id => id.Value, id => new RevenueId(id));
        var revenueAmountConverter = new ValueConverter<RevenueAmount, decimal>(a => a.Value, a => new RevenueAmount(a));
        builder.ToTable("Revenue");
        builder.HasKey(e => e.RevenueId);

        builder.Property(typeof(RevenueId), "_revenueId")
            .HasConversion(revenueIdConverter)
            .HasColumnName("Id");

        builder.Property(typeof(RevenueAmount), "_revenueAmount")
            .HasConversion(revenueAmountConverter)
            .HasColumnName("Amount");
        
        builder.Property(typeof(DateTime), "_recognizedDate")
            .HasColumnName("ReconizedDate");
    }

    public void Configure(EntityTypeBuilder<Software> builder)
    {
        var softwareIdConverter = new ValueConverter<SoftwareId, Guid>(id => id.Value, id => new SoftwareId(id));
        var softwareNameConverter = new ValueConverter<SoftwareName, string>(a => a.Value, a => new SoftwareName(a));
        var softwareDescriptionConverter = new ValueConverter<SoftwareDescription, string>(a => a.Value, a => new SoftwareDescription(a));
        var softwareVersionConverter = new ValueConverter<SoftwareVersion, string>(a => a.Value, a => new SoftwareVersion(a));
        var softwareCategoryConverter = new ValueConverter<SoftwareCategory, string>(a => a.Value, a => new SoftwareCategory(a));
        var softwarePriceConverter = new ValueConverter<SoftwarePrice, decimal>(a => a.Value, a => new SoftwarePrice(a));
        
        builder.ToTable("Software");
        builder.HasKey(e => e.SoftwareId);

        builder.Property(typeof(SoftwareId), "_softwareId")
            .HasConversion(softwareIdConverter)
            .HasColumnName("Id");
        
        builder.Property(typeof(SoftwareName), "_softwareName")
            .HasConversion(softwareNameConverter)
            .HasColumnName("Name");
        
        builder.Property(typeof(SoftwareDescription), "_softwareDescription")
            .HasConversion(softwareDescriptionConverter)
            .HasColumnName("Description");
        
        builder.Property(typeof(SoftwareVersion), "_softwareVersion")
            .HasConversion(softwareVersionConverter)
            .HasColumnName("Version");
        
        builder.Property(typeof(SoftwareCategory), "_softwareCategory")
            .HasConversion(softwareCategoryConverter)
            .HasColumnName("Category");
        
        builder.Property(typeof(SoftwarePrice), "_softwarePrice")
            .HasConversion(softwarePriceConverter)
            .HasColumnName("Price");
        
        
    }
}
