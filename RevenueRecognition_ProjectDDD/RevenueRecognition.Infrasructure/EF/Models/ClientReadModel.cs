using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RevenueRecognition.Application.Models;

public class ClientReadModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public ClientAddressReadModel Address { get; set; }
    public string PhoneNumber { get; set; }

    public IndividualClientReadModel IndividualClient { get; set; }
    public CompanyClientReadModel CompanyClient { get; set; }
    
}