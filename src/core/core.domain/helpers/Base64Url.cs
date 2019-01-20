using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace core.domain.helpers
{

  internal static class Base64Url
  {
    public static string Encode(byte[] arg)
    {
      return Convert.ToBase64String(arg).Split('=')[0].Replace('+', '-').Replace('/', '_');
    }

    public static byte[] Decode(string arg)
    {
      string s = arg.Replace('-', '+').Replace('_', '/');
      switch (s.Length % 4)
      {
        case 0:
          return Convert.FromBase64String(s);
        case 2:
          s += "==";
          goto case 0;
        case 3:
          s += "=";
          goto case 0;
        default:
          throw new Exception("Illegal base64url string!");
      }
    }
  }
}