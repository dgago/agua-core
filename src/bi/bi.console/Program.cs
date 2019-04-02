using System;

using bi.data.pg;
using bi.domain.app.commands;
using bi.domain.data;
using bi.domain.model.bi_event;
using bi.domain.services;

using core.domain.app;
using core.domain.app.commands;
using core.domain.data;
using core.domain.extensions;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.events;
using core.domain.services.log;

using Microsoft.Extensions.DependencyInjection;

namespace bi.console
{
  internal class Program
  {
    private static readonly ServiceProvider services;

    static Program()
    {
      const string connectionString = "Server=192.168.0.103;Port=5432;Database=postgres;User Id=postgres;Password=abc123;";

      IServiceCollection scoll = new ServiceCollection()
        .AddLogging()

        .AddSingleton<ILogAdapter, ConsoleLogAdapter>()
        .AddSingleton<IEventAdapter, ConsoleEventAdapter>()
        .AddSingleton<IAccessControlConfig, ConsoleAccessControlConfig>()
        .AddSingleton<IAuthorizationContext>(_ => new ConsoleAuthorizationContext("console"))
        .AddSingleton<AccessControlDomainService>()
        .AddSingleton<BiEventDomainService>()
        .AddSingleton<IDbContext>(_ => new PgDbContext(connectionString))
        .AddSingleton<IRepository<BiEventRoot>, PgBiEventRepository>()
        .AddSingleton<IBiEventRepository, PgBiEventRepository>()
        .AddAuthorizedCommandHandler<CreateBiEventCommand, CreateBiEventCommandHandler, BiEventRoot>()
        ;

      services = scoll.BuildServiceProvider();
    }

    private static void Main(string[] args)
    {
      ICommandHandler<CreateBiEventCommand> handler
        = services.GetService<ICommandHandler<CreateBiEventCommand>>();

      CreateBiEventCommand command = new CreateBiEventCommand(
        null,
        "prueba",
        System.IO.File.ReadAllText(
          AppDomain.CurrentDomain.BaseDirectory + "\\prueba.json"
          ));

      try
      {
        CommandResult res = handler.Handle(
          command);
      }
      catch(Exception ex)
      {
        Console.WriteLine($"{ex}");
      }
    }
  }
}