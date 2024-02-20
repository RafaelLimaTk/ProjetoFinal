using FluentValidation.Results;
using PF.Core.Messages;

namespace PF.Core.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T evento) where T : Event;
    Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
}
