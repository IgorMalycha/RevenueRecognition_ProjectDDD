namespace RevenueRecognition.Application.Models;

public class DiscountReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    public ICollection<AgreementReadModel> Agreements { get; set; }
}