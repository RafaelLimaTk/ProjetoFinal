using PF.Core.Utils;
using PF.MessageBus;
using PF.Reserva.API.Services;

namespace PF.Reserve.API.Configuration;

public static class MessageBusConfig
{
    public static void AddMessageBusConfiguration(this IServiceCollection Services,
    IConfiguration configuration)
    {
        Services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
            .AddHostedService<ReserveIntegrationHandler>();
    }
}
