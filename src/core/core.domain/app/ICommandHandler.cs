﻿using System.Threading.Tasks;
using core.domain.services;

namespace core.domain.app
{
  public interface ICommandHandler<TCommand>
    where TCommand : Command
  {
    CommandResult Handle(TCommand command);

    Task<CommandResult> HandleAsync(TCommand command);
  }
}