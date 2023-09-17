using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using BlackRevival.Common.Util;
using System;

namespace BlackRevival.Common.GameDB.Attendance;

public class AttendanceEventRecord
{
    public enum EventID
    {
        NONE,
        NEW_USER,
        X_MAS,
        FIRST_INAPP,
        SEASON_VOTE,
        REPEAT,
        SIXTH_ATTENDANCE = 100,
        NEW_YEAR_ATTENDANCE
    }

    public bool IsExpired()
    {
        return (this.expireDtm.ToUniversalTime() - DateTime.UtcNow).TotalSeconds <= 0.0;
    }

    public bool IsContainEventView()
    {
        return this.eventId != 4;
    }

    public AttendanceEventRecord.EventID GetEventID()
    {
        return AcEnum.ConvertInt<AttendanceEventRecord.EventID>(this.eventId);
    }

    public bool IsGetRewardable()
    {
        return this.attendanceCount > 0 && !this.rewarded;
    }

    [JsonPropertyName("eid")] public int eventId { get; set; }

    [JsonPropertyName("cnt")] public int attendanceCount { get; set; }

    [JsonPropertyName("atv")] public bool isActiveNow { get; set; }

    [JsonPropertyName("sd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime startDtm { get; set; }

    [JsonPropertyName("lad")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime lastAttendDtm { get; set; }

    [JsonPropertyName("ed")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime expireDtm { get; set; }

    [JsonPropertyName("rwd")] public bool rewarded { get; set; }

}