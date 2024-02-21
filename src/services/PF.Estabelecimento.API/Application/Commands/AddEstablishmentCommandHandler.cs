using FluentValidation.Results;
using MediatR;
using PF.Core.Messages;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Application.Commands;

public class AddEstablishmentCommandHandler : CommandHandler, IRequestHandler<AddEstablishmentCommand, ValidationResult>
{
    private readonly IEstablishmentRepository _establishmentRepository;

    public AddEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
    {
        _establishmentRepository = establishmentRepository;
    }

    public async Task<ValidationResult> Handle(AddEstablishmentCommand message, 
        CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var establishment = new Establishment(
            message.Id, message.Name, message.Local, message.ImgURL, message.Detail, message.Favorite, message.QuantityPeople, message.NominatedAudience);

        var existinEstablishment = await _establishmentRepository.GetById(establishment.Id);

        if (existinEstablishment != null)
        {
            AddErro("O estabelecimento já existe.");
            return ValidationResult;
        }

        _establishmentRepository.Add(establishment);

        return await PersistenceData(_establishmentRepository.UnitOfWork);
    }
}
