using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class CharacterVoiceType
{
    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public string p_soundName
    {
        get
        {
            return this._soundName;
        }
    }

    public int p_skinCode
    {
        get
        {
            return this._skinCode;
        }
    }

    public CharacterVoiceType()
    {
    }

    public CharacterVoiceType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] CharacterVoiceType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("SoundName", ref this._soundName))
        {
            Log.Error("[DataLoad] CharacterVoiceType - DataLoad Failed !!! -  SoundName");
        }
        if (!rootNode.GetAttr("Code", ref this._skinCode))
        {
            Log.Error("[DataLoad] CharacterVoiceType - DataLoad Failed !!! -  Code");
        }
    }

    private string _type = string.Empty;

    private string _soundName = string.Empty;

    private int _skinCode;
}