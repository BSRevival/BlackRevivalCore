using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.EnemyGroup;
using BlackRevival.Common.PVE;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class EnemyGroupDB
{
	public EnemyGroupDB()
		{
			this.expeditionEnemyGroup = new List<EnemyGroupData>();
		}

		public EnemyGroupDB(EnemyGroupDB.Model data)
		{
			this.expeditionEnemyGroup = data.expeditionEnemyGroup;
			this.expeditionEquipTemplate = data.expeditionEquipTemplate;
		}

		public EnemyGroupData Find(Predicate<EnemyGroupData> match)
		{
			return this.expeditionEnemyGroup.Find(match);
		}

		public int GetEquipTemplateIdx(int survivalDay, AcE_EXPEDITION_DIFFICULTY difficult)
		{
			int num;
			switch (difficult)
			{
			case AcE_EXPEDITION_DIFFICULTY.EASY:
				num = survivalDay / (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_EASY);
				break;
			case AcE_EXPEDITION_DIFFICULTY.NORMAL:
				num = survivalDay / (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_NORMAL);
				break;
			case AcE_EXPEDITION_DIFFICULTY.HARD:
				num = survivalDay / (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_HARD);
				break;
			default:
				num = survivalDay / 2;
				break;
			}
			num = Math.Min(num, 10);
			Log.Information("[EquipTemplate] index[{0}]", new object[] { num });
			return num;
		}

		public EquipTemplate GetEquipTemplate(int weaponType, int idx)
		{
			List<EquipTemplate> list = this.expeditionEquipTemplate.FindAll((EquipTemplate template) => template.weaponType == weaponType);
			if (list == null)
			{
				return null;
			}
			Log.Information("[EquipTemplate] WeaponType[{0}], Index[{1}]", new object[]
			{
				(AcE_WEAPON_TYPE)weaponType,
				idx
			});
			return list.Find((EquipTemplate equip) => equip.index == idx);
		}
		//TODO: Fix when ExpeditionUnitData is implemented
		/*public ExpeditionUnitData GetMainUnit(int groupCode, ref List<int> exceptUnitClasses, AcE_EXPEDITION_DIFFICULTY difficulty)
		{
			EnemyGroupParam selected = null;
			if (difficulty == AcE_EXPEDITION_DIFFICULTY.EASY)
			{
				selected = this.GetEasyMainUnitParam(groupCode);
			}
			if (selected == null)
			{
				EnemyGroupData enemyGroupData = this.Find((EnemyGroupData item) => item.code.Equals(groupCode));
				if (enemyGroupData == null)
				{
					Log.Error(string.Format("[EnemyGroupDB - GetMainUnit] EnemyGroupData is null. groupCode[{0}]", groupCode));
					return null;
				}
				List<AcChoose.AcChoosObject> list = new List<AcChoose.AcChoosObject>();
				foreach (EnemyGroupParam enemyGroupParam in enemyGroupData.enemyGroupList)
				{
					if (!exceptUnitClasses.Contains(enemyGroupParam.unitClass))
					{
						list.Add(new AcChoose.AcChoosObject(enemyGroupParam.appearRatio, enemyGroupParam));
						if (enemyGroupParam.unitClass != 0 && enemyGroupParam.unitClass < 10000)
						{
							exceptUnitClasses.Add(enemyGroupParam.unitClass);
						}
					}
				}
				AcChoose.AcChoosObject acChoosObject = AcChoose.Choose(list);
				selected = acChoosObject.data as EnemyGroupParam;
			}
			if (selected == null)
			{
				Log.Error("[EnemyGroupDB.GetMainUnit] Choosen error.");
				return null;
			}
			ExpeditionUnitData expeditionUnitData = GameDB.expeditionUnit.Find((ExpeditionUnitData item) => item.unitClass.Equals(selected.unitClass) && item.unitGrade.Equals(selected.unitGrade));
			if (expeditionUnitData == null)
			{
				Log.Error(string.Format("Failed to find ExpeditionUnitData. GropuCode[{0}], UnitClass[{1}], UnitGrade[{2}]", groupCode, selected.unitClass, selected.unitGrade));
			}
			return expeditionUnitData;
		}*/

		private EnemyGroupParam GetEasyMainUnitParam(int groupCode)
		{
			if (groupCode < 1001 || 30000 < groupCode)
			{
				Log.Warning(string.Format("[EnemyGroupDB.GetEasyMainUnit] Invalid groupCode[{0}]", groupCode));
				return null;
			}
			EnemyGroupData enemyGroupData = this.Find((EnemyGroupData item) => item.code.Equals(groupCode));
			if (enemyGroupData == null)
			{
				Log.Error(string.Format("[EnemyGroupDB.GetEasyMainUnit] EnemyGroupData is null. groupCode[{0}]", groupCode));
				return null;
			}
			List<EnemyGroupParam> sortedByGrade = new List<EnemyGroupParam>(enemyGroupData.enemyGroupList);
			sortedByGrade.Sort((EnemyGroupParam x, EnemyGroupParam y) => x.unitGrade.CompareTo(y.unitGrade));
			sortedByGrade.RemoveAll((EnemyGroupParam x) => x.unitGrade > sortedByGrade[0].unitGrade);
			Random random = new Random(DateTime.Now.Ticks.GetHashCode());
			return sortedByGrade[random.Next(0, sortedByGrade.Count)];
		}
		//TODO: Fix when ExpeditionUnitData is implemented
		/*public ExpeditionUnitData GetSubUnit(int groupCode, int unitGradeMax, ref List<int> exceptUnitClasses)
		{
			EnemyGroupData enemyGroupData = this.Find((EnemyGroupData item) => item.code.Equals(groupCode));
			List<AcChoose.AcChoosObject> list = new List<AcChoose.AcChoosObject>();
			float num = 1f / (float)enemyGroupData.enemyGroupList.Count;
			foreach (EnemyGroupParam enemyGroupParam in enemyGroupData.enemyGroupList)
			{
				if (!exceptUnitClasses.Contains(enemyGroupParam.unitClass))
				{
					list.Add(new AcChoose.AcChoosObject(enemyGroupParam.appearRatio, enemyGroupParam));
					if (enemyGroupParam.unitClass != 0 && enemyGroupParam.unitClass < 10000)
					{
						exceptUnitClasses.Add(enemyGroupParam.unitClass);
					}
				}
			}
			AcChoose.AcChoosObject acChoosObject = AcChoose.Choose(list);
			EnemyGroupParam selected = acChoosObject.data as EnemyGroupParam;
			int unitGrade = UnityEngine.Random.Range(201, unitGradeMax + 1);
			ExpeditionUnitData expeditionUnitData = GameDB.expeditionUnit.Find((ExpeditionUnitData item) => item.unitClass.Equals(selected.unitClass) && item.unitGrade.Equals(unitGrade));
			if (expeditionUnitData == null)
			{
				Log.Error("GropuCode[{0}], UnitClass[{1}], UnitGrade[{2}]", new object[] { groupCode, selected.unitClass, selected.unitGrade });
			}
			return expeditionUnitData;
		}*/

		public EquipTemplate GetAllyEquipTemplate(int weaponType, int idx, AcE_EXPEDITION_DIFFICULTY difficulty)
		{
			List<EquipTemplate> list = this.expeditionEquipTemplate.FindAll((EquipTemplate template) => template.weaponType == weaponType && template.code > 11000 && template.code < 17999);
			if (list == null)
			{
				return null;
			}
			switch (difficulty)
			{
			case AcE_EXPEDITION_DIFFICULTY.EASY:
				idx += (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_EASY_START);
				break;
			case AcE_EXPEDITION_DIFFICULTY.NORMAL:
				idx += (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_NORMAL_START);
				break;
			case AcE_EXPEDITION_DIFFICULTY.HARD:
				idx += (int)AcPvEGlobalConstantDB.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_HARD_START);
				break;
			}
			idx = Math.Max(1, idx);
			idx = Math.Min(idx, 10);
			Log.Information("[Ally EquipTemplate] WeaponType[{0}], Index[{1}]", new object[] { weaponType, idx });
			return list.Find((EquipTemplate equip) => equip.index == idx);
		}

		public EquipTemplate GetBossEquipTemplate(int weaponType)
		{
			EquipTemplate equipTemplate = this.expeditionEquipTemplate.Find((EquipTemplate template) => template.weaponType == weaponType && template.code > 51090);
			if (equipTemplate == null)
			{
				return null;
			}
			Log.Information(string.Format("[Ally EquipTemplate] WeaponType[{0}]", weaponType));
			return equipTemplate;
		}

		private readonly List<EnemyGroupData> expeditionEnemyGroup;

		private readonly List<EquipTemplate> expeditionEquipTemplate;

		public class Model
		{
			public List<EnemyGroupData> expeditionEnemyGroup { get; set; }

			public List<EquipTemplate> expeditionEquipTemplate { get; set; }
		}
}