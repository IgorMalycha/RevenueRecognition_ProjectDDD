namespace RevenueRecognition.Application.Models;

public class CompanyClientReadModel : ClientReadModel
{
    public string CompanyName { get; set; }
    public string KrsNumber { get; set; }

    public ICollection<AgreementReadModel> Agreements { get; set; }
    public ClientReadModel Client { get; set; }
}