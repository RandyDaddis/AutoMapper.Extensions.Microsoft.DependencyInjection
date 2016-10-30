using Autofac;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Commands;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.CommandProcessing
{
    public class CommandBus : ICommandBus
    {
        private readonly IComponentContext _context;
        public CommandBus(IComponentContext context)
        {
            _context = context;
        }
        public CustomMessage Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            var handler = _context.Resolve<ICommandHandler<TCommand>>();

            if (!((handler != null) && handler is ICommandHandler<TCommand>))
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = "CommandHandlerNotFoundException_Dna(" + typeof(TCommand) + ")";
            }
            else
            {
                customMessage = handler.Execute(command); // E.G. xxx_UpdateHandler.Execute()
                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = "CommandBus_Dna.Execute() | handler.Execute(command) - null returned";
                }
            }
            return customMessage;
        }

        public CustomMessage Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            var handler = _context.Resolve<IValidationHandler<TCommand>>();

            if (!((handler != null) && handler is IValidationHandler<TCommand>))
            {
                customMessage.IsErrorCondition = true;
                customMessage.Message = "ValidationHandlerNotFoundException_Dna(" + typeof(TCommand) + ")";
            }
            else
            {
                customMessage = handler.Validate(command); // E.G. xxx_ValidationHandler.Validate()
                if (customMessage == null)
                {
                    customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                    customMessage.IsErrorCondition = true;
                    customMessage.Message = "CommandBus_Dna.Validate() | handler.Validate(command) - null returned";
                }
            }
            return customMessage;
        }
    }
}
