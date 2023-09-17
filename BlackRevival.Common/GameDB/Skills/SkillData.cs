using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Skills
{
	public class SkillData
	{
		[JsonPropertyName("rid")] public int id { get; set; }

		[JsonPropertyName("sid")] public int skillId { get; set; }

		[JsonPropertyName("stp")] public SkillType skillType { get; set; }

		[JsonPropertyName("shd")] public SkillHolder holder { get; set; }

		[JsonPropertyName("stt")] public StackType stackType { get; set; }

		[JsonPropertyName("mst")] public int maxStack { get; set; }

		[JsonPropertyName("ist")] public int initialStack { get; set; }

		[JsonPropertyName("drt")] public DurationType durationType { get; set; }

		[JsonPropertyName("drs")] public int duration { get; set; }

		[JsonPropertyName("cot")] public int coolTime { get; set; }

		[JsonPropertyName("cat")] public int castingTime { get; set; }

		[JsonPropertyName("crh")] public bool criticalHappen { get; set; }

		[JsonPropertyName("alh")] public bool alwaysHit { get; set; }

		[JsonPropertyName("sat")] public SkillActiveTarget skillActiveTarget { get; set; }

		[JsonPropertyName("ise")] public bool isShowEffect { get; set; }

		[JsonPropertyName("slnt")] public SkillLogNotiType skillLogNotiType { get; set; }

		[JsonPropertyName("sant")] public SkillActiveNotiType skillActiveNotiType { get; set; }

		[JsonPropertyName("sei")] public List<int> statusEffects { get; set; }

		[JsonPropertyName("scol")] public SkillColor skillColor { get; set; }

		[JsonPropertyName("mtp")] public MapType mapType { get; set; }

		[JsonPropertyName("asc")] public bool allowSameCharacterClass { get; set; }

		[NonSerialized] private readonly string SKILL_FORMAT = "SkillIcon_{0}";

		public int UISkillId
		{
			get
			{
				switch ((Skill)skillId)
				{
					case Skill.OMEN_TEAM:
					case Skill.OMEN_E:
						return 3008;
					case Skill.STIGMA_E:
						return 1009;
					case Skill.JUDGEMENT_E:
						return 3006;
					case Skill.PHONY_DEAL_E:
						return 3005;
					case Skill.BURNED_E:
						return 5027;
					case Skill.BLEEDING_E:
						return 3010;
					case Skill.POISONED_E:
						return 5055;
					case Skill.STIMULATION_E:
						return 5001;
					case Skill.JEOMHYEOL_E:
						return 5004;
					case Skill.INTEGRATED_GPS_E:
						return 5029;
					case Skill.PEACEMAKER_TEAM:
					case Skill.PEACEMAKER_E:
						return 2001;
					case Skill.NO_EXCAVATION_E:
						return 2002;
					case Skill.SPICY_E:
						return 2008;
					case Skill.INFRARED_DETECT_E:
						return 2009;
					case Skill.SPEEDING_E:
						return 1016;
					case Skill.JUSTICE_E:
						return 1013;
					case Skill.HIDE_E:
						return 2007;
					case Skill.DRUNKEN_MASTER_E:
						return 1018;
					case Skill.KEEP_PAIN_TEAM:
					case Skill.KEEP_PAIN_E:
					case Skill.KEEP_PAIN_TEAM_E:
						return 1023;
					case Skill.BLOOD_FEST_TEAM:
					case Skill.BLOOD_FEST_E:
					case Skill.BLOOD_FEST_E_TEAM:
						return 1001;
					case Skill.CONTRE_ATTAQUE_E:
						return 2010;
					case Skill.PLAYING_DEAD_E:
						return 1017;
					case Skill.SMOKE_E:
						return 5028;
					case Skill.AMBUSH_E:
						return 6002;
					case Skill.DETECT_E:
						return 6003;
					case Skill.COUNTER_E:
						return 6004;
					case Skill.ACCELATE_E:
						return 6005;
					case Skill.WEAPON_ENHANCE_TEAM:
						return 1002;
					case Skill.DISSONANCES_TEAM:
						return 3004;
					case Skill.HACKER_TEAM:
						return 1011;
					case Skill.CLEANING_SERVICE_TEAM:
						return 3023;
					case Skill.TRACE_TEAM_E:
						return 12508;
					case Skill.ADAPTATION_TEAM_E:
						return 6302;
					case Skill.DESPERATE_THROW_TEAM:
						return 3011;
					case Skill.CLAIRVOYANCE_TEAM:
						return 2004;
					case Skill.CHECK_TEAM:
						return 3017;
					case Skill.HUNTING_TEAM:
						return 1020;
					case Skill.PATTERN_COLLECT_TEAM:
						return 3021;
					case Skill.FISHING_TEAM:
						return 2020;
					case Skill.PROVOKE_TEAM_E:
						return 6301;
					case Skill.HUNTING_TRAP_TEAM:
						return 2015;
					case Skill.TIME_TRAIL_TEAM:
						return 2019;
					case Skill.HUNTING_TRAP_TEAM_E:
						return 11505;
					case Skill.GUERILLA_WARFARE_TEAM:
						return 1006;
					case Skill.CYBERNETICS_TEAM:
						return 1005;
					case Skill.ACTIVATE_TURRET_TEAM:
						return 2013;
					case Skill.FEVER_MINE_TEAM_E:
						return 6305;
					case Skill.POACH_TEAM_E:
						return 6304;
					case Skill.SOLITUDE_ARTIST_TEAM:
						return 1028;
					case Skill.SOLITUDE_TEAM:
						return 13513;
					case Skill.ARTISTIC_MATERIAL_TEAM:
						return 13514;
					case Skill.VITAL_CRASH_E:
						return 2028;
					case Skill.ONE_VS_17_TEAM:
						return 3007;
					case Skill.SPIN_A_SPEAR_E:
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

		public bool PlayerTarget => skillActiveTarget == SkillActiveTarget.CHARACTER;

		public string GetName(bool isPvEModeItem = false)
		{
			if (isPvEModeItem)
			{
				return LocalizationDB.Instance.SkillName(skillId + 100000);
			}

			return LocalizationDB.Instance.SkillName(skillId);
		}

		public string GetName_EnableEmpty()
		{
			return LocalizationDB.Instance.SkillIgnoreName(skillId);
		}


		public string GetCaseByCaseName()
		{
			return LocalizationDB.Instance.CaseByCaseSkillName(skillId);
		}

		public string GetDesc(bool isPvEModeItem = false)
		{
			if (!isPvEModeItem)
			{
				return LocalizationDB.Instance.SkillDesc(skillId);
			}

			return LocalizationDB.Instance.SkillDesc(skillId + 100000);
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
			/*if (isPvEModeItem)
			{
				return AcSingleton<AcPvEItemSkillDB>.Instance.Exist(skillId);
			}
			*/
			return true;
		}

		public string GetIconSprite()
		{
			StackType stackType = this.stackType;
			if ((uint)(stackType - 11) <= 1u || stackType == StackType.EXAUST_CHARGE_APPEARANCE_STACK_INVISIBLE)
			{
				return GetDefaultAppearanceIconSprite(skillId);
			}

			switch ((Skill)skillId)
			{
				case Skill.Wound_Head_E:
					return "S300030";
				case Skill.Wound_Body_E:
					return "S300040";
				case Skill.Wound_Arm_E:
					return "S300050";
				case Skill.Wound_Leg_E:
					return "S300060";
				case Skill.STUFFED_E:
					return "S300020";
				case Skill.OVERHYDRATION_E:
					return "S300010";
				case Skill.HANGOVER_E:
					return "S300070";
				case Skill.ALMA_LADRON_MYSELF_E:
				case Skill.ALMA_LADRON_ENEMY_E:
					return string.Format(SKILL_FORMAT, 12505);
				case Skill.EYE_OF_AZRAEL_TEAM:
					return GetIconSprite(Skill.EYE_OF_AZRAEL);
				case Skill.MEMORY_TEAM:
					return GetIconSprite(Skill.MEMORY);
				case Skill.INFRARED_DETECT_TEAM:
					return GetIconSprite(Skill.INFRARED_DETECT);
				case Skill.INNING_EATER_TEAM:
				case Skill.INNING_EATER_TEAM_E:
					return GetIconSprite(Skill.INNING_EATER);
				case Skill.OCTAGON_E:
					return GetIconSprite(Skill.OCTAGON_FEVER);
				case Skill.SLOWED2_E:
					return GetIconSprite(Skill.SLOWED_E);
				case Skill.SHRINE_OF_CORRUPTION_E:
					return GetIconSprite(Skill.JUDGEMENT);
				default:
					return string.Format(SKILL_FORMAT, UISkillId);
			}
		}

		public string GetIconSprite(Skill skillId)
		{
			return string.Format(SKILL_FORMAT, (int)skillId);
		}

		private string GetDefaultAppearanceIconSprite(int skillId)
		{
			return $"SkillIcon_{skillId}_{((initialStack == maxStack) ? maxStack : 0)}";
		}

		public string GetDescAdd(bool isPvEModeItem = false)
		{
			if (!isPvEModeItem)
			{
				return LocalizationDB.Instance.SkillDescAdd(skillId);
			}

			return LocalizationDB.Instance.SkillDescAdd(skillId + 100000);
		}

		public string GetBroadcastDescAdd()
		{
			return LocalizationDB.Instance.SkillBroadcastDesc(skillId);
		}

		public string GetActionLog()
		{
			return LocalizationDB.Instance.SkillActionLog(skillId);
		}

		public string GetSkillTypeDesc()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(LocalizationDB.Instance.Dynamic("타입"));
			stringBuilder.Append(": ");
			switch (skillType)
			{
				case SkillType.COMBAT:
					stringBuilder.Append(LocalizationDB.Instance.Dynamic("컴뱃"));
					break;
				case SkillType.PASSIVE:
					stringBuilder.Append(LocalizationDB.Instance.Dynamic("패시브"));
					break;
				case SkillType.FIELD:
					stringBuilder.Append(LocalizationDB.Instance.Dynamic("필드"));
					break;
				default:
					return string.Empty;
			}

			return stringBuilder.ToString();
		}

		public string getCoolTimeDesc()
		{
			if (coolTime > 0)
			{
				return LocalizationDB.Instance.Dynamic("쿨타임") + ": " + LocalizationDB.Instance.StringFormat("{0}초", coolTime);
			}

			return string.Empty;
		}

		public string GetCoolTimeTooltipLabel()
		{
			if (coolTime > 0)
			{
				return "(" + LocalizationDB.Instance.StringFormat("쿨타임 {0}초", coolTime) + ")";
			}

			return string.Empty;
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



		public string GetFieldEffectIcon()
		{
			switch (skillId)
			{
				case 2001:
				case 13501:
					return "Ingame_Char_Abil_Icon_004";
				case 2002:
				case 13502:
					return "Ingame_Char_Abil_Icon_005";
				case 2018:
				case 13503:
					return "Ingame_Char_Abil_Icon_006";
				case 13528:
					return "Ingame_Char_Abil_Icon_012";
				case 13541:
					return "Ingame_Char_Abil_Icon_014";
				case 13544:
					return "Ingame_Char_Abil_Icon_015";
				case 13545:
					return "Ingame_Char_Abil_Icon_016";
				default:
					return string.Empty;
			}
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
