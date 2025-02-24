namespace RevenueRecognition.Application.Models;

public class AgreementReadModel
{
    public Guid Id { get; set; }
    public AgreementPeriodReadModel AgreementPeriod { get; set; }
    public int ActualizationYears { get; set; }
    public bool IsSigned { get; set; }
    public bool IsPaid { get; set; }
    public decimal Price { get; set; }
    public SoftwareReadModel Software { get; set; }
    public ClientReadModel Client { get; set; }
    public DiscountReadModel Discount { get; set; }
    public List<PaymentReadModel> Payments { get; set; }
    

    
}