using PF.Estabelecimento.API.Data;
using PF.Estabelecimento.API.Data.Repository;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection Services)
    {
        Services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        Services.AddScoped<EstablishmentContext>();
    }
}
