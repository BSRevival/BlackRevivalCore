using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.APIServer.Database;

public class QuestProgress
{
    [JsonPropertyName("qpid")]
    public long QuestProgressId { get; set; }

    [JsonPropertyName("qd")]
    public int QuestId { get; set; }

    [JsonPropertyName("pg")]
    public int Progress { get; set; }

    [JsonPropertyName("c")]
    public bool Cleared { get; set; }

    [JsonPropertyName("r")]
    public bool Rewarded { get; set; }

    [JsonPropertyName("rt")]
    public QuestRenewalType RenewalType { get; set; }

    [JsonPropertyName("ed")]
    public long ExpireDtm { get; set; }

    // Navigational properties
    public virtual User User { get; set; }

}