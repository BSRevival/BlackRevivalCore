using System.Text.Json.Serialization;

namespace BlackRevival.Common.Networking;

public class WebSocketMessage
{
    // Token: 0x17000432 RID: 1074
    // (get) Token: 0x06001B50 RID: 6992 RVA: 0x00014BEC File Offset: 0x00012DEC
    public bool IsNotification
    {
        get
        {
            return !string.IsNullOrEmpty(this.method);
        }
    }

    // Token: 0x04001305 RID: 4869
    [JsonPropertyName("mtd")]
    public string method {get; set;}

    // Token: 0x04001306 RID: 4870
    [JsonPropertyName("rid")]
    public long id {get; set;}

    // Token: 0x04001307 RID: 4871
    [JsonPropertyName("tme")]
    public long time {get; set;}

    // Token: 0x04001308 RID: 4872
    [JsonPropertyName("cod")]
    public int code {get; set;}

    // Token: 0x04001309 RID: 4873
    [JsonPropertyName("msg")]
    public string msg {get; set;}

    // Token: 0x0400130A RID: 4874
    [JsonIgnore]
    public string json = "";
}