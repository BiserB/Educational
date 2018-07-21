using System;
using System.Text;

namespace BookLibrary.App.Auxiliary
{
    public static class StringExtensions
    {
        public static string EscapeIgnoreCase(this string source, string target, string prefix, string sufix)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
            {
                return source;
            }

            int targetLength = target.Length;

            var sb = new StringBuilder();

            string result = source;
            string remaining = source;

            int foundIndex = source.IndexOf(target, StringComparison.InvariantCultureIgnoreCase);
            int startIndex = 0;

            while (foundIndex >= 0)
            {
                if (foundIndex > 0)
                {
                    sb.Append(remaining.Substring(0, foundIndex));
                }

                sb.Append(prefix);
                sb.Append(remaining.Substring(foundIndex, targetLength));
                sb.Append(sufix);

                startIndex = foundIndex + targetLength;

                remaining = remaining.Substring(startIndex);

                foundIndex = remaining.IndexOf(target, StringComparison.InvariantCultureIgnoreCase);

                if (foundIndex < 0)
                {
                    sb.Append(remaining);
                }
            }

            if (sb.Length > 0)
            {
                result = sb.ToString();
            }

            return result;
        }
    }
}