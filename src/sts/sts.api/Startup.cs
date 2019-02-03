﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using core.domain.app;
using core.domain.data;
using core.domain.services;
using core.domain.services.accessControl;
using core.domain.services.log;
using core.domain.services.events;
using sts.domain.app.commands;
using sts.domain.data;
using sts.data;
using core.domain.app.commands;
using sts.domain.model.settings;

namespace sts.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services
        .AddSingleton<ILogAdapter, ConsoleLogAdapter>()
        .AddSingleton<IEventAdapter, ConsoleEventAdapter>()
        .AddSingleton<ISettingRepository, ConsoleSettingRepository>()
        .AddSingleton<IAccessControlConfig, ApiAccessControlConfig>()
        .AddSingleton<AccessControlDomainService>()
        .AddSingleton<IAuthorizationContext>(x => new ApiAuthorizationContext("sts-api"))
        .AddAuthorizedCommandHandler<ChangeSettingCommand, ChangeSettingCommandHandler, SettingRoot>()
        .AddAuthorizedCommandHandler<CreateSettingCommand, CreateSettingCommandHandler, SettingRoot>()
        .AddAuthorizedCommandHandler<RemoveSettingCommand, RemoveSettingCommandHandler, SettingRoot>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      // global exception handler
      app.UseExceptionHandler(errorApp =>
      {
        // handle
      });

      app.UseMvc();
    }
  }
}
