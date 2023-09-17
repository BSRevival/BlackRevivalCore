using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.PVE;

public class AcPvEGlobalConstantDB
{
	public static AcPvEGlobalConstantDB Instance { get; private set; }
	
	public AcPvEGlobalConstantDB()
	{
		Load();
		Instance = this;
	}
    public void Load()
	{
		this._contantDataDic.Clear();
		this._globalLvEXPDataDic.Clear();
		AcXml acXml = new AcXml();
		if (acXml.Load("Data/Xmls/pve/PvEGlobalConstantData.xml", true))
		{
			acXml.GetAllChildData("PvEGlobalData", true).ForEach(delegate(AcXmlNode x)
			{
				if (x.p_xmlElement.Name.Contains("ConstantData"))
				{
					this.LoadData_Constant(x);
					return;
				}
				if (x.p_xmlElement.Name.Contains("GlobalLvData"))
				{
					this.LoadData_GlobalLevel(x);
				}
			});
		}
	}

	private void LoadData_Constant(AcXmlNode constantXml)
	{
		if (!constantXml.HasChild())
		{
			return;
		}
		constantXml.GetChilds().ForEach(delegate(AcXmlNode x)
		{
			AcPvEGlobalConstantDB.AcE_PVE_CONSTANT acE_PVE_CONSTANT = AcEnum.Convert<AcPvEGlobalConstantDB.AcE_PVE_CONSTANT>(x.p_xmlElement.Name);
			if (acE_PVE_CONSTANT == AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.NONE)
			{
				Log.Error("[AcPvEGlobalConstantDB.LoadData_Constant] Type is None");
				return;
			}
			float value = 0f;
			if (x.GetAttr("VALUE", ref value))
			{
				this._contantDataDic.Add(acE_PVE_CONSTANT, value);
				return;
			}
			Log.Error(string.Format("[AcPvEGlobalConstantDB.LoadData_Constant] VALUE is Not Exist => type {0}", acE_PVE_CONSTANT));
		});
	}

	private void LoadData_GlobalLevel(AcXmlNode globalLvDataXml)
	{
		if (!globalLvDataXml.HasChild())
		{
			return;
		}
		globalLvDataXml.GetChilds().ForEach(delegate(AcXmlNode x)
		{
			AcPvEGlobalEXPData acPvEGlobalEXPData = new AcPvEGlobalEXPData();
			if (!x.GetAttr("Level", ref acPvEGlobalEXPData.level))
			{
				Log.Error("[AcPvEGlobalEXPDB.LoadData_GlobalLevel] Level is Not Exist");
			}
			if (!x.GetAttr("StartExp", ref acPvEGlobalEXPData.startExp))
			{
				Log.Error("[AcPvEGlobalEXPDB.LoadData_GlobalLevel] StartExp is Not Exist");
			}
			if (!x.GetAttr("EndExp", ref acPvEGlobalEXPData.endExp))
			{
				Log.Error("[AcPvEGlobalEXPDB.LoadData_GlobalLevel] EndExp is Not Exist");
			}
			this._globalLvEXPDataDic.Add(acPvEGlobalEXPData.level, acPvEGlobalEXPData);
		});
	}

	public float FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT type)
	{
		if (this._contantDataDic == null || !this._contantDataDic.ContainsKey(type))
		{
			return 0f;
		}
		return this._contantDataDic[type];
	}

	public AcPvEGlobalEXPData FindGlobalLvEXPData(int level)
	{
		if (this._globalLvEXPDataDic == null || !this._globalLvEXPDataDic.ContainsKey(level))
		{
			return null;
		}
		return this._globalLvEXPDataDic[level];
	}

	public AcPvEGlobalEXPData FindGlobalLvEXPData_FromExp(int curExp)
	{
		if (this._globalLvEXPDataDic == null)
		{
			return null;
		}
		AcPvEGlobalEXPData acPvEGlobalEXPData = null;
		foreach (KeyValuePair<int, AcPvEGlobalEXPData> keyValuePair in this._globalLvEXPDataDic)
		{
			if (keyValuePair.Value.startExp <= curExp)
			{
				acPvEGlobalEXPData = keyValuePair.Value;
				if (curExp <= acPvEGlobalEXPData.endExp)
				{
					return acPvEGlobalEXPData;
				}
			}
		}
		return acPvEGlobalEXPData;
	}

	public int GetGlobalLv_FromExp(int curExp)
	{
		AcPvEGlobalEXPData acPvEGlobalEXPData = this.FindGlobalLvEXPData_FromExp(curExp);
		if (acPvEGlobalEXPData != null)
		{
			return acPvEGlobalEXPData.level;
		}
		return 1;
	}

	private Dictionary<AcPvEGlobalConstantDB.AcE_PVE_CONSTANT, float> _contantDataDic = new Dictionary<AcPvEGlobalConstantDB.AcE_PVE_CONSTANT, float>();

	private Dictionary<int, AcPvEGlobalEXPData> _globalLvEXPDataDic = new Dictionary<int, AcPvEGlobalEXPData>();

	public enum AcE_PVE_CONSTANT
	{
		NONE,
		SEARCH_COMPLETE_EXP,
		FIELD_COMPLETE_EXP,
		CHARACTER_LV_UP_EXP,
		KILL_ENEMY_EXP,
		DEAD_CHARACTER_EXP,
		EASY_EXP_RATE,
		NORMAL_EXP_RATE,
		HARD_EXP_RATE,
		MOVE_DELAY_UNIT,
		MOVE_DELAY_WILD_ANIMAL,
		MOVE_PROB_LV1,
		MOVE_PROB_LV2,
		MOVE_PROB_LV3,
		MOVE_PROB_LV4,
		MOVE_DIR_PROB_LV1,
		MOVE_DIR_PROB_LV2,
		MOVE_DIR_PROB_LV3,
		MOVE_DIR_PROB_LV4,
		MOVE_DISTANCE_MIN,
		MOVE_DISTANCE_MAX,
		WAIT_DELAY,
		ALERT_UNIT_NOISE,
		ALERT_WILD_ANIMAL_NOISE,
		ALERT_GUN_SHOT,
		MAX_WILD_ANIMAL,
		MAX_SUBJECT,
		NOISE_VALUE_NORMAL,
		NOISE_VALUE_FAST,
		ADD_NOISE_VALUE_NORMAL_LV1,
		ADD_NOISE_VALUE_NORMAL_LV2,
		ADD_NOISE_VALUE_NORMAL_LV3,
		ADD_NOISE_VALUE_NORMAL_LV4,
		ADD_NOISE_VALUE_FAST_LV1,
		ADD_NOISE_VALUE_FAST_LV2,
		ADD_NOISE_VALUE_FAST_LV3,
		ADD_NOISE_VALUE_FAST_LV4,
		RESTING_NOISE_VALUE_LV1,
		RESTING_NOISE_VALUE_LV2,
		RESTING_NOISE_VALUE_LV3,
		RESTING_NOISE_VALUE_LV4,
		ADD_WILD_ANIMAL_LV,
		ADD_SUBJECT_LV,
		ADD_WILD_ANIMAL_TIME,
		PREPARATION_TIME_DEFAULT,
		PREPARATION_TIME_GLOBAL_LV_RATE,
		PREPARATION_NORMAL_TIME,
		PREPARATION_HARD_TIME,
		PREPARATION_TIME_MIN,
		CREATE_ENEMY_LV_MIN,
		CREATE_ENEMY_LV_MAX,
		CREATE_ALLY_LV_MIN,
		CREATE_ALLY_LV_MAX,
		CREATE_BOSS_LV_EASY_MIN,
		CREATE_BOSS_LV_EASY_MAX,
		CREATE_BOSS_LV_NORMAL_MIN,
		CREATE_BOSS_LV_NORMAL_MAX,
		CREATE_BOSS_LV_HARD_MIN,
		CREATE_BOSS_LV_HARD_MAX,
		CREATE_NOISE_LV4_SUBJECT_ADD_LV,
		AI_CARD_SYNTHESIS_LV2,
		AI_CARD_SYNTHESIS_LV3,
		INVENTORY_BAG_CAPACITY,
		INVENTORY_WAREHOUSE_CAPACITY,
		EQUIP_IDX_EASY,
		EQUIP_IDX_NORMAL,
		EQUIP_IDX_HARD,
		EQUIP_IDX_EASY_START,
		EQUIP_IDX_NORMAL_START,
		EQUIP_IDX_HARD_START
	}
}