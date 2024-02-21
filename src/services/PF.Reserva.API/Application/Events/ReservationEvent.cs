using PF.Core.Messages;

namespace PF.Reserva.API.Application.Events;

public class ReservationEvent : Event
{
    public Guid EstablishmentId { get; set; }

    public ReservationEvent(Guid establishmentId)
    {
        EstablishmentId = establishmentId;
    }
}
