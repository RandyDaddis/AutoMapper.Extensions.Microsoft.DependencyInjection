using NetCore.Core.Common;
using NetCore.Core.Commands;

namespace NetCore.Core.CommandProcessing
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        CustomMessage Execute(TCommand command);
    }
}

