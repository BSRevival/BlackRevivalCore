using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class MonologueType : AnnounceType
{
    public AcE_CharacterClass p_characterClass
    {
        get
        {
            return this._characterClass;
        }
    }

    public int p_characterSkinType
    {
        get
        {
            return this._characterSkinType;
        }
    }

    public MonologueType()
    {
    }

    public MonologueType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] MonologueType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("Texture", ref this._texture))
        {
            Log.Error("[DataLoad] MonologueType - DataLoad Failed !!! -  Texture");
        }
        string empty = string.Empty;
        if (!rootNode.GetAttr("CharacterClass", ref empty))
        {
            Log.Error("[DataLoad] MonologueType - DataLoad Failed !!! -  CharacterClass");
        }
        else if (empty.Length > 0)
        {
            this._characterClass = AcEnum.Convert<AcE_CharacterClass>(empty);
        }
        if (!rootNode.GetAttr("CharacterSkinType", ref this._characterSkinType))
        {
            Log.Error("[DataLoad] MonologueType - DataLoad Failed !!! -  CharacterSkinType");
        }
    }

    private AcE_CharacterClass _characterClass;

    private int _characterSkinType;
}