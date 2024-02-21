using FluentValidation.Results;
using MediatR;
using PF.Core.Messages;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Application.Commands;

public class UpdateEstablishmentCommandHandler : CommandHandler, IRequestHandler<UpdateEstablishmentCommand, ValidationResult>
{
    private readonly IEstablishmentRepository _establishmentRepository;

    public UpdateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
    {
        _establishmentRepository = establishmentRepository;
    }

    public async Task<ValidationResult> Handle(UpdateEstablishmentCommand message, 
        CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var existinEstablishment = await _establishmentRepository.GetById(message.Id);
        if (existinEstablishment == null)
        {
            AddErro("Estabelecimento inválido.");
            return ValidationResult;
        }

        existinEstablishment.UpdateEstablishment(
            message.Name, message.Local, message.ImgURL, message.Detail, message.Favorite, message.QuantityPeople, message.NominatedAudience);

        _establishmentRepository.Update(existinEstablishment);

        return await PersistenceData(_establishmentRepository.UnitOfWork);
    }
}
