using NetCore.Core.Common;
using NetCore.Core.Commands;

namespace NetCore.Core.CommandProcessing
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        CustomMessage Validate(TCommand command);
    }
}
