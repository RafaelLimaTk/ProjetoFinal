namespace PF.Core.Messages.Integration;

public class ReservationStartedIntegrationEvent : IntegrationEvent
{
    public Guid EstablishmentId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int NumberOfPeople { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string Comments { get; private set; }

    public int QuantityPeople { get; set; }

    public ReservationStartedIntegrationEvent(
        Guid establishmentId, DateTime startDate, DateTime endDate, int numberOfPeople, decimal totalPrice, string comments)
    {
        EstablishmentId = establishmentId;
        StartDate = startDate;
        EndDate = endDate;
        NumberOfPeople = numberOfPeople;
        TotalPrice = totalPrice;
        Comments = comments;
    }
}
