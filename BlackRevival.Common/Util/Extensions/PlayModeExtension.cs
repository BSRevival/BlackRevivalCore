using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB;
using BlackRevival.Common.Model;

public static class PlayModeExtension
{
	public static MapType GetMapType(this PlayMode playMode)
	{
		if (playMode.IsTeamMode())
		{
			return MapType.SEOUL;
		}
		if (playMode == PlayMode.NONE)
		{
			return MapType.NONE;
		}
		return MapType.LUMIA;
	}

	public static bool IsTeamMode(this PlayMode playMode)
	{
		if (playMode != PlayMode.TEAM)
		{
			return playMode == PlayMode.TEAM_PRIVATE;
		}
		return true;
	}

	public static bool IsQueueMatch(this PlayMode playMode)
	{
		switch (playMode)
		{
		case PlayMode.NORMAL:
		case PlayMode.RANK:
		case PlayMode.TEAM:
		case PlayMode.TOURNURMENT:
			return true;
		default:
			return false;
		}
	}

	public static string GetName(this PlayMode playMode)
	{
		return playMode switch
		{
			PlayMode.RANK => LocalizationDB.Instance.Dynamic("랭크대전"), 
			PlayMode.NORMAL => LocalizationDB.Instance.Dynamic("일반대전"), 
			PlayMode.HIDDEN => LocalizationDB.Instance.Dynamic("비공개대전"), 
			PlayMode.AI => LocalizationDB.Instance.Dynamic("싱글대전"), 
			PlayMode.TUTORIAL => LocalizationDB.Instance.Dynamic("시나리오모드"), 
			PlayMode.TEAM => LocalizationDB.Instance.Dynamic("팀 대전(beta)"), 
			PlayMode.TEAM_PRIVATE => LocalizationDB.Instance.Dynamic("SB_FM_029"), 
			PlayMode.TOURNURMENT => LocalizationDB.Instance.Dynamic("TOURNAMENT_01"), 
			PlayMode.LABYRINTH => LocalizationDB.Instance.Dynamic("PVE_START_TAB_NAME"), 
			_ => "", 
		};
	}

	public static bool IsNecessaryCheckingOwner(this PlayMode playMode)
	{
		if (playMode == PlayMode.HIDDEN || playMode == PlayMode.TEAM_PRIVATE)
		{
			return true;
		}
		return false;
	}

	public static bool IsNecessaryRoomKey(this PlayMode playMode)
	{
		switch (playMode)
		{
		case PlayMode.HIDDEN:
		case PlayMode.AI:
		case PlayMode.TEAM_PRIVATE:
		case PlayMode.TUTORIAL:
			return true;
		default:
			return false;
		}
	}

	public static bool IsAvailableBan(this PlayMode playMode)
	{
		if (playMode == PlayMode.HIDDEN || playMode == PlayMode.AI || playMode == PlayMode.TEAM_PRIVATE)
		{
			return true;
		}
		return false;
	}

	public static bool IsHideRoomKey(this PlayMode playMode)
	{
		if (playMode == PlayMode.AI || playMode == PlayMode.TUTORIAL)
		{
			return true;
		}
		return false;
	}

	public static bool IsExistDifficulty(this PlayMode playMode)
	{
		if (playMode == PlayMode.NORMAL || playMode == PlayMode.TEAM)
		{
			return true;
		}
		return false;
	}

	public static bool IsNecessaryEnterableStatus(this PlayMode playMode)
	{
		return false;
	}

	public static float GetSearchTimeScale(this PlayMode playMode)
	{
		return 0.9f;
	}

	public static float GetAttackTimeScale(this PlayMode playMode)
	{
		return 1.8f;
	}

	public static float GetHackingCastingTime(this PlayMode playMode)
	{
		if ((uint)(playMode - 40) <= 1u)
		{
			return 10f;
		}
		return 70f;
	}

	public static float GetHackingWarningTime(this PlayMode playMode, bool isNight)
	{
		if (!isNight)
		{
			return 0f;
		}
		return 35f;
	}

	public static string GetHackingWarningMessage(this PlayMode playMode, bool isNight)
	{
		if (isNight)
		{
			return "HackMsg1";
		}
		return "HackMsg2";
	}

	public static bool IsEnterableLeague(this PlayMode playMode, League userleague)
	{
		if (playMode == PlayMode.RANK)
		{
			if (userleague > League.ELEPHANT1)
			{
				return true;
			}
			return false;
		}
		return true;
	}
}