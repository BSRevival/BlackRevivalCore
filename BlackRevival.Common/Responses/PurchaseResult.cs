using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class PurchaseResult
{
    public UserAsset userAsset { get; set; }

    public ProvideResult provideResult { get; set; }

    public AttendanceEventRecord attendanceEventRecord { get; set; }
}