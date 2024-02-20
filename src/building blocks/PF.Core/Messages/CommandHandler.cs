using FluentValidation.Results;
using PF.Core.Data;

namespace PF.Core.Messages;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ValidationResult();
    }

    protected void AddErro(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }

    protected async Task<ValidationResult> PersistenceData(IUnitOfWork uow)
    {
        if (!await uow.Commit()) AddErro("Houve um erro ao persistir os dados");

        return ValidationResult;
    }
}
