using BlackRevival.Common.GameDB.Signature;
using BlackRevival.Common.Model.AcE;

public static class SignatureDataListExtension
{
    public static List<SignatureData> GetCharacterMatch(this List<SignatureData> dataList, AcE_CharacterClass characterClass)
    {
        return dataList.GetCharacterMatch((int)characterClass);
    }

    public static List<SignatureData> GetCharacterMatch(this List<SignatureData> dataList, int characterCode)
    {
        return dataList.FindAll((SignatureData x) => x.characterClass == characterCode);
    }

    public static List<SignatureData> GetStateMatch(this List<SignatureData> dataList, AcE_SignatureStateType stateType)
    {
        return dataList.FindAll((SignatureData x) => x.signatureStateType == stateType);
    }

    public static List<SignatureData> GetTypeMatch(this List<SignatureData> dataList, AcE_SignatureType signatureType)
    {
        return dataList.FindAll((SignatureData x) => x.signatureType == signatureType);
    }
}