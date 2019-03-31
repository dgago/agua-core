using System;
using System.Collections;

namespace core.domain.extensions
{
  public static class ValidationExtensions
  {
    public static void Exists(this object arg, string name, string id = null)
    {
      if (arg == null)
      {
        string idm = id.IsNows() ? "" : $" con identificador {id}";
        throw new ArgumentException($"El item {name}{idm} no existe.");
      }
    }

    public static IList NotEmpty(this IList arg, string name)
    {
      if (arg == null)
      {
        throw new ArgumentException($"El valor de {name} debe ser especificado.");
      }

      if (arg.Count == 0)
      {
        throw new ArgumentException($"La lista {name} no puede estar vacía.");
      }

      return arg;
    }

    public static T NotNull<T>(this T arg, string name)
    {
      if (arg == null)
      {
        throw new ArgumentException($"El valor de {name} debe ser especificado.");
      }

      return arg;
    }

    public static string NotNull(this string arg, string name)
    {
      if (arg.IsNows())
      {
        throw new ArgumentException($"El valor de {name} debe ser especificado.");
      }

      return arg;
    }

    public static uint NotZero(this uint arg, string name)
    {
      if (arg == 0)
      {
        throw new ArgumentException($"El valor de {name} debe ser distinto de cero.");
      }

      return arg;
    }

    public static int NotZero(this int arg, string name)
    {
      if (arg == 0)
      {
        throw new ArgumentException($"El valor de {name} debe ser distinto de cero.");
      }

      return arg;
    }

    public static uint Zero(this uint arg, string name)
    {
      if (arg != 0)
      {
        throw new ArgumentException($"El valor de {name} debe ser igual a cero.");
      }

      return arg;
    }

    public static int Zero(this int arg, string name)
    {
      if (arg != 0)
      {
        throw new ArgumentException($"El valor de {name} debe ser igual a cero.");
      }

      return arg;
    }
  }
}
