namespace core.domain.extensions
{
  public static class StringExtensions
  {
    public static bool IsNows(this string arg)
    {
      return string.IsNullOrWhiteSpace(arg);
    }
  }
}
