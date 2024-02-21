using FluentValidation.Results;
using MediatR;
using PF.Core.Mediator;
using PF.Reserva.API.Application.Commands;
using PF.Reserva.API.Application.Mappings;
using PF.Reserva.API.Application.Queries;
using PF.Reserva.API.Data;
using PF.Reserva.API.Data.Repository;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection Services)
    {
        Services.AddScoped<IMediatorHandler, MediatorHandler>();

        Services.AddScoped<IRequestHandler<AddReserveCommand, ValidationResult>, ReserveCommandHandler>();

        Services.AddScoped<IReserveQueries, ReservaQueries>();

        Services.AddScoped<IReserveRepository, ReserveRepository>();
        Services.AddScoped<ReserveContext>();

        Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
    }
}
