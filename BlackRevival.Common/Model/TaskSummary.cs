using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.Model;

public class TaskSummary
{
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    // Token: 0x04005FBA RID: 24506
    [JsonPropertyName("tnm")]
    public int taskNum{ get; set; }

    // Token: 0x04005FBB RID: 24507
    [JsonPropertyName("anm")]
    public int actNum{ get; set; }

    // Token: 0x04005FBC RID: 24508
    [JsonPropertyName("atp")]
    public ActType actType{ get; set; }

    // Token: 0x04005FBD RID: 24509
    [JsonPropertyName("ptp")]
    public ActType startTermActType{ get; set; }

    // Token: 0x04005FBE RID: 24510
    [JsonPropertyName("ptn")]
    public int startTermTaskNum{ get; set; }

    // Token: 0x04005FBF RID: 24511
    [JsonPropertyName("pab")]
    public bool playable{ get; set; }

    // Token: 0x04005FC0 RID: 24512
    [JsonPropertyName("crd")]
    public bool cleared{ get; set; }

    // Token: 0x04005FC1 RID: 24513
    [JsonPropertyName("cct")]
    public int clearedCount{ get; set; }
}