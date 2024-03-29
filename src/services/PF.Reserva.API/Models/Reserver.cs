﻿using PF.Core.DomainObjects;

namespace PF.Reserva.API.Models;

public class Reserver : Entity, IAggregateRoot
{
    internal const decimal BASE_PRICE = 800;
    internal const decimal ADDITIONAL_PERSON_PRICE = 3.5M;
    internal const decimal CANCELLATION_FREE_PERCENTAGE = 15;

    public Guid EstablishmentId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public ReservationStatus Status { get; private set; }
    public int NumberOfPeople { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string Comments { get; private set; }

    public Reserver(Guid establishmentId, DateTime startDate, DateTime endDate, int numberOfPeople, decimal totalPrice, string comments)
    {
        Id = Guid.NewGuid();
        EstablishmentId = establishmentId;
        StartDate = startDate;
        EndDate = endDate;
        NumberOfPeople = numberOfPeople;
        TotalPrice = totalPrice;
        Comments = comments;
        Status = ReservationStatus.Pending;
    }

    public bool CheckCapacity(int establishmentCapacity)
    {
        return NumberOfPeople <= establishmentCapacity;
    }

    public void CalculateTotalPrice()
    {
        TotalPrice = BASE_PRICE + (NumberOfPeople * ADDITIONAL_PERSON_PRICE);
    }

    public void ConfirmReservation()
    {
        Status = ReservationStatus.Confirmed;
    }

    public void CancelReservation(DateTime currentDate)
    {
        var startDate = StartDate - currentDate;

        if (startDate.TotalDays >= 7)
        {
            Status = ReservationStatus.Cancelled;
        }
        else
        {
            var diferention = TotalPrice * (CANCELLATION_FREE_PERCENTAGE / 100);
            var valor = TotalPrice - diferention;
            TotalPrice -= valor;
            Status = ReservationStatus.CancelledWithFee;
        }
    }
}
