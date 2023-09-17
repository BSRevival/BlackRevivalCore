using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Localization;
using BlackRevival.Common.Model;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class LocalizationDB
{
	
	public static LocalizationDB Instance { get; private set; }
	
    public LocalizationDB(SupportLanguage language, Model data)
    {
        this.localData = new Dictionary<string, string>();
        this.Language = language;
        this.voiceLanguage = language;
        this.LoadDB(this.Language, data.rawData);
    }
    
    public void LoadDB(SupportLanguage language, List<LocalizationDataRawData> data)
    {
        this.Language = language;
        int num = language - SupportLanguage.Korean;
        for (int i = 0; i < data.Count; i++)
        {
            try
            {
                if (!_tempStartTextList.Contains(data[i].key))
                {
                    if (localData.ContainsKey(data[i].key))
                    {
                        Log.Error("[LocalizationDB] ERROR - It has the same name key = {0}", new object[] { data[i].key });
                    }
                    else
                    {
                        localData.Add(data[i].key, data[i].value[num]);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("[LocalizationDB] ERROR key = {0}", new object[] { data[i].key });
                Log.Error(ex.Message);
            }
        }
        isGameTextLoadComplete = true;
    }
    private string LoadText(string text)
    {
	    if (!localData.ContainsKey(text))
	    {
		    return string.Empty;
	    }
	    return localData[text];
    }
    public string FindProgressiveData(string path, string subpath, string key, params object[] args)
	{
		string text = string.Format("{0}/{1}/{2}", path, subpath, key);
		if (!localData.ContainsKey(text))
		{
			Log.Debug("[LocalizationDB] Failed to find string {0}/{1}/{2}", new object[] { path, subpath, key });
			return "";
		}
		if (args != null)
		{
			try
			{
				return string.Format(LoadText(text), args);
			}
			catch (Exception)
			{
				return LoadText(text);
			}
		}
		return LoadText(text);
	}

	public string Dynamic(string text)
	{
		if (!localData.ContainsKey(text))
		{
			Log.Error("[LocalizationDB] " + text);
			return text;
		}
		return LoadText(text);
	}

	public string FindKey(string text)
	{
		List<string> list = localData.Keys.ToList<string>();
		if (list.Exists((string x) => x.Contains(text)))
		{
			return list.Find((string x) => x.Contains(text));
		}
		return string.Empty;
	}

	public string IgnoreDynamic(string text)
	{
		if (!localData.ContainsKey(text))
		{
			return string.Empty;
		}
		return LoadText(text);
	}

	public string Label(string text)
	{
		if (!localData.ContainsKey(text))
		{
			Log.Error("[LocalizationDB] " + text);
			return text;
		}
		return LoadText(text);
	}

	public string StringFormat(string key, params object[] args)
	{
		if (!localData.ContainsKey(key))
		{
			Log.Error("[LocalizationDB] " + key);
			return Korean.ReplaceJosa(key);
		}
		if (args != null)
		{
			try
			{
				return Korean.ReplaceJosa(string.Format(LoadText(key), args));
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				return Korean.ReplaceJosa(LoadText(key));
			}
		}
		return Korean.ReplaceJosa(LoadText(key));
	}

	public string ParsingString(string orgString, string startString, string endString)
	{
		int num = orgString.IndexOf(startString) + startString.Length;
		int num2 = orgString.IndexOf(endString) + endString.Length;
		return orgString.Substring(num, num2 - num);
	}

	public string DeadReason(string path, string key)
	{
		return FindProgressiveData("dead_reason", path, key, null);
	}

	public string Character(string path, long key)
	{
		return FindProgressiveData("Character", path, key.ToString("D3"), Array.Empty<object>());
	}

	public string[] CharacterLongText(string path, long key)
	{
		return FindProgressiveData("Character", path, key.ToString("D3"), Array.Empty<object>()).Split(new char[] { '_' });
	}

	public string CharacterTitle(long key)
	{
		return FindProgressiveData("Character", "Title", key.ToString("D3"), Array.Empty<object>());
	}
	private bool NeedConvertLanguage()
	{
		SupportLanguage supportLanguage = Language;
		return supportLanguage - SupportLanguage.Japanese <= 1;
	}
	public string SkillName(int skillCode)
	{
		string text = Dynamic(string.Format("Skill_Name/{0}", skillCode));
		if (!NeedConvertLanguage())
		{
			return text;
		}
		return text.Replace("※", "");
	}

	public string SkillIgnoreName(int skillCode)
	{
		string text = IgnoreDynamic(string.Format("Skill_Name/{0}", skillCode));
		if (!NeedConvertLanguage())
		{
			return text;
		}
		return text.Replace("※", "");
	}

	public string CaseByCaseSkillName(int skillCode)
	{
		string text = Dynamic(string.Format("Skill_Name/{0}", skillCode));
		if (!NeedConvertLanguage())
		{
			return text;
		}
		return text.Replace("※", "\n");
	}

	public string SkillDesc(int skillCode)
	{
		return IgnoreDynamic(string.Format("Skill_Desc/{0}", skillCode));
	}

	public string SkillDescAdd(int skillCode)
	{
		return IgnoreDynamic(string.Format("Skill_Desc_Add/{0}", skillCode));
	}

	public string SkillBroadcastDesc(int skillCode)
	{
		return IgnoreDynamic(string.Format("Skill_Broadcast_Desc_Add/{0}", skillCode));
	}

	public string SkillActionLog(int skillCode)
	{
		return IgnoreDynamic(string.Format("Skill/ActionLog/{0}", skillCode));
	}

	public string CharacterSkinName(int skin)
	{
		return FindProgressiveData("Concept", "Skin_Name", string.Format("{0:00000}", skin), Array.Empty<object>());
	}

	public string CharacterSkinSlotName(int skin)
	{
		return FindProgressiveData("Concept", "Skin_SlotName", string.Format("{0:00000}", skin), Array.Empty<object>());
	}

	public string CharacterMatchingName(int skin)
	{
		return FindProgressiveData("Concept", "Skin_Matching_Name", string.Format("{0:00000}", skin), Array.Empty<object>());
	}

	public string Monster(string path, int key)
	{
		string path2 = "Concept";
		MonsterClass monsterClass = (MonsterClass)key;
		return FindProgressiveData(path2, path, monsterClass.ToString(), Array.Empty<object>());
	}

	public string MonsterName(int monsterClass)
	{
		string path = "Concept";
		string subpath = "Monster_Name";
		MonsterClass monsterClass2 = (MonsterClass)monsterClass;
		return FindProgressiveData(path, subpath, monsterClass2.ToString(), Array.Empty<object>());
	}

	public string MonsterWatchEvent(int monsterClass)
	{
		string path = "Game_Event";
		string subpath = "Monster_WatchWord";
		MonsterClass monsterClass2 = (MonsterClass)monsterClass;
		return FindProgressiveData(path, subpath, monsterClass2.ToString(), Array.Empty<object>());
	}

	public string MonsterWeaponName(MonsterWeaponType type)
	{
		if (type != MonsterWeaponType.None)
		{
			return FindProgressiveData("Game_Event", "Monster", type.ToString(), Array.Empty<object>());
		}
		return Dynamic("Lobby_LUI/Common/None");
	}

	public string FieldName(int code)
	{
		string path = "Concept";
		string subpath = "Map_Name";
		FieldType fieldType = (FieldType)code;
		return FindProgressiveData(path, subpath, fieldType.ToString(), Array.Empty<object>());
	}

	public string NaviFieldName(int code)
	{
		string path = "Concept";
		string subpath = "Navi_Name";
		FieldType fieldType = (FieldType)code;
		return FindProgressiveData(path, subpath, fieldType.ToString(), Array.Empty<object>());
	}

	public string LeagueName(int code)
	{
		League league = (League)code;
		string text = league.ToString();
		return FindProgressiveData("Lobby_LUI", "League", text.Substring(0, text.Length - 1), Array.Empty<object>()) + text.Substring(text.Length - 1);
	}

	public string BattleActionLogger(FlushActionLogSequence seq, object key, params object[] prm)
	{
		string text = FindProgressiveData("actionlog", (seq == FlushActionLogSequence.UsePassive) ? "skill_passive" : "skill_field", key.ToString(), prm);
		if (!string.IsNullOrEmpty(text))
		{
			return Korean.ReplaceJosa(text);
		}
		return string.Empty;
	}

	public string ItemName(int itemCode)
	{
		if (itemCode == 0)
		{
			return "";
		}
		string text = Dynamic(string.Format("Item/Name/{0}", itemCode));
		if (Language != SupportLanguage.Japanese)
		{
			return text;
		}
		return text.Replace("※", "");
	}

	public string DicItemName(int itemCode)
	{
		if (itemCode == 0)
		{
			return "";
		}
		string text = Dynamic(string.Format("Item/Name/{0}", itemCode));
		if (Language != SupportLanguage.Japanese)
		{
			return text;
		}
		return text.Replace("※", "\n");
	}

	public string ItemDesc(int itemCode)
	{
		if (itemCode != 0)
		{
			return Dynamic(string.Format("Item/Desc/{0}", itemCode));
		}
		return "";
	}

	public string ItemConditionDesc(int itemCode)
	{
		if (itemCode != 0)
		{
			return Dynamic(string.Format("Item_EvolutionCondition/{0}", itemCode));
		}
		return string.Empty;
	}

	public string MailCreateTime(string key)
	{
		return Dynamic(string.Format("Lobby_LUI/Mail/{0}", "Arrived_" + key));
	}

	public string MailExpireTime(string key)
	{
		return Dynamic(string.Format("Lobby_LUI/Mail/{0}", "Expired_" + key));
	}

	public string NadjaSpeech(string key, params object[] args)
	{
		return FindProgressiveData("lobby_nadja", "bubble", key, args);
	}

	public string DiscoverText(CharacterDB db, int characterNum)
	{
		string code = db.Find(characterNum).Code;
		return FindProgressiveData("lobby_scenario", "discover", "getrecord", new object[] { code });
	}

	public string RewardBoxText(int box_count)
	{
		return FindProgressiveData("lobby_scenario", "reward", "box", new object[] { box_count });
	}

	public List<string> GetScenarioSelect(string select_menu)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(select_menu))
		{
			return new List<string>();
		}
		for (int i = 0; i <= 10; i++)
		{
			string key = string.Format("select_{0}", i);
			string text = FindProgressiveData("lobby_scenario", select_menu, key, null);
			if (string.IsNullOrEmpty(text))
			{
				break;
			}
			list.Add(text);
		}
		if (list.Count == 0)
		{
			return new List<string>();
		}
		return list;
	}

	public List<string> GetRuleBookTitles(int selectNumber)
	{
		return GetRuleBookText("title", selectNumber);
	}

	public List<string> GetRuleBookPages(int selectNumber)
	{
		return GetRuleBookText("page", selectNumber);
	}

	public List<string> GetRuleBookImages(int selectNumber)
	{
		int count = GetRuleBookTitles(selectNumber).Count;
		List<string> list = new List<string>();
		string arg = string.Empty;
		string arg2 = string.Empty;
		for (int i = 0; i <= count; i++)
		{
			arg = string.Format("select_{0}", selectNumber);
			arg2 = string.Format("set_{0}_image", i);
			string item = IgnoreDynamic(string.Format("scenario_faq/{0}/{1}", arg, arg2));
			list.Add(item);
		}
		return list;
	}

	private List<string> GetRuleBookText(string key, int selectNumber)
	{
		List<string> list = new List<string>();
		string subpath = string.Empty;
		string key2 = string.Empty;
		for (int i = 0; i <= 10; i++)
		{
			subpath = string.Format("select_{0}", selectNumber);
			key2 = string.Format("set_{0}_{1}", i, key);
			string text = FindProgressiveData("scenario_faq", subpath, key2, null);
			if (string.IsNullOrEmpty(text))
			{
				break;
			}
			list.Add(text);
		}
		return list;
	}

	public List<string> GetBackGroundStoryText(int selectNumber)
	{
		List<string> list = new List<string>();
		string subpath = string.Empty;
		string key = string.Empty;
		for (int i = 0; i <= 10; i++)
		{
			subpath = string.Format("select_{0}", selectNumber);
			key = string.Format("page_{0}", i);
			string text = FindProgressiveData("scenario_background", subpath, key, null);
			if (string.IsNullOrEmpty(text))
			{
				break;
			}
			list.Add(text);
		}
		return list;
	}

	public string ScenarioTitle(string menu_name)
	{
		return FindProgressiveData("lobby_scenario", "main_menu", menu_name, Array.Empty<object>());
	}

	public string RecordTitle(CharacterDairy.DiaryActionType type, params object[] args)
	{
		return Korean.ReplaceJosa(FindProgressiveData("character_record", "type", string.Format("{0}", (int)type), args));
	}

	public string GetCharacterContent(int char_id, AcE_RECORD_TYPE select_key)
	{
		string text = string.Empty;
		if (char_id == 0)
		{
			return text;
		}
		text = select_key.ToString().ToLower();
		return Dynamic(string.Format("character_record/{0}/{1}", char_id.ToString("D3"), text));
	}

	public string GetGuideText(int select_key)
	{
		string subpath = string.Format("select_{0}", select_key);
		return FindProgressiveData("scenario_beginner", subpath, "page", null);
	}

	public string GetNumberComma(int number)
	{
		return string.Format("{0:n0}", number);
	}
    public SupportLanguage Language;

    public SupportLanguage voiceLanguage;
    
    private bool isDBLoaded = false;

    public bool isMerging = false;

    public bool isGameTextLoadComplete = false;

    private List<string> _tempStartTextList = new List<string>();


    public Dictionary<string, string> localData { get; set; }= new Dictionary<string, string>();

    private const int CODE_NONE = 0;

    public const int MAX_READ_COUNT = 10;
    
    public class Model
    {
        public List<LocalizationDataRawData> rawData { get; set; }
    }
}