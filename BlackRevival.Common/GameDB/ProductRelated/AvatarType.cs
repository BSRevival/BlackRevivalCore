using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class AvatarType
{
    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public int p_code
    {
        get
        {
            return this._code;
        }
    }

    public string p_texture
    {
        get
        {
            return this._texture;
        }
    }

    public float p_x
    {
        get
        {
            return this._x;
        }
    }

    public float p_y
    {
        get
        {
            return this._y;
        }
    }

    public AcE_AvatarEffectType p_effectType
    {
        get
        {
            return this._effectEffectType;
        }
    }

    public AvatarType()
    {
    }

    public AvatarType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("AvatarType", ref this._type))
        {
            Log.Error("[DataLoad] AvatarType - DataLoad Failed !!! -  AvatarType");
        }
        if (!rootNode.GetAttr("Code", ref this._code))
        {
            Log.Error("[DataLoad] AvatarType - DataLoad Failed !!! -  Code");
        }
        if (!rootNode.GetAttr("Texture", ref this._texture))
        {
            Log.Error("[DataLoad] AvatarType - DataLoad Failed !!! -  Texture");
        }
        if (!rootNode.GetAttr("X", ref this._x))
        {
            Log.Error("[DataLoad] AvatarType - DataLoad Failed !!! -  X");
        }
        if (!rootNode.GetAttr("Y", ref this._y))
        {
            Log.Error("[DataLoad] AvatarType - DataLoad Failed !!! -  Y");
        }
        if (!rootNode.GetAttr<AcE_AvatarEffectType>("EffectType", ref this._effectEffectType))
        {
            this._effectEffectType = AcE_AvatarEffectType.NONE;
        }
    }

    private string _type = string.Empty;

    private int _code;

    private string _texture = string.Empty;

    private float _x;

    private float _y;

    private AcE_AvatarEffectType _effectEffectType;
}