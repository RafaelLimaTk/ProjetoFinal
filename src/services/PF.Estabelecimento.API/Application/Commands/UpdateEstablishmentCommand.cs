using FluentValidation;
using PF.Core.Messages;

namespace PF.Estabelecimento.API.Application.Commands;

public class UpdateEstablishmentCommand : Command
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Local { get; set; }
    public string ImgURL { get; set; }
    public string Detail { get; set; }
    public bool Favorite { get; set; }
    public int QuantityPeople { get; set; }
    public string NominatedAudience { get; set; }

    public UpdateEstablishmentCommand(
    Guid id, string name, string local, string imgUrl, string detail, bool favorite, int quantityPeople, string nominatedAudience)
    {
        AggregateId = id;
        Id = id;
        Name = name;
        Local = local;
        ImgURL = imgUrl;
        Detail = detail;
        Favorite = favorite;
        QuantityPeople = quantityPeople;
        NominatedAudience = nominatedAudience;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateEstablishmentValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class UpdateEstablishmentValidation : AbstractValidator<UpdateEstablishmentCommand>
{
    public UpdateEstablishmentValidation()
    {
        RuleFor(e => e.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do estabelecimento inválida");

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("O nome do estabelecimento não foi informado");

        RuleFor(c => c.Local)
            .NotEmpty()
            .WithMessage("O local do estabelecimento não foi informado");

        RuleFor(c => c.ImgURL)
            .NotEmpty()
            .WithMessage("Ocorreu um erro ao salvar a imagem do estabelecimento");

        RuleFor(c => c.Detail)
            .NotEmpty()
            .WithMessage("Os detalhes do estabelecimento não foi informado");

        RuleFor(c => c.NominatedAudience)
            .NotEmpty()
            .WithMessage("O público alvo não foi informado");
    }
}
