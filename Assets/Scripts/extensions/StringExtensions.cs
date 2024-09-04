namespace DefaultNamespace.extensions
{
  public static class StringExtensions
  {
    public static string Paint(this char value, string color) =>
      value.ToString().Paint(color);
    
    public static string Paint(this string value, string color) =>
      $"<color={color}>{value}</color>";
  }
}