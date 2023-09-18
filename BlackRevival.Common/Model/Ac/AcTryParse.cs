using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using Serilog.Core;

namespace BlackRevival.Common.Model;

public class AcTryParse
{
    public static float AsFloat(string param)
    {
        float result = 0f;
        if (!float.TryParse(param, out result))
        {
            Log.Warning("Could not parse float. [{0}]", new object[]
            {
                param
            });
        }
        return result;
    }

    public static int AsInt(string param)
    {
        int result = 0;
        if (!int.TryParse(param, out result))
        {
            Log.Warning("Could not parse int. [{0}]", new object[]
            {
                param
            });
        }
        return result;
    }

    public static double AsDouble(string param)
    {
        double result = 0.0;
        if (!double.TryParse(param, out result))
        {
            Log.Warning("Could not parse double. [{0}]", new object[]
            {
                param
            });
        }
        return result;
    }

    public static bool AsBool(string param)
    {
        bool result = false;
        if (!bool.TryParse(param, out result))
        {
            Log.Warning("Could not parse bool. [{0}]", new object[]
            {
                param
            });
        }
        return result;
    }

    public static T AsEnum<T>(string param) where T : struct
    {
        T result = default(T);
        if (!Enum.TryParse<T>(param, out result))
        {
            Log.Warning("Could not parse Enum. [{0}]", new object[]
            {
                param
            });
        }
        return result;
    }

}
