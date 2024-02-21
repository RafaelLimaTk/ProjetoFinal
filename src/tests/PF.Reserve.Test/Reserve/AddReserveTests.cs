using PF.Reserva.API.Models;

namespace PF.Reserve.Test.Reserve;

public class AddReserveTests
{
    [Fact(DisplayName = "Testando a crição da reserva")]
    public void Reserve_Creation_MustSetpropertieCorrectly()
    {
        // Arrange
        var establishmentId = Guid.NewGuid();
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(2);
        var numberOfPeople = 80;
        var totalPrice = 564;
        var comments = "Nenhuma obs";

        // Act
        var reservation = new Reserver(establishmentId, startDate, endDate, numberOfPeople, totalPrice, comments);

        // Assert 
        Assert.Equal(establishmentId, reservation.EstablishmentId);
        Assert.Equal(startDate, reservation.StartDate);
        Assert.Equal(endDate, reservation.EndDate);
        Assert.Equal(numberOfPeople, reservation.NumberOfPeople);
        Assert.Equal(totalPrice, reservation.TotalPrice);
        Assert.Equal(comments, reservation.Comments);
        Assert.Equal(ReservationStatus.Pending, reservation.Status);
    }

    [Theory(DisplayName = "Checar se a capacidade do estabelecimento dá para o total de pessoas")]
    [InlineData(65, true)]
    [InlineData(45, false)]
    public void Reserve_CheckCapacity_MustReturTrue(int establishmentCapacity, bool capacityResult)
    {
        //Arrang
        var reservation = new Reserver(Guid.NewGuid(), DateTime.Now.AddDays(10), DateTime.Now.AddDays(15), 55, 814, "Nenhuma obs");

        //Act
        var result = reservation.CheckCapacity(establishmentCapacity);

        // Assert
        Assert.Equal(capacityResult, result);
    }

    [Fact(DisplayName = "Calcular o total do preço da reserva")]
    public void Reserver_CalculateTotalPrice_MustCalculateCorrectly()
    {
        //Arrange
        var reservation = new Reserver(Guid.NewGuid(), DateTime.Now.AddDays(10), DateTime.Now.AddDays(15), 50, 0, "Nenhuma obs");

        //Act
        reservation.CalculateTotalPrice();

        //Assert
        var expectedPrice = 800 + (50 * 3.5M);
        Assert.Equal(expectedPrice, reservation.TotalPrice);
    }

    [Fact (DisplayName = "Atualizar o status da reserva para confirmado")]
    public void Reserve_ConfirmReservation_MustUpdateStatusForConfirmReservation()
    {
        //Arrange
        var reservation = new Reserver(Guid.NewGuid(), DateTime.Now.AddDays(10), DateTime.Now.AddDays(15), 50, 814, "Nenhuma obs");

        //Act
        reservation.ConfirmReservation();

        //Assert
        Assert.Equal(ReservationStatus.Confirmed, reservation.Status);
    }

    [Fact (DisplayName = "Cancelar reserva com 7 dias de antecedência deve cancelar sem taxa")]
    public void Reserve_CancelReservation_olderThan7Days_MustCancelWithoutFee()
    {
        //Arrange
        var reservation = new Reserver(Guid.NewGuid(), DateTime.Now.AddDays(10), DateTime.Now.AddDays(15), 50, 814, "Cancel test");
        var currentDate = DateTime.Now;

        //Act
        reservation.CancelReservation(currentDate);

        //Assert
        Assert.Equal(ReservationStatus.Cancelled, reservation.Status);
    }
}
