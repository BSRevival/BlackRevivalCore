using BlackRevival.Common.Model;

namespace BlackRevival.Common.InGame;

public class EverythingLocation
{
    public FieldCharacter fieldCharacter  { get;set; }

    public long restrictRemainSec { get;set; }

    public FieldType meLocation { get;set; }

    public Dictionary<int, int> monsterLocation { get;set; }

    public Dictionary<long, int> corpseLocation { get;set; }

    public Dictionary<int, InstalledRobot> installedRobots { get;set; }

    public List<FieldTypeStatus> publicLocation { get;set; }

    public Dictionary<int, int> fieldTypeAndCharacterCount { get;set; }
    //This is a long one
    //public List<EnemyInfomation> enemyInformations { get;set; }

    public Dictionary<int, TimeTrailStatus> fieldTypeAndTimeTrailStatus { get;set; }

    public List<int> artisticMaterial { get;set; }

    public List<int> hideAndSeekPlaces { get;set; }

    public Dictionary<int, InstalledDoll> installedDoll { get;set; }

    public List<int> shrineOfCorruption { get;set; }

    public Dictionary<int, int> monsterClassAndFieldType { get;set; }
}