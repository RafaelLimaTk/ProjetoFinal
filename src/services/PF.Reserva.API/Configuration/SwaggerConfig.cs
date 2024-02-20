using Microsoft.OpenApi.Models;

namespace PF.Reserva.API.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection Services)
    {
        Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Projeto Final Reserva API",
                Description = "Está API é exclusivamente criada para estudo e utiliza o RabbitMQ.",
                Contact = new OpenApiContact() { Name = "Rafael Lima", Email = "rafamano123.rl@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    }
}
