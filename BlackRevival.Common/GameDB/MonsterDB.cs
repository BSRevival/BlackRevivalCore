using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Monster;

namespace BlackRevival.Common.GameDB;

public class MonsterDB
{
	public static MonsterDB Instance { get; private set; }
	public MonsterDB()
	{
		this.monsters = new List<MonsterData>();
		Instance = this;
	}

	public MonsterDB(MonsterDB.Model model)
	{
		this.monsters = model.monsters;
		Instance = this;
	}

	public MonsterData Find(int monsterClass, MapType mapType)
	{
		return this.monsters.Find((MonsterData data) => data.monsterClass == monsterClass && data.mapType == mapType);
	}

	public MonsterData Find(int monsterClass, PlayMode playMode)
	{
		MapType mapType = ((playMode == PlayMode.TEAM || playMode == PlayMode.TEAM_PRIVATE) ? MapType.SEOUL : MapType.LUMIA);
		return this.monsters.Find((MonsterData data) => data.monsterClass == monsterClass && data.mapType == mapType);
	}

	public List<MonsterData> FindClass(int monsterClass)
	{
		return this.monsters.FindAll((MonsterData data) => data.monsterClass == monsterClass);
	}

	public List<MonsterData> FindClassAll(MapType mapType)
	{
		return this.monsters.FindAll((MonsterData data) => data.mapType == mapType);
	}

	public string GetName(int monsterClass)
	{
		List<MonsterData> list = this.FindClass(monsterClass);
		if (list == null || list.Count == 0)
		{
			return "";
		}
		return list[0].GetName();
	}

	public string GetDesc(int monsterClass)
	{
		List<MonsterData> list = this.FindClass(monsterClass);
		if (list == null || list.Count == 0)
		{
			return "";
		}
		return list[0].GetDesc();
	}
	

	public int GetInitialIntervalCount(int monsterClass)
	{
		List<MonsterData> list = this.FindClass(monsterClass);
		if (list == null || list.Count == 0)
		{
			return 0;
		}
		return list[0].initialIntervalSeconds / 180;
	}

	private List<MonsterData> monsters { get; set; }

	public class Model
	{
		public List<MonsterData> monsters { get; set; }
	}
}