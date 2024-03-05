using System.Text;

namespace CSharpDataStructures;

public class ReverseString
{
  public static string? manipulateString(string text)
  {
    if (String.IsNullOrEmpty(text)) return null;

    StringBuilder result = new StringBuilder();

    for (var i = text.Length - 1; i >= 0; i--)
    {
      result.Append(text[i]);
    }

    return result.ToString();

  }
}
