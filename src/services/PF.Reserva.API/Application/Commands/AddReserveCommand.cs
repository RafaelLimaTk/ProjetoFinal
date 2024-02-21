using FluentValidation;
using PF.Core.Messages;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Application.Commands;

public class AddReserveCommand : Command
{
    public Guid EstablishmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfPeople { get; set; }
    public decimal TotalPrice { get; set; }
    public string Comments { get; set; }

    public AddReserveCommand(
        Guid establishmentId, DateTime startDate, DateTime endDate, int numberOfPeople, decimal totalPrice, string comments)
    {
        AggregateId = establishmentId;
        EstablishmentId = establishmentId;
        StartDate = startDate;
        EndDate = endDate;
        NumberOfPeople = numberOfPeople;
        TotalPrice = totalPrice;
        Comments = comments;
    }

    public override bool IsValid()
    {
        ValidationResult = new AddReserveValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class AddReserveValidation : AbstractValidator<AddReserveCommand>
{
    public AddReserveValidation()
    {
        RuleFor(r => r.EstablishmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do estabelecimento inválida");

        RuleFor(r => r.StartDate)
            .NotEmpty()
            .WithMessage("A data de inciio não foi informada")
            .Must(BeAValidDate)
            .WithMessage("A data de início é invalida")
            .GreaterThan(DateTime.Now)
            .WithMessage("A data de início deve ser futura");

        RuleFor(r => r.EndDate)
            .NotEmpty()
            .WithMessage("A data fim não foi informada")
            .Must(BeAValidDate)
            .WithMessage("A data fim é inválida")
            .GreaterThan(r => r.StartDate)
            .WithMessage("A data fim deve ser maior que a data de inicio");

        RuleFor(r => r.NumberOfPeople)
            .GreaterThan(0)
            .WithMessage("O numéro de pessoas deve ser maior que 0");

        RuleFor(r => r.TotalPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço total não pode ser negativo");

        RuleFor(r => r.Comments)
            .MaximumLength(500)
            .WithMessage("Os comentários não podem ultrapassar 500 caracteres");
    }
    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
