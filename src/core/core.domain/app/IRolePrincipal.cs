using System.Security.Principal;

namespace core.domain.app
{
  public interface IRolePrincipal : IPrincipal
  {

    string[] Roles { get; }

  }
}