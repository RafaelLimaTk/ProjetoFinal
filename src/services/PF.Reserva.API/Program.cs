using PF.Reserva.API.Configuration;

namespace PF.Reserva.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApiConfiguration(builder.Configuration);

        builder.Services.RegisterServices();

        builder.Services.AddSwaggerConfiguration();

        var myhandlers = AppDomain.CurrentDomain.Load("PF.Core");
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myhandlers));

        var app = builder.Build();

        app.UseApiConfiguration();

        app.Run();
    }
}