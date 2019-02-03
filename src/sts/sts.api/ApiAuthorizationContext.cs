using core.domain.app.commands;
using Microsoft.AspNetCore.Http;

namespace sts.api
{
  internal class ApiAuthorizationContext : IAuthorizationContext
  {
    internal ApiAuthorizationContext(string client)
    {
      this.Client = client;
    }

    internal ApiAuthorizationContext(string client, HttpContext context)
    {
      this.Client = client;
      this._context = context;
    }

    private readonly HttpContext _context;

    public string Client { get; }

    public string Username
    {
      get
      {
        return this._context.User.Identity.Name;
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
