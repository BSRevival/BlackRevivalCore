using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Character;

public class CharacterClassData
{
	[JsonIgnore]
	public string Name
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.Character("Name", (long)this.characterNum);
			}
			return "";
		}
	}

	[JsonIgnore]
	public string Code
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.Character("Code", (long)this.characterNum);
			}
			return "";
		}
	}

	[JsonIgnore]
	public string FullName
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.Character("FullName", (long)this.characterNum);
			}
			return "";
		}
	}

	[JsonIgnore]
	public string Story
	{
		get
		{
			return LocalizationDB.Instance.Character("Story", (long)this.characterNum);
		}
	}

	[JsonIgnore]
	public string Profile
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.Character("Char_Profile", (long)this.characterNum);
			}
			return "";
		}
	}

	[JsonIgnore]
	public string[] Guide_against
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.CharacterLongText("Guide_Against", (long)this.characterNum);
			}
			return null;
		}
	}

	[JsonIgnore]
	public string[] Guide_play
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.CharacterLongText("Guide_Play", (long)this.characterNum);
			}
			return null;
		}
	}

	[JsonIgnore]
	public string Title
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.CharacterTitle((long)this.characterNum);
			}
			return null;
		}
	}

	
	[JsonIgnore]
	public string GuideLink
	{
		get
		{
			if (this.characterNum != 0)
			{
				return LocalizationDB.Instance.Character("Guide_Link", (long)this.characterNum);
			}
			return string.Empty;
		}
	}

	[JsonIgnore]
	public AcE_CharacterClass CharacterClassType
	{
		get
		{
			return AcEnum.ConvertInt<AcE_CharacterClass>(this.characterNum);
		}
	}
    [JsonPropertyName("cod")]
    public int characterNum{ get; set; }

    [JsonPropertyName("cta")]
    public List<CharacterStat> ability{ get; set; }

    [JsonPropertyName("dcs")]
    public int defaultSkinCode{ get; set; }

    [JsonPropertyName("acs")]
    public List<int> skins{ get; set; }

    [JsonPropertyName("skil")]
    public List<int> skills{ get; set; }

    [JsonPropertyName("ist")]
    public int strategyType{ get; set; }

    [JsonPropertyName("rmt")]
    public List<AcE_WEAPON_TYPE> randomMasteryType{ get; set; }

}