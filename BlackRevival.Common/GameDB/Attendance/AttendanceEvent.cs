using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Attendance;

public class AttendanceEvent
{
    [JsonPropertyName("eid")]
    public int eventId { get; set; }
    
    [JsonPropertyName("exp")]
    public int daysToExpiration { get; set; }

    [JsonPropertyName("rwd")] 
    public Dictionary<int, Goods> rewards { get; set; }

    [JsonPropertyName("get")] 
    public GameEventType gameEventType { get; set; }

    [JsonPropertyName("evex")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime eventExpiration { get; set; }

    [JsonPropertyName("mxs")] 
    public int maxSize { get; set; }
}