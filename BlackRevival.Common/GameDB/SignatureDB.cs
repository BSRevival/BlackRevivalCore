using BlackRevival.Common.GameDB.Signature;
using BlackRevival.Common.Model.AcE;
using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class SignatureDB
{
	public SignatureDB()
	{
		this.SignatureList = new List<SignatureData>();
		this.SignatureOptionTableList = new List<SignatureOptionTable>();
	}

	public SignatureDB(SignatureDB.Model data)
	{
		this.SignatureList = data.signatureList;
		this.SignatureOptionTableList = data.signatureOptionTableList;
	}

	public SignatureData Find(Predicate<SignatureData> match)
	{
		return this.SignatureList.Find(match);
	}

	public bool TryGetSignatureData(int characterClass, out List<SignatureData> signatureList)
	{
		signatureList = this.GetSignatureData(characterClass);
		return signatureList != null && signatureList.Count > 0;
	}

	public bool TryGetSignatureData(AcE_CharacterClass characterClass, out List<SignatureData> signatureList)
	{
		signatureList = this.GetSignatureData((int)characterClass);
		return signatureList != null;
	}

	public List<SignatureData> GetSignatureData(int characterClass)
	{
		List<SignatureData> characterMatch = this.SignatureList.GetCharacterMatch(characterClass);
		if (characterMatch == null)
		{
			Log.Error(string.Format("{0} is Null || {1} = {2}", "outData", "characterClass", characterClass));
		}
		return characterMatch;
	}

	public bool TryGetSignatureData(string characterClass, string type, out SignatureData signatureData)
	{
		signatureData = null;
		AcE_CharacterClass characterClass2;
		AcE_SignatureType type2;
		if (AcEnum.TryGetValueAllCase<AcE_CharacterClass>(characterClass, out characterClass2) && AcEnum.TryGetValue<AcE_SignatureType>(type, out type2))
		{
			signatureData = this.GetSignatureData((int)characterClass2, type2);
		}
		return signatureData != null;
	}

	public bool TryGetSignatureData(int characterClass, AcE_SignatureType type, out SignatureData signatureData)
	{
		signatureData = this.GetSignatureData(characterClass, type);
		return signatureData != null;
	}

	public SignatureData GetSignatureData(int characterClass, AcE_SignatureType type)
	{
		List<SignatureData> signatureData = this.GetSignatureData(characterClass);
		SignatureData signatureData2 = ((signatureData != null) ? signatureData.Find((SignatureData x) => x.signatureType == type) : null);
		if (signatureData2 == null)
		{
			Log.Error(string.Format("{0} is Null || {1} = {2} || {3} = {4}", new object[] { "outData", "characterClass", characterClass, "type", type }));
		}
		return signatureData2;
	}

	public bool TryGetSignatureData(string subType, out SignatureData signatureData)
	{
		signatureData = this.GetSignatureData(subType);
		return signatureData != null;
	}

	public SignatureData GetSignatureData(string subType)
	{
		SignatureData signatureData = this.SignatureList.Find((SignatureData x) => x.goodsSubType == subType);
		if (signatureData == null)
		{
			Log.Error("outData is Null || subType = " + subType);
		}
		return signatureData;
	}

	public bool TryGetSignatureData(AcE_SignatureStateType stateType, out List<SignatureData> signatureList)
	{
		signatureList = this.GetSignatureData(stateType);
		return signatureList != null;
	}

	public List<SignatureData> GetSignatureData(AcE_SignatureStateType stateType)
	{
		List<SignatureData> stateMatch = this.SignatureList.GetStateMatch(stateType);
		if (stateMatch == null)
		{
			Log.Error(string.Format("{0} is Null || {1} = {2}", "outData", "stateType", stateType));
		}
		return stateMatch;
	}

	public bool TryGetSignatureData(AcE_SignatureType signatureType, out List<SignatureData> signatureList)
	{
		signatureList = this.GetSignatureData(signatureType);
		return signatureList != null;
	}

	public List<SignatureData> GetSignatureData(AcE_SignatureType signatureType)
	{
		List<SignatureData> typeMatch = this.SignatureList.GetTypeMatch(signatureType);
		if (typeMatch == null)
		{
			Log.Error(string.Format("{0} is Null || {1} = {2}", "outData", "signatureType", signatureType));
		}
		return typeMatch;
	}

	public SignatureOptionTable FindTable(Predicate<SignatureOptionTable> match)
	{
		return this.SignatureOptionTableList.Find(match);
	}

	public bool TryGetOptionTable(AcE_SignatureType signatureType, int level, out SignatureOptionTable table)
	{
		table = this.GetOptionTable(signatureType, level);
		return table != null;
	}

	public SignatureOptionTable GetOptionTable(AcE_SignatureType signatureType, int level)
	{
		SignatureOptionTable signatureOptionTable = this.SignatureOptionTableList.Find((SignatureOptionTable x) => x.signatureType == signatureType && x.level == level);
		if (signatureOptionTable == null)
		{
			Log.Error(string.Format("{0} is Null || {1} = {2} || {3} = {4}", new object[] { "outData", "signatureType", signatureType, "level", level }));
		}
		return signatureOptionTable;
	}

	public List<SignatureData> SignatureList = new List<SignatureData>();

	public List<SignatureOptionTable> SignatureOptionTableList = new List<SignatureOptionTable>();

	public class Model
	{
		public List<SignatureData> signatureList { get; set; }

		public List<SignatureOptionTable> signatureOptionTableList { get; set; }
	}
}