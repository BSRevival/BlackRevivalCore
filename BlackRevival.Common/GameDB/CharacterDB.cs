using System.Text.Json.Serialization;
using BlackRevival.Common.GameDB.Character;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class CharacterDB
{
	public CharacterDB()
	{
		this.characterClasses = new List<CharacterClassData>();
		this.characterDairy = new List<CharacterDiaryData>();
	}
	
	

	public CharacterDB(CharacterDB.Model model)
	{
		this.characterClasses = model.characters;
		this.characterDairy = model.characterDairy;
		this.DataLoad();
	}
	
	public void DataLoad()
	{
		AcXml acXml = new AcXml();
		if (acXml.Load("Data/Xmls/CharacterSkinData.xml", true))
		{
			acXml.GetAllChildData("CharacterSkinData", "SkinCode", "Skin_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				this.characterSkins.Add(new CharacterSkinData(item));
			});
		}
		if (acXml.Load("Data/Xmls/CharacterGradeData.xml", true))
		{
			acXml.GetAllChildData("CharacterGradeData", "Code", "Grade_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				this.characterGradeDatas.Add(new CharacterGradeData(item));
			});
		}
		foreach (CharacterSkinData characterSkinData in this.characterSkins)
		{
			if (characterSkinData.p_defaultSkin)
			{
				this.characterDefaultSkins.Add(characterSkinData);
			}
		}
	}

	
	public List<CharacterClassData> GetCharacterClassDataList()
	{
		return this.characterClasses;
	}

	public List<CharacterSkinData> GetCharacterSkinList()
	{
		return this.characterSkins;
	}

	public List<CharacterSkinData> GetCharacterDefaultSkinList()
	{
		return this.characterDefaultSkins;
	}
	
		public bool TryFind(AcE_CharacterClass classType, out CharacterClassData data)
	{
		return this.TryFind((int)classType, out data);
	}

	public bool TryFind(int characterCode, out CharacterClassData data)
	{
		data = this.Find(characterCode);
		return data != null;
	}

	public CharacterClassData Find(AcE_CharacterClass classType)
	{
		return this.Find((int)classType);
	}

	public CharacterClassData Find(int characterCode)
	{
		CharacterClassData characterClassData = this.characterClasses.Find((CharacterClassData data) => data.characterNum == characterCode);
		if (characterClassData == null)
		{
			Log.Error("[CharacterDB.Find data is null] characterCode = " + characterCode);
		}
		return characterClassData;
	}

	public CharacterClassData FindClassDataBySkinType(int skinType, bool showLog = true)
	{
		CharacterClassData characterClassData = this.characterClasses.Find((CharacterClassData data) => data.skins.Contains(skinType));
		if (characterClassData == null && showLog)
		{
			Log.Error("[CharacterDB.FindClassDataBySkinType data is null] skinType = " + skinType);
		}
		return characterClassData;
	}

	public List<CharacterSkinData> FindSkinDatas(int characterClass)
	{
		List<CharacterSkinData> list = this.characterSkins.FindAll((CharacterSkinData skin) => skin.p_characterClass == characterClass);
		if (list == null)
		{
			Log.Error("[CharacterDB.FindSkinDatas data is null] characterClass = " + characterClass);
		}
		return list;
	}

	public CharacterSkinData FindSkinData(int skinCode)
	{
		CharacterSkinData characterSkinData = this.characterSkins.Find((CharacterSkinData skin) => skin.p_skinCode == skinCode);
		if (characterSkinData == null)
		{
			Log.Error("[pivot data is null] skinCode = " + skinCode);
			return null;
		}
		return characterSkinData;
	}

	public CharacterSkinData FindDefaultSkinData(int characterClass)
	{
		if (this.characterDefaultSkins == null)
		{
			return null;
		}
		return this.characterDefaultSkins.Find((CharacterSkinData x) => x.p_characterClass == characterClass);
	}
	
	
	private  List<CharacterSkinData> characterSkins = new List<CharacterSkinData>();

	private  List<CharacterClassData> characterClasses;

	private  List<CharacterDiaryData> characterDairy { get; set; }

	private  List<CharacterGradeData> characterGradeDatas = new List<CharacterGradeData>();

	private  List<CharacterSkinData> characterDefaultSkins = new List<CharacterSkinData>();

	public class Model
	{
		public List<CharacterClassData> characters { get; set; }

		public List<CharacterSkinData> characterSkins { get; set; }

		public List<CharacterDiaryData> characterDairy { get; set; }

		public List<CharacterGradeData> characterGradeDatas { get; set; }
	}
}