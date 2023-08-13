using System.Globalization;
using System.Text;

namespace BlackRevival.Common.Util;

public class StringUtil
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
        return StringUtil.GetTitleCase(text.ToLower());
    }

    public static string GetTitleCase<T>(T type) where T : Enum
    {
        TextInfo textInfo = StringUtil._textInfo;
        if (textInfo == null)
        {
            return null;
        }
        return textInfo.ToTitleCase(type.ToString());
    }
}