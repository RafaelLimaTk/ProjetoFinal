using FluentValidation.Results;
using MediatR;
using PF.Core.Messages;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Application.Commands;

public class ReserveCommandHandler : CommandHandler, IRequestHandler<AddReserveCommand, ValidationResult>
{
    private readonly IReserveRepository _reserveRepository;
    public ReserveCommandHandler(IReserveRepository reserveRepository)
    {
        _reserveRepository = reserveRepository;
    }

    public async Task<ValidationResult> Handle(AddReserveCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var reserve = new Reserver(
            message.EstablishmentId, message.StartDate, message.EndDate, message.NumberOfPeople, message.TotalPrice, message.Comments);

        if (!ValidateReserve(reserve)) return ValidationResult;

        reserve.CalculateTotalPrice();

        _reserveRepository.Add(reserve);

        return await PersistenceData(_reserveRepository.UnitOfWork);
    }

    private bool ValidateReserve(Reserver reserve)
    {
        var numberOfPeople = reserve.NumberOfPeople;

        if (!reserve.CheckCapacity(numberOfPeople))
        {
            AddErro("A quantidade de pessoas é maior do que o estabelecimento suporta");
            return false;
        }

        return true;
    }
}
