using MediatR;

namespace PF.Estabelecimento.API.Application.Events;

public class AddEstablishmentEventHandler : INotificationHandler<AddEstablishmentEvent>
{
    public Task Handle(AddEstablishmentEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
