using System.Text;
using System.Text.RegularExpressions;
using Serilog;

namespace BlackRevival.Common.GameDB.Localization;

public class Korean
{
    	public static string ReplaceJosa(string src)
	{
		try
		{
			return Korean._josa.Replace(src);
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
		}
		return src;
	}

	private static Korean.Josa _josa = new Korean.Josa();

	public class Josa
	{
		public string Replace(string src)
		{
			StringBuilder stringBuilder = new StringBuilder(src.Length);
			MatchCollection matchCollection = this._josaRegex.Matches(src);
			int num = 0;
			if (string.IsNullOrEmpty(src))
			{
				return "";
			}
			foreach (object obj in matchCollection)
			{
				Match match = (Match)obj;
				Korean.Josa.JosaPair josaPair = this._josaPatternPaird[match.Value];
				stringBuilder.Append(src, num, match.Index - num);
				if (match.Index > 0)
				{
					char c = src[match.Index - 1];
					int num2 = 1;
					while (c == ']')
					{
						while (c != '[')
						{
							num2++;
							if (match.Index - num2 < 0)
							{
								return src;
							}
							c = src[match.Index - num2];
						}
						if (c == '[')
						{
							num2++;
							if (match.Index - num2 < 0)
							{
								return src;
							}
							c = src[match.Index - num2];
						}
					}
					if ((Korean.Josa.HasJong(c) && match.Value != "(으)로") || (Korean.Josa.HasJongExceptRieul(c) && match.Value == "(으)로"))
					{
						stringBuilder.Append(josaPair.josa1);
					}
					else
					{
						stringBuilder.Append(josaPair.josa2);
					}
				}
				else
				{
					stringBuilder.Append(josaPair.josa1);
				}
				num = match.Index + match.Length;
			}
			stringBuilder.Append(src, num, src.Length - num);
			return stringBuilder.ToString();
		}

		private static bool HasJong(char inChar)
		{
			return inChar >= '가' && inChar <= '힣' && (inChar - '가') % '\u001c' > '\0';
		}

		private static bool HasJongExceptRieul(char inChar)
		{
			if (inChar >= '가' && inChar <= '힣')
			{
				int num = (int)((inChar - '가') % '\u001c');
				return num != 8 && num != 0;
			}
			return false;
		}

		private Regex _josaRegex = new Regex("\\(이\\)가|\\(와\\)과|\\(을\\)를|\\(은\\)는|\\(아\\)야|\\(이\\)야|\\(이\\)여|\\(으\\)로|\\(이\\)라");

		private Dictionary<string, Korean.Josa.JosaPair> _josaPatternPaird = new Dictionary<string, Korean.Josa.JosaPair>
		{
			{
				"(이)가",
				new Korean.Josa.JosaPair("이", "가")
			},
			{
				"(와)과",
				new Korean.Josa.JosaPair("과", "와")
			},
			{
				"(을)를",
				new Korean.Josa.JosaPair("을", "를")
			},
			{
				"(은)는",
				new Korean.Josa.JosaPair("은", "는")
			},
			{
				"(아)야",
				new Korean.Josa.JosaPair("아", "야")
			},
			{
				"(이)야",
				new Korean.Josa.JosaPair("이야", "야")
			},
			{
				"(이)여",
				new Korean.Josa.JosaPair("이여", "여")
			},
			{
				"(으)로",
				new Korean.Josa.JosaPair("으로", "로")
			},
			{
				"(이)라",
				new Korean.Josa.JosaPair("이라", "라")
			}
		};

		private class JosaPair
		{
			public JosaPair(string josa1, string josa2)
			{
				this.josa1 = josa1;
				this.josa2 = josa2;
			}

			public string josa1 { get; private set; }

			public string josa2 { get; private set; }
		}
	}
}