using System;
using System.Reflection;
using System.Threading;
using core.domain.app;
using core.domain.data;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.log;
using core.domain.services.events;
using Microsoft.Extensions.DependencyInjection;
using sts.domain.app.commands;
using sts.domain.data;
using sts.data;
using core.domain.app.commands;
using sts.domain.model.settings;

namespace sts.console
{
  class Program
  {
    static readonly ServiceProvider services;

    static Program()
    {
      IServiceCollection scoll = new ServiceCollection()
        .AddLogging()
        .AddSingleton<ILogAdapter, ConsoleLogAdapter>()
        .AddSingleton<IEventAdapter, ConsoleEventAdapter>()
        .AddSingleton<ISettingRepository, ConsoleSettingRepository>()
        .AddSingleton<IAccessControlConfig, ConsoleAccessControlConfig>()
        .AddSingleton<AccessControlDomainService>()
        .AddSingleton<IAuthorizationContext>(x => new ConsoleAuthorizationContext("console"))
        .AddAuthorizedCommandHandler<ChangeSettingCommand, ChangeSettingCommandHandler, SettingRoot>()
        .AddAuthorizedCommandHandler<CreateSettingCommand, CreateSettingCommandHandler, SettingRoot>()
        .AddAuthorizedCommandHandler<RemoveSettingCommand, RemoveSettingCommandHandler, SettingRoot>();

      services = scoll.BuildServiceProvider();
    }

    static void Main(string[] args)
    {
      ICommandHandler<ChangeSettingCommand> handler
        = services.GetService<ICommandHandler<ChangeSettingCommand>>();

      const string id = "1";
      ChangeSettingCommand command = new ChangeSettingCommand(
        id,
        new { a = 1 });

      try
      {
        CommandResult res = handler.Handle(
          command);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"{ex}");
      }
    }
  }
}
