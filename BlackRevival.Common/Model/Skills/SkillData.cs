
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
	public class SkillData
	{
		[JsonPropertyName("rid")]
		public readonly int id;

		[JsonPropertyName("sid")]
		public readonly int skillId;

		[JsonPropertyName("stp")]
		public readonly SkillType skillType;

		[JsonPropertyName("shd")]
		public readonly SkillHolder holder;

		[JsonPropertyName("stt")]
		public readonly StackType stackType;

		[JsonPropertyName("mst")]
		public readonly int maxStack;

		[JsonPropertyName("ist")]
		public readonly int initialStack;

		[JsonPropertyName("drt")]
		public readonly DurationType durationType;

		[JsonPropertyName("drs")]
		public readonly int duration;

		[JsonPropertyName("cot")]
		public readonly int coolTime;

		[JsonPropertyName("cat")]
		public readonly int castingTime;

		[JsonPropertyName("crh")]
		public readonly bool criticalHappen;

		[JsonPropertyName("alh")]
		public readonly bool alwaysHit;

		[JsonPropertyName("sat")]
		public readonly SkillActiveTarget skillActiveTarget;

		[JsonPropertyName("ise")]
		public readonly bool isShowEffect;

		[JsonPropertyName("slnt")]
		public SkillLogNotiType skillLogNotiType;

		[JsonPropertyName("sant")]
		public SkillActiveNotiType skillActiveNotiType;

		[JsonPropertyName("sei")]
		public readonly List<int> statusEffects;

		[JsonPropertyName("scol")]
		public readonly SkillColor skillColor;

		[JsonPropertyName("mtp")]
		public readonly MapType mapType;

		[JsonPropertyName("asc")]
		public readonly bool allowSameCharacterClass;

		[NonSerialized]
		private readonly string SKILL_FORMAT = "SkillIcon_{0}";

		public int UISkillId
		{
			get
			{
				switch (skillId)
				{
					case 3508:
					case 12504:
						return 3008;
					case 12501:
						return 1009;
					case 12503:
						return 3006;
					case 12502:
						return 3005;
					case 11501:
						return 5027;
					case 11502:
						return 3010;
					case 11504:
						return 5055;
					case 11001:
						return 5001;
					case 11002:
						return 5004;
					case 11003:
						return 5029;
					case 2501:
					case 13501:
						return 2001;
					case 13502:
						return 2002;
					case 12008:
						return 2008;
					case 12009:
						return 2009;
					case 12003:
						return 1016;
					case 12002:
						return 1013;
					case 12007:
						return 2007;
					case 12005:
						return 1018;
					case 1523:
					case 12013:
					case 12313:
						return 1023;
					case 1501:
					case 12001:
					case 12301:
						return 1001;
					case 12010:
						return 2010;
					case 12004:
						return 1017;
					case 13001:
						return 5028;
					case 14001:
						return 6002;
					case 14004:
						return 6003;
					case 14002:
						return 6004;
					case 14003:
						return 6005;
					case 1502:
						return 1002;
					case 3504:
						return 3004;
					case 1511:
						return 1011;
					case 3523:
						return 3023;
					case 12808:
						return 12508;
					case 14006:
						return 6302;
					case 3511:
						return 3011;
					case 2504:
						return 2004;
					case 3517:
						return 3017;
					case 1520:
						return 1020;
					case 3521:
						return 3021;
					case 2520:
						return 2020;
					case 14005:
						return 6301;
					case 2515:
						return 2015;
					case 2519:
						return 2019;
					case 12315:
						return 11505;
					case 1506:
						return 1006;
					case 1505:
						return 1005;
					case 2513:
						return 2013;
					case 14008:
						return 6305;
					case 14007:
						return 6304;
					case 1528:
						return 1028;
					case 13813:
						return 13513;
					case 13814:
						return 13514;
					case 13517:
						return 2028;
					case 3507:
						return 3007;
					case 12036:
						return 2036;
					default:
						return skillId;
				}
			}
		}

		public SkillActivateType skillActivateType
		{
			get
			{
				switch (skillType)
				{
					case SkillType.COMBAT:
						return SkillActivateType.Combat;
					case SkillType.PASSIVE:
						return SkillActivateType.Passive;
					case SkillType.FIELD:
						if (holder == SkillHolder.POTENTIAL)
						{
							return SkillActivateType.Potential;
						}
						return SkillActivateType.Field;
					default:
						return SkillActivateType.None;
				}
			}
		}

		public bool PlayerTarget
		{
			get
			{
				return skillActiveTarget == SkillActiveTarget.CHARACTER;
			}
		}

		public bool IsTeamStimuli()
		{
			return skillId == 15001;
		}

		public bool IsTeamUnstoppable()
		{
			return skillId == 15002;
		}


		public bool IsBuffEffect()
		{
			if (skillType == SkillType.EFFECT)
			{
				return skillColor == SkillColor.GREEN;
			}
			return false;
		}

		public bool IsRecoveryDeBuff()
		{
			if (skillId != 10008 && skillId != 10009)
			{
				return skillId == 10010;
			}
			return true;
		}

		public bool UseableSkill(bool isPvEModeItem = false)
		{
			//if (isPvEModeItem)
			//{
			//	return AcSingleton<AcPvEItemSkillDB>.Instance.Exist(skillId);
			//}
			return true;
		}

		

		public bool IsDefenceSkill(bool containBoth)
		{
			if (skillLogNotiType == SkillLogNotiType.Defence)
			{
				return true;
			}
			if (skillLogNotiType != SkillLogNotiType.DefenceOnlyMe)
			{
				return true;
			}
			if (containBoth && skillLogNotiType == SkillLogNotiType.Both)
			{
				return true;
			}
			return false;
		}

		public bool IsStackAvailableType()
		{
			StackType stackType = this.stackType;
			if ((uint)(stackType - 9) <= 1u)
			{
				return true;
			}
			return false;
		}
	}
}
