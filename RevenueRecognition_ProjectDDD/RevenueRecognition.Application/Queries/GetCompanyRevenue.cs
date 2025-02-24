using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Application.Queries;

public class GetCompanyRevenue : IQuery<CompanyRevenueDto>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}