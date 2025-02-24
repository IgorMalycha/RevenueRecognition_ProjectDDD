using RevenueRecognition.Application.DTOs;
using RevenueRecognition.Shared.Abstractions.Queries;

namespace RevenueRecognition.Application.Queries;

public class GetProductRevenue : IQuery<ProductRevenueDto>
{
    public Guid Id { get; set; }
}