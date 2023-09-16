using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class MatchingCardType
{
    public int p_code
    {
        get
        {
            return this._code;
        }
    }

    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public string p_backgroundType
    {
        get
        {
            return this._backgroundType;
        }
    }

    public MatchingCardType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Code", ref this._code))
        {
            Log.Error("[DataLoad] MatchingCardType - DataLoad Failed !!! -  Code");
        }
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] MatchingCardType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("BackgroundType", ref this._backgroundType))
        {
            Log.Error("[DataLoad] MatchingCardType - DataLoad Failed !!! -  BackgroundType");
        }
    }

    private readonly int _code;

    private readonly string _type;

    private readonly string _backgroundType;
}