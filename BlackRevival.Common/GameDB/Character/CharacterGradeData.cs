using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.Character;

public class CharacterGradeData
{
    public int p_code
    {
        get
        {
            return this._code;
        }
    }

    public int p_maxExp
    {
        get
        {
            return this._maxExp;
        }
    }

    public CharacterGrade characterGrade
    {
        get
        {
            CharacterGrade result = CharacterGrade.NONE;
            if (Enum.IsDefined(typeof(CharacterGrade), this._code))
            {
                result = (CharacterGrade)this._code;
            }
            return result;
        }
    }

    public CharacterGradeData()
    {
    }

    public CharacterGradeData(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Code", ref this._code))
        {
            Log.Error("[DataLoad] CharacterGradeData - DataLoad Failed !!! -  Code");
        }
        if (!rootNode.GetAttr("MaxExp", ref this._maxExp))
        {
            Log.Error("[DataLoad] CharacterGradeData - DataLoad Failed !!! -  MaxExp");
        }
    }

    private int _code;

    private int _maxExp;
}