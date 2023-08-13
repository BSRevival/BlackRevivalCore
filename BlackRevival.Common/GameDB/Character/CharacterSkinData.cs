using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.Character;

public class CharacterSkinData
{
	public int p_characterClass
	{
		get
		{
			return this._characterClass;
		}
	}

	public int p_skinCode
	{
		get
		{
			return this._skinCode;
		}
	}

	public bool p_defaultSkin
	{
		get
		{
			return this._defaultSkin;
		}
	}

	public int p_parentSkin
	{
		get
		{
			return this._parentSkin;
		}
	}

	public int p_ingamePivotX
	{
		get
		{
			return this._ingamePivotX;
		}
	}

	public int p_ingamePivotY
	{
		get
		{
			return this._ingamePivotY;
		}
	}

	public int p_ingameScaleX
	{
		get
		{
			return this._ingameScaleX;
		}
	}

	public bool p_existLive2D
	{
		get
		{
			return this._existLive2D;
		}
	}

	public float p_live2DX
	{
		get
		{
			return this._live2DX;
		}
	}

	public float p_live2DY
	{
		get
		{
			return this._live2DY;
		}
	}

	public float p_live2DScale
	{
		get
		{
			return this._live2DScale;
		}
	}

	public float p_charFullPivotX
	{
		get
		{
			return this._charFullPivotX;
		}
	}

	public float p_charFullPivotY
	{
		get
		{
			return this._charFullPivotY;
		}
	}

	public CharacterSkinData.AcE_GRADE p_grade
	{
		get
		{
			return this._grade;
		}
	}

	public CharacterSkinData.AcE_GRADE p_gradeLive2D
	{
		get
		{
			return this._gradeLive2D;
		}
	}

	public DateTime p_startDate
	{
		get
		{
			return this._startDate;
		}
	}

	public CharacterSkinData()
	{
	}

	public CharacterSkinData(AcXmlNode rootNode)
	{
		if (!rootNode.GetAttr("SkinCode", ref this._skinCode))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  SkinCode");
		}
		string empty = string.Empty;
		if (!rootNode.GetAttr("CharacterType", ref empty))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  CharacterType");
		}
		else
		{
			AcE_CharacterClass characterClass = AcEnum.Convert<AcE_CharacterClass>(empty);
			this._characterClass = (int)characterClass;
		}
		if (!rootNode.GetAttr("DefaultSkin", ref this._defaultSkin))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  DefaultSkin");
		}
		if (!rootNode.GetAttr("IngamePivotX", ref this._ingamePivotX))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  IngamePivotX");
		}
		if (!rootNode.GetAttr("IngamePivotY", ref this._ingamePivotY))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  IngamePivotY");
		}
		if (!rootNode.GetAttr("IngameScale", ref this._ingameScaleX))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  IngameScale");
		}
		if (!rootNode.GetAttr("CharFullPivotX", ref this._charFullPivotX))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  CharFullPivotX");
		}
		if (!rootNode.GetAttr("CharFullPivotY", ref this._charFullPivotY))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  CharFullPivotY");
		}
		if (!rootNode.GetAttr("ParentSkinKey", ref this._parentSkin))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  ParentSkinKey");
		}
		if (!rootNode.GetAttr("ExistLive2D", ref this._existLive2D))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  ExistLive2D");
		}
		if (!rootNode.GetAttr("Live2DX", ref this._live2DX))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  Live2DX");
		}
		if (!rootNode.GetAttr("Live2DY", ref this._live2DY))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  Live2DY");
		}
		if (!rootNode.GetAttr("Live2DScale", ref this._live2DScale))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  Live2DScale");
		}
		if (!rootNode.GetAttr<CharacterSkinData.AcE_GRADE>("Grade", ref this._grade))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  Grade || SkinCode - " + this._skinCode);
		}
		if (!rootNode.GetAttr<CharacterSkinData.AcE_GRADE>("Grade_Live2D", ref this._gradeLive2D))
		{
			Log.Error("[DataLoad] CharacterSkinData - DataLoad Failed !!! -  Grade_Live2D || SkinCode - " + this._skinCode);
		}
		if (rootNode.GetAttr("StartDate", ref this._startDate))
		{
			Log.Information(string.Format("[DataLoad] CharacterSkinData - DataLoad Catch StartDate - {0} || SkinCode - {1}", this._startDate, this._skinCode));
		}
	}

	private int _characterClass;

	private int _skinCode;

	private bool _defaultSkin;

	private int _parentSkin;

	private int _ingamePivotX;

	private int _ingamePivotY;

	private int _ingameScaleX;

	private bool _existLive2D;

	private float _live2DX;

	private float _live2DY;

	private float _live2DScale;

	private float _charFullPivotX;

	private float _charFullPivotY;

	private CharacterSkinData.AcE_GRADE _grade = CharacterSkinData.AcE_GRADE.Common;

	private CharacterSkinData.AcE_GRADE _gradeLive2D = CharacterSkinData.AcE_GRADE.Common;

	private DateTime _startDate;

	public enum AcE_GRADE
	{
		None,
		Common,
		Uncommon,
		Rare,
		Epic,
		Legend
	}
}