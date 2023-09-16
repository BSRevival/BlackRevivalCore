using System.Globalization;
using System.Text;

namespace BlackRevival.Common.Util;

public static class StringUtils
{
    private static readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;
    private static StringBuilder _stringBuilder = new StringBuilder();

    public static string p_stringBuilderText
    {
        get
        {
            return _stringBuilder.ToString();
        }
    }

    public static string GetTitleCase(string text)
    {
        TextInfo textInfo = _textInfo;
        if (textInfo == null)
        {
            return null;
        }
        return textInfo.ToTitleCase(text);
    }

    public static string GetForceTitleCase(string text)
    {
        return StringUtils.GetTitleCase(text.ToLower());
    }

    public static string GetTitleCase<T>(T type) where T : Enum
    {
        TextInfo textInfo = StringUtils._textInfo;
        if (textInfo == null)
        {
            return null;
        }
        return textInfo.ToTitleCase(type.ToString());
    }
    public static bool EqualsFast(this string content, string comparedString)
    {
        return content.Equals(comparedString, StringComparison.Ordinal);
    }

    public static bool EqualsFastIgnoreCase(this string content, string comparedString)
    {
        return content.Equals(comparedString, StringComparison.OrdinalIgnoreCase);
    }

    public static bool EndsWithFast(this string content, string match)
    {
        return content.EndsWith(match, StringComparison.Ordinal);
    }

    public static bool StartsWithFast(this string content, string match)
    {
        return content.StartsWith(match, StringComparison.Ordinal);
    }

    public static bool WrappedIn(this string content, string match, StringComparison comp = StringComparison.Ordinal)
    {
        return content.StartsWith(match, comp) && content.EndsWith(match, comp);
    }
}