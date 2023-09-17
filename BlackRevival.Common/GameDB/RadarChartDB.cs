using BlackRevival.Common.GameDB.Radar;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB;

public class RadarChartDB
{
    public RadarChartDB()
    {
        this.radarMinMax = new List<UserRadarData>();
    }

    public RadarChartDB(RadarChartDB.Model data)
    {
        this.radarMinMax = data.radarMinMax;
    }

    public UserRadarData GetData(League league, string name)
    {
        foreach (UserRadarData userRadarData in this.radarMinMax)
        {
            if (userRadarData.league == league && userRadarData.name.Equals(name))
            {
                return userRadarData;
            }
        }
        return null;
    }

    public List<UserRadarData> radarMinMax { get; set; }

    public class Model
    {
        public List<UserRadarData> radarMinMax { get; set; }
    }
}