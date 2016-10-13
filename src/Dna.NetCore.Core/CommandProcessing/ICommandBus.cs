﻿using Dna.NetCore.Core.Commands;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.CommandProcessing
{
    public interface ICommandBus
    {
        // DEVNOTE: choice of return type is constrained due to being used as a parameter 
        // passed to System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties);
        CustomMessage Validate<TCommand>(TCommand command) where TCommand : ICommand;

        CustomMessage Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}