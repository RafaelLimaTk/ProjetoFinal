﻿using Microsoft.AspNetCore.Mvc;
using PF.Core.Mediator;
using PF.Core.Messages.Integration;
using PF.Estabelecimento.API.Application.Commands;
using PF.Estabelecimento.API.Application.DTOs;
using PF.Estabelecimento.API.Application.Queries;
using PF.Estabelecimento.API.Controllers.Base;
using PF.Estabelecimento.API.Models;
using PF.MessageBus;

namespace PF.Estabelecimento.API.Controllers;

public class EstablishmentController : MainController
{
    private readonly IEstablishmentQueries _establishmentQueries;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMessageBus _bus;

    public EstablishmentController(IEstablishmentQueries establishmentQueries, IMediatorHandler mediatorHandler, IMessageBus bus)
    {
        _establishmentQueries = establishmentQueries;
        _mediatorHandler = mediatorHandler;
        _bus = bus;
    }

    [HttpGet("estabelecimentos")]
    public async Task<IActionResult> Index()
    {
        var establishments = await _establishmentQueries.GetAll();

        return establishments == null ? NotFound() : CustomResponse(establishments);
    }

    [HttpGet("detalhe-estabelecimento/{id}")]
    public async Task<IActionResult> EstablishmentDetail(Guid id)
    {
        var establishment = await _establishmentQueries.GetById(id);
        return establishment == null ? NotFound() : CustomResponse(establishment);
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

    [HttpPost("reservar-estabelecimento")]
    public async Task<ActionResult<Establishment>> ReserverEstablishment(ReservationStartedIntegrationEvent establishment)
    {
        var reserveResult = await CreateReserve(establishment);

        if (!reserveResult.ValidationResult.IsValid) return CustomResponse(reserveResult.ValidationResult);

        return CustomResponse();
    }

    private async Task<ResponseMessage> CreateReserve(ReservationStartedIntegrationEvent establishment)
    {
        var createReserve = new ReservationStartedIntegrationEvent(
            establishment.EstablishmentId, establishment.StartDate, establishment.EndDate, establishment.NumberOfPeople, establishment.TotalPrice, establishment.Comments);

        var establishmentExisti = await _establishmentQueries.GetById(establishment.EstablishmentId);
        if (establishmentExisti != null) createReserve.QuantityPeople = establishmentExisti.QuantityPeople;

        return await _bus.RequestAsync<ReservationStartedIntegrationEvent, ResponseMessage>(createReserve);
    }
}
