using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.LevelTable;

public class LevelExpTableData
{
    public int GetRealStartExp(float exp)
    {
        return (int)MathF.Max(0f, exp - this.startExp);
    }

    public float GetNeed2NextLv()
    {
        return this.untilSameLv - this.startExp + 1f;
    }

    public float GetExpPercent(float exp)
    {
        return Math.Clamp((float)this.GetRealStartExp(exp) / this.GetNeed2NextLv(), 0f, 1f);
    }

    [JsonPropertyName("lv")]
    public int lv { get; set; }

    [JsonPropertyName("mtp")]
    public MapType mapType { get; set; }

    [JsonPropertyName("sxp")]
    public float startExp { get; set; }

    [JsonPropertyName("nnl")]
    public float need2NextLv { get; set; }

    [JsonPropertyName("usl")]
    public float untilSameLv { get; set; }

    [JsonPropertyName("hnx")]
    public bool hasNext { get; set; }
}