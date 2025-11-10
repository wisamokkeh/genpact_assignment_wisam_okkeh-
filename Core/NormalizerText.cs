using System.Net;
using System.Text.RegularExpressions;

namespace AutomationWiki.Core
{
    public static class NormalizerText
    {
        public static string Normalize(string input)
        {
          if (string.IsNullOrWhiteSpace(input))
            return string.Empty;
                
          var decoded = WebUtility.HtmlDecode(input);

            decoded = Regex.Replace(
                decoded,
                "<!--.*?-->",
                " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            decoded = Regex.Replace(
                decoded,
                "<style.*?</style>",
                " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            decoded = Regex.Replace(
                decoded,
                "<script.*?</script>",
                " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            decoded = Regex.Replace(
                decoded,
                "<sup.*?</sup>",
                " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            decoded = Regex.Replace(
                decoded,
                "<ol class=\"references\".*?</ol>",
                " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase
            );

            decoded = Regex.Replace(decoded, "<.*?>", " ");

            decoded = decoded.ToLowerInvariant();

            decoded = Regex.Replace(decoded, @"[^a-z0-9\s]", " ");

            decoded = Regex.Replace(decoded, @"\s+", " ").Trim();

            return decoded;
        }

        public static int CountUniqeWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var text = input.Split([' ', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries);
            return text.Distinct().Count();

        }

    }
}