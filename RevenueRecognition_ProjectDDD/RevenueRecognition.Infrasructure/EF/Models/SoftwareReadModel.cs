namespace RevenueRecognition.Application.Models;

public class SoftwareReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Version { get; set; }
    public string Category { get; set; }
    public decimal SoftwarePrice { get; set; }
    
    public List<AgreementReadModel> Agreements { get; set; }
}