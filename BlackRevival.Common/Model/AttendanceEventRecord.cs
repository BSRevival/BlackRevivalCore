using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class AttendanceEventRecord
{
    [JsonPropertyName("eid")]
    public int eventId{ get; set; }

    [JsonPropertyName("cnt")]
    public int attendanceCount{ get; set; }

    [JsonPropertyName("atv")]
    public bool isActivatedNow{ get; set; }

    [JsonPropertyName("sd")]
    //[JsonConverter(typeof(MicrosecondEpochConverter))]
    public long startDtm{ get; set; }

    [JsonPropertyName("lad")]
    //[JsonConverter(typeof(MicrosecondEpochConverter))]
    public long lastAttendDtm{ get; set; }

    [JsonPropertyName("ed")]
    //[JsonConverter(typeof(MicrosecondEpochConverter))]
    public long expireDtm{ get; set; }

    [JsonPropertyName("rwd")]
    public bool rewarded{ get; set; }
}