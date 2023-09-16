using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class LanternType
{
    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public string p_texture
    {
        get
        {
            return this._texture;
        }
    }

    public LanternType()
    {
    }

    public LanternType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] LanternType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("Texture", ref this._texture))
        {
            Log.Error("[DataLoad] LanternType - DataLoad Failed !!! -  Texture");
        }
    }

    private string _type = string.Empty;

    private string _texture = string.Empty;
}