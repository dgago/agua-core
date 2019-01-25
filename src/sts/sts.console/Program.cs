using System;
using System.Reflection;
using System.Threading;
using core.domain.app;
using core.domain.data;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.log;
using Microsoft.Extensions.DependencyInjection;
using sts.domain.app.commands;
using sts.domain.data;

namespace sts.console
{
  class Program
  {
    static readonly ServiceProvider services;

    static Program()
    {
      services = new ServiceCollection()
        .AddLogging()
        .AddSingleton<ILogAdapter, ConsoleLogAdapter>()
        .AddSingleton<ISettingRepository, SettingRepository>()
        .AddSingleton<IAccessControlConfigDomainService, HardCodedAccessControlConfigDomainService>()
        .AddSingleton<AccessControlDomainService>()
        .AddAuthorizedCommandHandler<ChangeSettingCommand, ChangeSettingCommandHandler>()
        .BuildServiceProvider();
    }

    static void Main(string[] args)
    {
      ICommandHandler<ChangeSettingCommand> handler
        = services.GetService<ICommandHandler<ChangeSettingCommand>>();

      const string id = "1";
      ChangeSettingCommand command = new ChangeSettingCommand(
        id,
        new { a = 1 });
      command.Client = "console";

      try
      {
        CommandResult res = handler.Handle(
          command,
          new CancellationToken());
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"{ex}");
      }
    }
  }
}
