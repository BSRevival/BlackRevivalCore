using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model.Labyrinth;

public class LabyrinthData
{
    /*
    [JsonIgnore]
    public AcPvEGameData p_pveGameData
    {
        get
        {
            AcPvEGameData result;
            if ((result = this.pveGameData) == null)
            {
                result = (this.pveGameData = this.DeserializePvEGameData());
            }
            return result;
        }
    }

    private AcPvEGameData DeserializePvEGameData()
    {
        if (string.IsNullOrEmpty(this.data))
        {
            Serilog.Log.Error("data is Null or Empty");
            return null;
        }
        AcPvEGameData acPvEGameData = JsonConvert.DeserializeObject<AcPvEGameData>(this.data);
        if (acPvEGameData == null)
        {
            Serilog.Log.Error("pveGameData is Null");
        }
        return acPvEGameData;
    }

    public AcE_EXPEDITION_DIFFICULTY GetExpeditionDifficulty()
    {
        return this.p_pveGameData.difficulty;
    }

    public CharacterClassData GetEnterCharacter()
    {
        if (this.p_pveGameData == null || this.p_pveGameData.characters == null || this.p_pveGameData.characters.Count == 0)
        {
            return null;
        }
        AcPvEGameData.PvECharacterData pvECharacterData = this.p_pveGameData.characters.Find((AcPvEGameData.PvECharacterData x) => x != null && x.curHp > 0f);
        if (pvECharacterData == null)
        {
            return null;
        }
        return GameDB.character.Find(pvECharacterData.unitClass);
    }

    public int GetExpeditionDateCount()
    {
        return this.p_pveGameData.survivalDay;
    }

    [JsonPropertyName("unm")]
    public readonly long UserNum;

    [JsonPropertyName("rky")]
    public readonly string roomKey;

    [JsonPropertyName("dat")]
    public readonly string data;

    [JsonPropertyName("cdtm")]
    public readonly long updateDtm;

    [JsonPropertyName("edtm")]
    public readonly long expiredDtm;

    [JsonIgnore]
    private AcPvEGameData pveGameData;
    */
}

