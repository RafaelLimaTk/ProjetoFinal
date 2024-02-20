using PF.Estabelecimento.API.Configuration;

namespace PF.Estabelecimento.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiConfiguration(builder.Configuration);

            builder.Services.RegisterServices();

            builder.Services.AddSwaggerConfiguration();

            var app = builder.Build();

            app.UseApiConfiguration();

            app.Run();
        }
    }
}