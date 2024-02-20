using FluentValidation.Results;
using MediatR;
using PF.Core.Mediator;
using PF.Estabelecimento.API.Application.Commands;
using PF.Estabelecimento.API.Application.Events;
using PF.Estabelecimento.API.Data;
using PF.Estabelecimento.API.Data.Repository;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection Services)
    {
        Services.AddScoped<IMediatorHandler, MediatorHandler>();
        Services.AddScoped<IRequestHandler<AddEstablishmentCommand, ValidationResult>, AddEstablishmentCommandHandler>();
        Services.AddScoped<IRequestHandler<UpdateEstablishmentCommand, ValidationResult>, UpdateEstablishmentCommandHandler>();

        Services.AddScoped<INotificationHandler<AddEstablishmentEvent>, AddEstablishmentEventHandler>();

        Services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        Services.AddScoped<EstablishmentContext>();
    }
}
