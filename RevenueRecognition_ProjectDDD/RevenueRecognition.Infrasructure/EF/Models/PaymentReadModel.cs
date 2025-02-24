namespace RevenueRecognition.Application.Models;

public class PaymentReadModel
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public AgreementReadModel Agreement { get; set; }
    public RevenueReadModel Revenue { get; set; }
}