using core.domain.app.commands;
using Microsoft.AspNetCore.Http;

namespace sts.api
{
  internal class ApiAuthorizationContext : IAuthorizationContext
  {
    public ApiAuthorizationContext(IHttpContextAccessor context)
    {
      this.Client = "sts-api";
      this._context = context;
    }

    private readonly IHttpContextAccessor _context;

    public string Client { get; }

    public string Username
    {
      get
      {
        return this._context.HttpContext.User.Identity.Name;
      }
    }

    public string[] UserRoles
    {
      get
      {
        return new string[] { };
      }
    }
  }
}
