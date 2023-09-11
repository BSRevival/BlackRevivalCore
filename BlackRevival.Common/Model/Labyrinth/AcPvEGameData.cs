using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model.Labyrinth;

public class AcPvEGameData
{
		/*
		public static AcPvEGameData.PvECharacterData GetCharacterData(AcPvECharacter character)
		{
			if (character == null)
			{
				Serilog.Log.Error("AcPvECharacter is null.");
				return null;
			}
			return new AcPvEGameData.PvECharacterData
			{
				teamIdx = (int)character.p_characterID,
				unitClass = character.p_UnitData.unitClass,
				unitGrade = character.p_UnitData.unitGrade,
				curHp = character.p_CurHP,
				curSp = character.p_CurStamina,
				exp = character.p_Exp,
				mastery = AcPvEGameData.GetMastery(character.p_Mastery),
				equipments = AcPvEGameData.GetEquipItemDatas(character.GetEquipments()),
				skinCode = character.p_SkinCode
			};
		}

		public static Dictionary<AcE_MASTERY_TYPE, float> GetMastery(Dictionary<AcE_MASTERY_TYPE, ObscuredFloat> mastery)
		{
			Dictionary<AcE_MASTERY_TYPE, float> dictionary = new Dictionary<AcE_MASTERY_TYPE, float>();
			foreach (KeyValuePair<AcE_MASTERY_TYPE, ObscuredFloat> keyValuePair in mastery)
			{
				dictionary.Add(keyValuePair.Key, keyValuePair.Value.GetDecrypted());
			}
			return dictionary;
		}

		public static List<AcPvEGameData.PvEFieldItemData> GetFieldItemDatas(Inventory inventory)
		{
			if (inventory == null || inventory.FieldItems.Count == 0)
			{
				return null;
			}
			List<AcPvEGameData.PvEFieldItemData> list = new List<AcPvEGameData.PvEFieldItemData>();
			foreach (FieldItem fieldItem in inventory.FieldItems)
			{
				if (string.IsNullOrEmpty(fieldItem.fieldItemCode))
				{
					Serilog.Log.Error("FieldItem.fieldItemCode is null or empty. Inventory[{arg}]", fieldItem.item);
				}
				list.Add(new AcPvEGameData.PvEFieldItemData
				{
					fieldItemCode = fieldItem.fieldItemCode,
					itemCode = fieldItem.item,
					quantity = fieldItem.quantity,
					loadingQuantity = fieldItem.loadingQuantity,
					itemSkillData = new AcPvEGameData.PvEFieldItemSkillData(fieldItem.p_pveItemSkillData)
				});
			}
			return list;
		}

		public static List<AcPvEGameData.PvEFieldItemData> GetEquipItemDatas(Equipments equipments)
		{
			if (equipments == null || equipments.equips.Count == 0)
			{
				return null;
			}
			List<AcPvEGameData.PvEFieldItemData> list = new List<AcPvEGameData.PvEFieldItemData>();
			foreach (KeyValuePair<int, FieldItem> keyValuePair in equipments.equips)
			{
				if (string.IsNullOrEmpty(keyValuePair.Value.fieldItemCode))
				{
					Serilog.Log.Error("FieldItem.fieldItemCode is null or empty. Equipments[{arg}]", keyValuePair.Value.item);
				}
				list.Add(new AcPvEGameData.PvEFieldItemData
				{
					fieldItemCode = keyValuePair.Value.fieldItemCode,
					itemCode = keyValuePair.Value.item,
					quantity = keyValuePair.Value.quantity,
					loadingQuantity = keyValuePair.Value.loadingQuantity,
					itemSkillData = new AcPvEGameData.PvEFieldItemSkillData(keyValuePair.Value.p_pveItemSkillData)
				});
			}
			return list;
		}

		[JsonPropertyName("df")]
		public AcE_EXPEDITION_DIFFICULTY difficulty { get; set; }

		[JsonPropertyName("un")]
		public long userNum { get; set; }

		[JsonPropertyName("rky")]
		public string roomKey { get; set; }

		[JsonPropertyName("sdt")]
		public long startDtm { get; set; }

		[JsonPropertyName("ge")]
		public float globalExp { get; set; }

		[JsonPropertyName("sd")]
		public int survivalDay { get; set; }

		[JsonPropertyName("ekcd")]
		public Dictionary<AcE_UNIT_TYPE, Dictionary<AcE_UNIT_GRADE, int>> enemyKD { get; set; } = new Dictionary<AcE_UNIT_TYPE, Dictionary<AcE_UNIT_GRADE, int>>();

		[JsonPropertyName("cc")]
		public int continueCount { get; set; }

		[JsonPropertyName("lcr")]
		public List<AcPvEGameData.PvECharacterData> characters { get; set; } = new List<AcPvEGameData.PvECharacterData>();

		[JsonPropertyName("ib")]
		public List<AcPvEGameData.PvEFieldItemData> bag { get; set; } = new List<AcPvEGameData.PvEFieldItemData>();

		[JsonPropertyName("iw")]
		public List<AcPvEGameData.PvEFieldItemData> warehouse { get; set; } = new List<AcPvEGameData.PvEFieldItemData>();

		[JsonPropertyName("adl")]
		public DamageLog atkDamageLog { get; set; }

		[JsonPropertyName("ddl")]
		public DamageLog defDamageLog { get; set; }

		[JsonPropertyName("tis")]
		public List<FieldItemLog> takenItems { get; set; }

		[JsonPropertyName("la")]
		public int lastArea { get; set; }

		[JsonPropertyName("ld")]
		public int lastDist { get; set; }

		public static AcPvEGameData CreateNewGameData(AcE_EXPEDITION_DIFFICULTY difficulty)
		{
			return AcPvEGameData.CreateNewGameData(AcSingleton<AcPlayerInfo>.Instance.p_user.userNum, AcSingleton<AcPlayerInfo>.Instance.p_enterCharacter.GetExpeditionUnitData(), difficulty);
		}

		public static AcPvEGameData CreateNewGameData(long userNum, ExpeditionUnitData unitData, AcE_EXPEDITION_DIFFICULTY difficulty)
		{
			try
			{
				AcPvEGameData acPvEGameData = new AcPvEGameData
				{
					difficulty = difficulty,
					userNum = userNum,
					globalExp = 0f,
					survivalDay = 0,
					enemyKD = new Dictionary<AcE_UNIT_TYPE, Dictionary<AcE_UNIT_GRADE, int>>()
				};
				acPvEGameData.bag.Add(new AcPvEGameData.PvEFieldItemData
				{
					fieldItemCode = AcPvEUtility.GenerateFieldItemCode(32004),
					itemCode = 32004,
					quantity = 10,
					itemSkillData = new AcPvEGameData.PvEFieldItemSkillData()
				});
				acPvEGameData.startCharacterClass = AcSingleton<AcPlayerInfo>.Instance.p_enterCharacter.characterClass;
				acPvEGameData.startCharacterSkinCode = AcSingleton<AcPlayerInfo>.Instance.p_enterCharacter.activeCharacterSkinType;
				AcPvEGameData.PvECharacterData pvECharacterData = new AcPvEGameData.PvECharacterData
				{
					teamIdx = 0,
					unitClass = unitData.unitClass,
					unitGrade = unitData.unitGrade,
					curHp = unitData.health,
					curSp = unitData.stamina,
					exp = 0f,
					mastery = new Dictionary<AcE_MASTERY_TYPE, float>
					{
						{
							AcE_MASTERY_TYPE.BLADE,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.BLADE, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.BOW,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.BOW, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.BLUNT,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.BLUNT, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.GUN,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.GUN, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.PUNCH,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.PUNCH, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.STAB,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.STAB, AcE_MASTERY_RANK_TYPE.F)
						},
						{
							AcE_MASTERY_TYPE.THROW,
							GameDB.expeditionMastery.GetMasteryRankExp(AcE_MASTERY_TYPE.THROW, AcE_MASTERY_RANK_TYPE.F)
						}
					},
					equipments = new List<AcPvEGameData.PvEFieldItemData>()
				};
				if (AcSingleton<AcPlayerInfo>.Instance != null && AcSingleton<AcPlayerInfo>.Instance.p_user != null)
				{
					pvECharacterData.skinCode = ((AcSingleton<AcPlayerInfo>.Instance.p_enterCharacter == null) ? AcPvECharacter.GetRandomSkinCode((AcE_UNIT_CLASS)unitData.unitClass) : AcSingleton<AcPlayerInfo>.Instance.p_enterCharacter.activeCharacterSkinType);
				}
				else
				{
					pvECharacterData.skinCode = AcPvECharacter.GetRandomSkinCode((AcE_UNIT_CLASS)unitData.unitClass);
				}
				foreach (int num in unitData.mastery)
				{
					AcE_MASTERY_TYPE acE_MASTERY_TYPE = (AcE_MASTERY_TYPE)(num / 100);
					AcE_MASTERY_RANK_TYPE masteryRankType = Ac_MasteryRankTypeExtention.GetMasteryRankType(num);
					pvECharacterData.mastery[acE_MASTERY_TYPE] = GameDB.expeditionMastery.GetMasteryRankExp(acE_MASTERY_TYPE, masteryRankType);
				}
				AcE_MASTERY_TYPE weaponType = AcE_MASTERY_TYPE.PUNCH;
				float num2 = 0f;
				foreach (KeyValuePair<AcE_MASTERY_TYPE, float> keyValuePair in pvECharacterData.mastery)
				{
					if (keyValuePair.Value > num2)
					{
						weaponType = keyValuePair.Key;
						num2 = keyValuePair.Value;
					}
				}
				int idx;
				switch (difficulty)
				{
				case AcE_EXPEDITION_DIFFICULTY.EASY:
					idx = (int)AcSingleton<AcPvEGlobalConstantDB>.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_EASY_START);
					break;
				case AcE_EXPEDITION_DIFFICULTY.NORMAL:
					idx = (int)AcSingleton<AcPvEGlobalConstantDB>.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_NORMAL_START);
					break;
				case AcE_EXPEDITION_DIFFICULTY.HARD:
					idx = (int)AcSingleton<AcPvEGlobalConstantDB>.Instance.FindContantData(AcPvEGlobalConstantDB.AcE_PVE_CONSTANT.EQUIP_IDX_HARD_START);
					break;
				default:
					idx = 0;
					break;
				}
				EquipTemplate equipTemplate = GameDB.enemyGroup.GetEquipTemplate((int)weaponType.GetWeaponType(), idx);
				if (equipTemplate == null)
				{
					throw new NullReferenceException(string.Format("[AcPvEGameData.CreateNewGameData] EquipTemplate is null. unitClass[{0}], weponType[{1}], idx[3]", pvECharacterData.unitClass, weaponType.GetWeaponType()));
				}
				foreach (int item in equipTemplate.itemIds)
				{
					FieldItem fieldItem = new FieldItem();
					fieldItem.fieldItemCode = AcPvEUtility.GenerateFieldItemCode(fieldItem.item);
					fieldItem.item = item;
					fieldItem.quantity = fieldItem.ItemData.initialBundleQty;
					foreach (ItemBaseStat itemBaseStat in fieldItem.ItemData.properties)
					{
						ItemBaseAbility baseAbility = itemBaseStat.baseAbility;
						if (baseAbility != ItemBaseAbility.ITEM_AP)
						{
							if (baseAbility == ItemBaseAbility.ITEM_DP)
							{
								fieldItem.defence = itemBaseStat.value;
							}
						}
						else
						{
							fieldItem.offence = itemBaseStat.value;
						}
					}
					if (fieldItem.ItemData.IsPVEProjectileWeapon())
					{
						fieldItem.loadingQuantity = fieldItem.ItemData.loadingCapacity;
					}
					pvECharacterData.equipments.Add(new AcPvEGameData.PvEFieldItemData
					{
						fieldItemCode = fieldItem.fieldItemCode,
						itemCode = fieldItem.item,
						quantity = fieldItem.quantity,
						loadingQuantity = fieldItem.loadingQuantity,
						itemSkillData = new AcPvEGameData.PvEFieldItemSkillData(fieldItem.p_pveItemSkillData)
					});
				}
				acPvEGameData.characters = new List<AcPvEGameData.PvECharacterData>();
				acPvEGameData.characters.Add(pvECharacterData);
				return acPvEGameData;
			}
			catch (Exception ex)
			{
				AcLogger.LogException(ex);
				if (AcSingleton<AcPlayerInfo>.Instance != null && AcSingleton<AcPlayerInfo>.Instance.p_user != null)
				{
					AcSingleton<AcGameManager>.Instance.ChangeScene(AcE_GAMESCENE_TYPE.LobbyScene);
				}
			}
			return null;
		}

		public static AcPvEGameData CreateGameData(long userNum, string roomKey, long startDtm, AcPvEGameManager gameManager)
		{
			try
			{
				AcPvEGameData gameData = new AcPvEGameData
				{
					difficulty = gameManager.difficulty,
					userNum = userNum,
					roomKey = roomKey,
					startDtm = startDtm,
					globalExp = gameManager.globalExp,
					survivalDay = gameManager.p_SurvivalDay,
					enemyKD = gameManager.p_killCountDic,
					continueCount = gameManager.continueCount,
					bag = AcPvEGameData.GetFieldItemDatas(gameManager.p_Bag),
					warehouse = AcPvEGameData.GetFieldItemDatas(gameManager.p_Warehouse),
					startCharacterClass = gameManager.startCharacterClass,
					startCharacterSkinCode = gameManager.startCharacterSkinCode
				};
				gameData.characters = new List<AcPvEGameData.PvECharacterData>();
				gameManager.myTeam.GetCharacters().ForEach(delegate(AcPvECharacter character)
				{
					gameData.characters.Add(new AcPvEGameData.PvECharacterData
					{
						teamIdx = (int)character.p_characterID,
						unitClass = character.p_UnitData.unitClass,
						unitGrade = character.p_UnitData.unitGrade,
						curHp = character.p_CurHP,
						curSp = character.p_CurStamina,
						exp = character.p_Exp,
						mastery = AcPvEGameData.GetMastery(character.p_Mastery),
						equipments = AcPvEGameData.GetEquipItemDatas(character.GetEquipments()),
						skinCode = character.p_SkinCode
					});
				});
				gameData.lastArea = gameManager.lastArea;
				gameData.lastDist = gameManager.lastDist;
				return gameData;
			}
			catch (Exception ex)
			{
				AcLogger.LogException(ex);
				AcSingleton<AcGameManager>.Instance.ChangeScene(AcE_GAMESCENE_TYPE.LobbyScene);
			}
			return null;
		}

		[JsonPropertyName("scc")]
		public int startCharacterClass;

		[JsonPropertyName("scsc")]
		public int startCharacterSkinCode;

		public class PvECharacterData
		{
			[JsonPropertyName("tix")]
			public int teamIdx { get; set; }

			[JsonPropertyName("uc")]
			public int unitClass { get; set; }

			[JsonPropertyName("ug")]
			public int unitGrade { get; set; }

			[JsonPropertyName("chp")]
			public float curHp { get; set; }

			[JsonPropertyName("csp")]
			public float curSp { get; set; }

			[JsonPropertyName("exp")]
			public float exp { get; set; }

			[JsonPropertyName("mstr")]
			public Dictionary<AcE_MASTERY_TYPE, float> mastery { get; set; } = new Dictionary<AcE_MASTERY_TYPE, float>();

			[JsonPropertyName("eqs")]
			public List<AcPvEGameData.PvEFieldItemData> equipments { get; set; }

			[JsonPropertyName("sc")]
			public int skinCode { get; set; }
		}

		public class PvEFieldItemData
		{
			[JsonPropertyName("fic")]
			public string fieldItemCode { get; set; }

			[JsonPropertyName("ic")]
			public int itemCode { get; set; }

			[JsonPropertyName("qt")]
			public int quantity { get; set; }

			[JsonPropertyName("lqt")]
			public int loadingQuantity { get; set; }

			[JsonPropertyName("isd")]
			public AcPvEGameData.PvEFieldItemSkillData itemSkillData;
		}

		public class PvEFieldItemSkillData
		{
			public PvEFieldItemSkillData()
			{
			}

			public PvEFieldItemSkillData(AcPvEItemSkillData pveItemSkillData)
			{
				if (pveItemSkillData == null)
				{
					return;
				}
				this.offenceAdd = pveItemSkillData.offenceAdd;
				this.cumulativeDamage = pveItemSkillData.cumulativeDamage;
			}

			[JsonPropertyName("oa")]
			public int offenceAdd;

			[JsonPropertyName("cd")]
			public float cumulativeDamage;
		}*/
	}