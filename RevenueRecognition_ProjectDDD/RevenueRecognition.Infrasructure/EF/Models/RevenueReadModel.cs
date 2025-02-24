namespace RevenueRecognition.Application.Models;

public class RevenueReadModel
{
    public Guid Id { get; set; }
    public decimal RevenueAmount { get; set; }
    public DateTime RecognizedDate { get; set; }

    public PaymentReadModel Payment { get; set; }
}