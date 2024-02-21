using FluentValidation.Results;
using PF.Core.Mediator;
using PF.Core.Messages.Integration;
using PF.MessageBus;
using PF.Reserva.API.Application.Commands;

namespace PF.Reserva.API.Services;

public class ReserveIntegrationHandler : BackgroundService
{
    private readonly IMessageBus _bus;
    private readonly IServiceProvider _serviceProvider;

    public ReserveIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
    {
        _bus = bus;
        _serviceProvider = serviceProvider;
    }

    private void SetResponder()
    {
        _bus.RespondAsync<ReservationStartedIntegrationEvent, ResponseMessage>(async request =>
            await ReservationStarted(request));

        _bus.AdvancedBus.Connected += OnConnect;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        SetResponder();
        return Task.CompletedTask;
    }

    private void OnConnect(object s, EventArgs e)
    {
        SetResponder();
    }

    private async Task<ResponseMessage> ReservationStarted(ReservationStartedIntegrationEvent message)
    {
        var clienteCommand = new AddReserveCommand(
            message.EstablishmentId, message.StartDate, message.EndDate, message.NumberOfPeople, message.TotalPrice, message.Comments, message.QuantityPeople);
        ValidationResult sucesso;

        using (var scope = _serviceProvider.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
            sucesso = await mediator.SendCommand(clienteCommand);
        }

        return new ResponseMessage(sucesso);
    }
}
