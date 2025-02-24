namespace RevenueRecognition.Domain.ValueObjects.AgreementValueObjects;

public record AgreementPeriod
{
    public DateTime BeginDate { get; }
    public DateTime EndDate { get; }

    public AgreementPeriod(DateTime beginDate, DateTime endDate)
    {
        BeginDate = beginDate;
        EndDate = endDate;
    }
}