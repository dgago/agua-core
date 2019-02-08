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
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;

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

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Title = "My API",
          Version = "v1",
          Description = "A simple example ASP.NET Core Web API",
          TermsOfService = "None",
          Contact = new Contact
          {
            Name = "Guada Fac",
            Email = string.Empty,
            Url = "https://twitter.com/gfac"
          },
          License = new License
          {
            Name = "Use under MIT license",
            Url = "https://example.com/license"
          }
        });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);

        File.WriteAllText(Path.Combine("R:\\me\\agua\\agua-core\\src\\sts\\sts.api", ".\\test.xml"), xmlPath);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(); // TODO: cual de los dos uso?
                          // app.UseSwagger(c =>
                          //   {
                          //     c.PreSerializeFilters.Add(
                          //       (swagger, httpReq) => swagger.Host = httpReq.Host.Value);
                          //   });

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
          // c.SwaggerEndpoint("./v1/swagger.json", "STS Api v1");
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "STS Api v1");
        });
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseStatusCodePages();
      app.UseMvc();
    }
  }
}
