using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Commands;

namespace Dna.NetCore.Core.CommandProcessing
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        CustomMessage Execute(TCommand command);
    }
}

