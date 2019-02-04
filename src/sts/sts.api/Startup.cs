using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using core.domain.services.accessControl;
using core.domain.services.log;
using core.domain.services.events;
using sts.domain.app.commands;
using sts.data;
using core.domain.app.commands;
using sts.domain.model.settings;
using Microsoft.AspNetCore.Http;
using core.domain.data;
using sts.domain.data;

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
        .AddSingleton<IRepository<SettingRoot>, ConsoleSettingRepository>()
        .AddSingleton<ISettingRepository, ConsoleSettingRepository>()
        .AddSingleton<IAccessControlConfig, ApiAccessControlConfig>()
        .AddSingleton<AccessControlDomainService>()
        .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
        .AddScoped<IAuthorizationContext, ApiAuthorizationContext>()
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

      app.UseMvc();
    }
  }
}
