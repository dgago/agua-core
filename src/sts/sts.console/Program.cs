﻿using System;
using System.Reflection;
using core.domain.app;
using core.domain.data;
using core.domain.services;
using core.domain.services.log;
using SimpleInjector;
using sts.domain.app.commands;
using sts.domain.data;

namespace sts.console
{

  class Program
  {
    static readonly Container container;

    static Program()
    {
      container = new Container();

      container.Register<ILogAdapter, ConsoleLogAdapter>(
        Lifestyle.Singleton);

      // TODO: debería haber una forma de registrar a todos los repository juntos
      // container.Collection.Register(
      //   typeof(IRepository),
      //   typeof(IRepository).Assembly);
      // despues de todo creo que es buena idea poner un tipo generico en irepository
      // para evitar lo siguiente
      container.Register<ISettingRepository, SettingRepository>(
        Lifestyle.Singleton);

      // TODO: debería haber una forma de registrar a todos los command handler juntos
      // container.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly, Lifestyle.Singleton);

      container.Register<ICommandHandler<ChangeSettingCommand>, ChangeSettingCommandHandler>();

      container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(AuthorizeCommandHandler<>));

      // container.RegisterDecorator(typeof(ICommandHandler<>),
      //   typeof(EventPublisherCommandHandler<>));
      // container.RegisterDecorator(typeof(ICommandHandler<>),
      //   typeof(AuthorizeCommandHandler<>));

      container.Verify();
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      ChangeSettingCommandHandler handler
        = container.GetInstance<ChangeSettingCommandHandler>();

      const string id = "1";
      ChangeSettingCommand command = new ChangeSettingCommand(id, new { a = 1 });

      try
      {
        // TODO: el decorador no funciona porque el método es asíncrono
        CommandResult res = handler.HandleAsync(command).Result;
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"{ex}");
      }
    }
  }
}
