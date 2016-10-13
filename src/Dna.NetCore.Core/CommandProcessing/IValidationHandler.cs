using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Commands;

namespace Dna.NetCore.Core.CommandProcessing
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        CustomMessage Validate(TCommand command);
    }
}
