using System.Text.RegularExpressions;

namespace Pleiades.Core.Utils;

public partial class StringUtils {
  public static string OnlyNumbers(string input) {
    return OnlyNumbersRegex().Replace(input, "");
  }

  [GeneratedRegex(@"\D")]
  private static partial Regex OnlyNumbersRegex();
}
