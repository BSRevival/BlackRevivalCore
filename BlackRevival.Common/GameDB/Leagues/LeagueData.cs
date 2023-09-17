using BlackRevival.Common.Model;
using BlackRevival.Common.Util;
using Serilog;
using System;

namespace BlackRevival.Common.GameDB.Leagues;

public class LeagueData
{

	public int p_code
	{
		get
		{
			return this._code;
		}
	}

	public LeagueType p_leagueType
	{
		get
		{
			return this._leagueType;
		}
	}

	public int p_leagueDownLimitt
	{
		get
		{
			return this._leagueDownLimitt;
		}
	}

	public int p_rankPointUpperLimit
	{
		get
		{
			return this._rankPointUpperLimit;
		}
	}

	public float p_winGoldReward
	{
		get
		{
			return this._winGoldReward;
		}
	}

	public LeagueTypeDetail p_leagueTypeDetail
	{
		get
		{
			return this._leagueTypeDetail;
		}
	}

	public LeagueBorder p_leagueBorder
	{
		get
		{
			return this._leagueBorder;
		}
	}

	public int p_leagueUpBonus
	{
		get
		{
			return this._leagueUpBonus;
		}
	}

	public int p_needUpgradePoint
	{
		get
		{
			return this._needUpgradePoint;
		}
	}

	public bool p_needUpgradeLeague
	{
		get
		{
			return this._needUpgradeLeague;
		}
	}

	public LeagueData()
	{
	}

	public LeagueData(AcXmlNode rootNode)
	{
		if (!rootNode.GetAttr("Code", ref this._code))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  Code");
		}
		string empty = string.Empty;
		if (!rootNode.GetAttr("LeagueType", ref empty))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  LeagueType");
		}
		else if (empty.Length > 0)
		{
			this._leagueType = AcEnum.Convert<LeagueType>(empty);
		}
		if (!rootNode.GetAttr("LeagueDownLimit", ref this._leagueDownLimitt))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  LeagueDownLimit");
		}
		if (!rootNode.GetAttr("RankPointUpperLimit", ref this._rankPointUpperLimit))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  RankPointUpperLimit");
		}
		if (!rootNode.GetAttr("WinGoldReward", ref this._winGoldReward))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  WinGoldReward");
		}
		empty = string.Empty;
		if (!rootNode.GetAttr("LeagueTypeDetail", ref empty))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  LeagueTypeDetail");
		}
		else if (empty.Length > 0)
		{
			this._leagueTypeDetail = AcEnum.Convert<LeagueTypeDetail>(empty);
		}
		empty = string.Empty;
		if (!rootNode.GetAttr("LeagueBorder", ref empty))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  LeagueBorder");
		}
		else if (empty.Length > 0)
		{
			this._leagueBorder = AcEnum.Convert<LeagueBorder>(empty);
		}
		if (!rootNode.GetAttr("LeagueUpPoint", ref this._leagueUpBonus))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  LeagueUpPoint");
		}
		if (!rootNode.GetAttr("NeedUpgradeLeague", ref this._needUpgradeLeague))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  NeedUpgradeLeague");
		}
		if (!rootNode.GetAttr("NeedUpgradePoint", ref this._needUpgradePoint))
		{
			Log.Error("[DataLoad] LeagueData - DataLoad Failed !!! -  NeedUpgradePoint");
		}
	}

	public string GetExpRange()
	{
		if (this.p_code == 0)
		{
			return string.Empty;
		}
		LeagueData leagueData = GameDB.LeagueDB.Instance.Find((League)(this.p_code - 1));
		int num = this.p_rankPointUpperLimit + 1;
		int num2 = 0;
		if (leagueData != null)
		{
			num2 = leagueData.p_rankPointUpperLimit + 1;
		}
		if (this.p_leagueType == LeagueType.CARNIVOROUS)
		{
			num2 -= 2549;
			num -= 2550;
		}
		if (this.p_code == 50)
		{
			return string.Format("{0} ~ MAX", num2);
		}
		return string.Format("{0} ~ {1}", num2, num);
	}

	public string GetLevelMarkSprite()
	{
		if (this.p_code == 0)
		{
			return string.Empty;
		}
		int num = this.p_code % 5;
		if (num == 0)
		{
			num = 5;
		}
		int num2 = -2 * num + 6;
		int num3 = num + num2;
		return string.Format("Common_Main_Leage_Loading_Result_Icon_number_{0:00}", num3);
	}

	public string name
	{
		get
		{
			if (this.p_code == 0)
			{
				return "????";
			}
			return LocalizationDB.Instance.LeagueName(this.p_code);
		}
	}

	public int UpperLimitPoint
	{
		get
		{
			int num = this.p_rankPointUpperLimit + 1;
			if (this.p_leagueType == LeagueType.CARNIVOROUS)
			{
				num -= 2549;
			}
			return num;
		}
	}

	public float GetWinGoldPercent()
	{
		return (float)((int)Math.Ceiling(this._winGoldReward * 100f));
	}

	private int _code;

	private LeagueType _leagueType;

	private int _leagueDownLimitt;

	private int _rankPointUpperLimit;

	private float _winGoldReward;

	private LeagueTypeDetail _leagueTypeDetail;

	private LeagueBorder _leagueBorder;

	private int _leagueUpBonus;

	private int _needUpgradePoint;

	private bool _needUpgradeLeague;
}