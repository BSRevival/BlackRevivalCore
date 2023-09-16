using Serilog;

namespace BlackRevival.Common.Util;

public class AcEnum
{
	public static bool IsDefined<T>(T type)
	{
		return Enum.IsDefined(typeof(T), type);
	}

	public static bool IsDefined<T>(string type)
	{
		return Enum.IsDefined(typeof(T), type);
	}

	public static bool IsDefinedAllCase<T>(string type)
	{
		return AcEnum.IsDefined<T>(type) || AcEnum.IsDefined<T>(type.ToUpper()) || AcEnum.IsDefined<T>(type.ToLower()) || AcEnum.IsDefined<T>(StringUtils.GetTitleCase(type.ToLower()));
	}

	public static bool IsDefinedInt<T>(int num)
	{
		return Enum.IsDefined(typeof(T), num);
	}

	public static bool IsDefinedInt<T>(int num, out T type)
	{
		type = default(T);
		if (AcEnum.IsDefinedInt<T>(num))
		{
			type = AcEnum.ConvertInt<T>(num);
			return true;
		}
		return false;
	}

	public static List<T> GetValues<T>()
	{
		Array values = Enum.GetValues(typeof(T));
		if (values != null)
		{
			List<T> list = new List<T>();
			foreach (object obj in values)
			{
				T item = (T)((object)obj);
				list.Add(item);
			}
			return list;
		}
		return null;
	}

	public static T PrevValue<T>(T type)
	{
		List<T> values = AcEnum.GetValues<T>();
		int index = Math.Clamp(values.FindIndex((T x) => x.Equals(type)) - 1, 0, values.Count - 1);
		return values[index];
	}

	public static T NextValue<T>(T type)
	{
		List<T> values = AcEnum.GetValues<T>();
		int index = Math.Clamp(values.FindIndex((T x) => x.Equals(type)) + 1, 0, values.Count - 1);
		return values[index];
	}

	public static T Convert<T>(string type)
	{
		T result;
		try
		{
			result = (T)((object)Enum.Parse(typeof(T), type));
		}
		catch (Exception)
		{
			string format = "[ Fail the Enum Convert ] \"{0}\" is can't convert to the \"{1}\"";
			T t = default(T);
			Log.Error(string.Format(format, type, t.GetType()));
			t = default(T);
			result = t;
		}
		return result;
	}

	public static T ConvertAllCase<T>(string type)
	{
		T result;
		try
		{
			if (AcEnum.IsDefined<T>(type))
			{
				result = AcEnum.Convert<T>(type);
			}
			else
			{
				type = StringUtils.GetTitleCase(type.ToLower());
				if (AcEnum.IsDefined<T>(type))
				{
					result = AcEnum.Convert<T>(type);
				}
				else
				{
					type = type.ToUpper();
					if (AcEnum.IsDefined<T>(type))
					{
						result = AcEnum.Convert<T>(type);
					}
					else
					{
						T t = default(T);
						result = t;
					}
				}
			}
		}
		catch (Exception)
		{
			string format = "[ Fail the Enum Convert All Case ] \"{0}\" is can't convert to the \"{1}\"";
			object arg = type;
			T t = default(T);
			Log.Error(string.Format(format, arg, t.GetType()));
			t = default(T);
			result = t;
		}
		return result;
	}

	public static T ConvertInt<T>(int code)
	{
		T result;
		try
		{
			if (Enum.IsDefined(typeof(T), code))
			{
				return (T)((object)Enum.ToObject(typeof(T), code));
			}
		}
		catch (Exception)
		{
			string format = "[ Fail the Enum Convert int ] \"{0}\" is can't convert to the \"{1}\"";
			object arg = code;
			result = default(T);
			Log.Error(string.Format(format, arg, result.GetType()));
			result = default(T);
			return result;
		}
		result = default(T);
		return result;
	}

	public static bool TryGetValue<T>(int code, out T outType)
	{
		outType = default(T);
		if (AcEnum.IsDefinedInt<T>(code))
		{
			outType = AcEnum.ConvertInt<T>(code);
			return true;
		}
		return false;
	}

	public static bool TryGetValue<T>(string type, out T outType)
	{
		outType = default(T);
		if (AcEnum.IsDefined<T>(type))
		{
			outType = AcEnum.Convert<T>(type);
			return true;
		}
		return false;
	}

	public static bool TryGetValueAllCase<T>(string type, out T outType)
	{
		outType = default(T);
		if (AcEnum.IsDefined<T>(type))
		{
			outType = AcEnum.Convert<T>(type);
			return true;
		}
		type = StringUtils.GetTitleCase(type.ToLower());
		if (AcEnum.IsDefined<T>(type))
		{
			outType = AcEnum.Convert<T>(type);
			return true;
		}
		type = type.ToUpper();
		if (AcEnum.IsDefined<T>(type))
		{
			outType = AcEnum.Convert<T>(type);
			return true;
		}
		return false;
	}

	public static bool IsDefault<T>(T type)
	{
		return type.Equals(default(T));
	}
}