using Microsoft.EntityFrameworkCore;
using PF.Reserva.API.Data;

namespace PF.Reserva.API.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection Services, 
        IConfiguration Configuration)
    {
        Services.AddDbContext<ReserveContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        Services.AddControllers();

        Services.AddCors(options =>
        {
            options.AddPolicy("Total",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        Services.AddEndpointsApiExplorer();
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
        }

        app.UseHttpsRedirection();

        app.UseCors("Total");

        app.UseAuthorization();

        app.MapControllers();
    }
}
