using BlackRevival.Common.GameDB.Attendance;

namespace BlackRevival.Common.GameDB;

public class AttendanceEventDB
{
    public AttendanceEventDB()
    {
        this.attendanceEvent = new List<AttendanceEvent>();
    }

    public AttendanceEventDB(AttendanceEventDB.Model data)
    {
        this.attendanceEvent = data.attendanceEvent;
    }

    public AttendanceEvent Find(int eventId)
    {
        return this.attendanceEvent.Find((AttendanceEvent data) => data.eventId == eventId);
    }

    public List<AttendanceEvent> attendanceEvent;

    public class Model
    {
        public List<AttendanceEvent> attendanceEvent;
    }
}