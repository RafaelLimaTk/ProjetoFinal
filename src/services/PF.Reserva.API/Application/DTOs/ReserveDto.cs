using PF.Reserva.API.Models;

namespace PF.Reserva.API.Application.DTOs;

public class ReserveDto
{
    public Guid Id { get; set; }
    public Guid EstablishmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ReservationStatus Status { get; set; }
}
