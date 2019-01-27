using core.domain.app;
using core.domain.app.commands;
using core.domain.services.accessControl;
using core.domain.services.log;
using core.domain.services.events;
using Microsoft.Extensions.DependencyInjection;

namespace sts.console
{
  public static class CommandHandlerRegistrator
  {
    public static IServiceCollection AddAuthorizedCommandHandler<TCommand, THandler>(
        this IServiceCollection services)
        where TCommand : Command
        where THandler : class, ICommandHandler<TCommand>
    {
      // adds an instance of THandler to the container
      services.AddScoped<THandler>();

      // when an instance of ICommandHandler<TCommand> is requested
      // first wraps that instance into an AuthorizeCommandHandler
      // and then into an EventPublisherCommandHandler
      // this thecnique helps to add cross cutting behavior to the handler
      // it's called the decorator pattern
      // in this particular case, the AuthorizeCommandHandler checks the command
      // and determines if the user or client is authorized to use it and then
      // invokes the command
      // the EventPublisherCommandHandler waits until the command is first
      // authorized and invoked, and then checks the entity in the CommandResult
      // for domain events. If there are any, publishes that events to the
      // event store
      services.AddScoped<ICommandHandler<TCommand>>(x =>
        new EventPublisherCommandHandler<TCommand>(
          x.GetService<IEventAdapter>(),
          new AuthorizeCommandHandler<TCommand>(
            x.GetService<AccessControlDomainService>(),
            x.GetService<IAuthorizationContext>(),
            x.GetService<ILogAdapter>(),
            x.GetService<THandler>())
            )
          );

      return services;
    }
  }
}
