using FluentValidation.Results;
using MediatR;
using PF.Core.Mediator;
using PF.Estabelecimento.API.Application.Commands;
using PF.Estabelecimento.API.Application.Mappings;
using PF.Estabelecimento.API.Application.Queries;
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


        Services.AddScoped<IEstablishmentQueries, EstablishmentQueries>();

        Services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        Services.AddScoped<EstablishmentContext>();

        Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
    }
}
