using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Expedition;


public class ExpeditionAreaData
{
    public string GetFieldName()
    {
        return LocalizationDB.Instance.Dynamic(string.Format("PVE_EXPEDITION_{0}_{1}_TITLE", this.code, this.district));
    }

    [JsonPropertyName("cod")]
    public int code { get; set; }

    [JsonPropertyName("dtr")]
    public int district { get; set; }

    [JsonPropertyName("dtp")]
    public int districtType { get; set; }

    [JsonPropertyName("mds")]
    public int maxDistance { get; set; }

    [JsonPropertyName("bvb")]
    public int baseVisibility { get; set; }

    [JsonPropertyName("ftp")]
    public int fieldType { get; set; }

    [JsonPropertyName("evl")]
    public List<ExpeditionAreaEventData> eventList { get; set; }

    [JsonPropertyName("sfi")]
    public bool sameFieldInfo { get; set; }

    [JsonPropertyName("fit")]
    public Dictionary<int, int> fixedItems { get; set; }
}