using Microsoft.AspNetCore.Mvc;
using PF.Core.Mediator;
using PF.Estabelecimento.API.Application.Commands;
using PF.Estabelecimento.API.Controllers.Base;
using PF.Estabelecimento.API.DTOs;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Controllers;

public class EstablishmentController : MainController
{
    private readonly IEstablishmentRepository _establishmentRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public EstablishmentController(IEstablishmentRepository establishmentRepository, IMediatorHandler mediatorHandler)
    {
        _establishmentRepository = establishmentRepository;
        _mediatorHandler = mediatorHandler;
    }

    [HttpGet("estabelecimentos")]
    public async Task<IEnumerable<Establishment>> Index()
    {
        return await _establishmentRepository.GetAll();
    }

    [HttpGet("detalhe-estabelecimento/{id}")]
    public async Task<Establishment> EstablishmentDetail(Guid id)
    {
        return await _establishmentRepository.GetById(id);
    }

    [HttpPost("adicionar-estabelecimento")]
    public async Task<ActionResult<Establishment>> AddEstablishment(EstablishmentDto establishment)
    {
        var resultEstablishment = await _mediatorHandler.SendCommand(
            new AddEstablishmentCommand(establishment.Id, establishment.Name, establishment.Local, establishment.ImgURL, establishment.Detail, establishment.Favorite, establishment.QuantityPeople, establishment.NominatedAudience));

        return CustomResponse(resultEstablishment);
    }

    [HttpPut("atualizar-estabelecimento")]
    public async Task<ActionResult<Establishment>> UpdateEstablishment(EstablishmentDto establishment)
    {
        var resultEstablishment = await _mediatorHandler.SendCommand(
            new UpdateEstablishmentCommand(establishment.Id, establishment.Name, establishment.Local, establishment.ImgURL, establishment.Detail, establishment.Favorite, establishment.QuantityPeople, establishment.NominatedAudience));

        return CustomResponse(resultEstablishment);
    }
}
