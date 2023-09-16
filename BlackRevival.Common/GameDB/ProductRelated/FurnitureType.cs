using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class FurnitureType
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

	public int p_panelNum
	{
		get
		{
			return this._panelNum;
		}
	}

	public BackgroundType p_backgroundType
	{
		get
		{
			return this._backgroundType;
		}
	}

	public int p_sortingOrder
	{
		get
		{
			return this._sortingOrder;
		}
	}

	public int p_x
	{
		get
		{
			return this._x;
		}
	}

	public int p_y
	{
		get
		{
			return this._y;
		}
	}

	public InteractType p_interactType
	{
		get
		{
			return this._interactType;
		}
	}

	public float p_interactPosX
	{
		get
		{
			return this._interactPosX;
		}
	}

	public float p_interactPosY
	{
		get
		{
			return this._interactPosY;
		}
	}

	public FurnitureType()
	{
	}

	public FurnitureType(AcXmlNode rootNode)
	{
		if (!rootNode.GetAttr("Code", ref this._code))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  Code");
		}
		if (!rootNode.GetAttr("Type", ref this._type))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  Type");
		}
		this._backgroundType = new BackgroundType(rootNode);
		if (!rootNode.GetAttr("PanelNum", ref this._panelNum))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  PanelNum");
		}
		if (!rootNode.GetAttr("SortingOrder", ref this._sortingOrder))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  SortingOrder");
		}
		if (!rootNode.GetAttr("X", ref this._x))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  X");
		}
		if (!rootNode.GetAttr("Y", ref this._y))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  Y");
		}
		string empty = string.Empty;
		if (!rootNode.GetAttr("InteractType", ref empty))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  InteractType");
		}
		else if (empty.Length > 0)
		{
			this._interactType = AcEnum.Convert<InteractType>(empty);
		}
		if (!rootNode.GetAttr("InteractPosX", ref this._interactPosX))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  InteractPosX");
		}
		if (!rootNode.GetAttr("InteractPosY", ref this._interactPosY))
		{
			Log.Error("[DataLoad] FurnitureType - DataLoad Failed !!! -  InteractPosY");
		}
	}

	private int _code;

	private string _type = string.Empty;

	private int _panelNum;

	private BackgroundType _backgroundType;

	private int _sortingOrder;

	private int _x;

	private int _y;

	private InteractType _interactType;

	private float _interactPosX;

	private float _interactPosY;

}