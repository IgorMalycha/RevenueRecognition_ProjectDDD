namespace RevenueRecognition.Application.Models;

public class IndividualClientReadModel : ClientReadModel
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public bool IsDeleted { get; set; }
    public string Pesel { get; set; }

    public ICollection<AgreementReadModel> Agreements { get; set; }
    public ClientReadModel Client { get; set; }

}