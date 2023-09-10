using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class QuestProgress
{
    [JsonPropertyName("qpid")]
    public long questProgressId{ get; set; }

    [JsonPropertyName("qd")]
    public int questId{ get; set; }

    [JsonPropertyName("pg")]
    public int progress{ get; set; }

    [JsonPropertyName("c")]
    public bool cleared{ get; set; }

    [JsonPropertyName("r")]
    public bool rewarded{ get; set; }

    [JsonPropertyName("rt")]
    public QuestRenewalType renewalType{ get; set; }

    [JsonPropertyName("ed")]
    public long expireDtm{ get; set; }
}