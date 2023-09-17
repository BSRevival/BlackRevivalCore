using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Item;
public class FieldItem
	{
		public FieldItem()
		{
			this.fieldItemCode = "";
			this.item = 0;
			this.loadingQuantity = 0;
			this.attachedItem = new List<int>();
			this.quantity = 0;
			this.offence = 0f;
			this.offenceAdd = 0f;
			this.defence = 0f;
			this.defenceAdd = 0f;
		}

		public FieldItem(FieldItem item)
		{
			this.fieldItemCode = item.fieldItemCode;
			this.item = item.item;
			this.loadingQuantity = item.loadingQuantity;
			this.attachedItem = item.attachedItem;
			this.quantity = item.quantity;
			this.offence = item.offence;
			this.offenceAdd = item.offenceAdd;
			this.defence = item.defence;
			this.defenceAdd = item.defenceAdd;
			this.weaponAlmostBroken = item.weaponAlmostBroken;
			this.useSilencer = item.useSilencer;
			this.itemData = item.itemData;
		}

		[JsonIgnore]
		public ItemData ItemData
		{
			get
			{
				ItemData result;
				if ((result = this.itemData) == null)
				{
					result = (this.itemData = GameDB.ItemDB.Instance.Find(this.item));
				}
				return result;
			}
		}

		[JsonIgnore]
		public AcPvEItemSkillData p_pveItemSkillData
		{
			get
			{
				AcPvEItemSkillData result;
				if ((result = this._pveItemSkillData) == null)
				{
					result = (this._pveItemSkillData = new AcPvEItemSkillData());
				}
				return result;
			}
			set
			{
				this._pveItemSkillData = value;
			}
		}

		public bool IsEmpty()
		{
			return this.item == 0;
		}

		public string GetFieldCompleteName()
		{
			ItemData itemData = GameDB.ItemDB.Instance.Find(this.item);
			if (itemData.itemType == ItemType.WEAPON)
			{
				if (itemData.weaponType == AcE_WEAPON_TYPE.BOW || itemData.weaponType == AcE_WEAPON_TYPE.GUN)
				{
					if (itemData.IsProjectileWeapon())
					{
						return string.Format("[{2}]{0}[-] {1}", itemData.GetItemName(), LocalizationDB.Instance.StringFormat("{0}발", new object[] { this.loadingQuantity }), itemData.GetGradeColor(false));
					}
					return string.Format("[{1}]{0}[-]", itemData.GetItemName(), itemData.GetGradeColor(false));
				}
				else
				{
					if (itemData.weaponType == AcE_WEAPON_TYPE.THROW)
					{
						return string.Format("[{2}]{0}[-] {1}", itemData.GetItemName(), LocalizationDB.Instance.StringFormat("{0}개", new object[] { this.quantity }), itemData.GetGradeColor(false));
					}
					return string.Format("[{1}]{0}[-]", itemData.GetItemName(), itemData.GetGradeColor(false));
				}
			}
			else
			{
				if (itemData.IsMagazineItem() || itemData.IsQuiverItem())
				{
					return string.Format("[{2}]{0}[-] {1}", itemData.GetItemName(), LocalizationDB.Instance.StringFormat("{0}발", new object[] { this.loadingQuantity }), itemData.GetGradeColor(false));
				}
				if (itemData.IsStackableItem())
				{
					return string.Format("[{2}]{0}[-] {1}", itemData.GetItemName(), LocalizationDB.Instance.StringFormat("{0}개", new object[] { this.quantity }), itemData.GetGradeColor(false));
				}
				return string.Format("[{1}]{0}[-]", itemData.GetItemName(), itemData.GetGradeColor(false));
			}
		}

		public string GetFieldCompletePoint()
		{
			return string.Format("{0} {1}", this.ItemData.GetItemTypeName(), this.GetFieldActivePoint());
		}

		public string GetFieldActivePoint()
		{
			ItemData itemData = GameDB.ItemDB.Instance.Find(this.item);
			if (itemData.itemType == ItemType.WEAPON)
			{
				if (this.offenceAdd > 0f)
				{
					return string.Format("{0}([54CA58]+{1}[-])", (int)Math.Truncate((double)this.offence), (int)Math.Truncate((double)this.offenceAdd));
				}
				if (this.offenceAdd < 0f)
				{
					return string.Format("{0}([F22613]{1}[-])", (int)Math.Truncate((double)this.offence), (int)Math.Truncate((double)this.offenceAdd));
				}
				if (this.offence > 0f)
				{
					return string.Format("{0}", (int)Math.Truncate((double)this.offence));
				}
			}
			else if (itemData.GetActivePoint() > 0)
			{
				if (this.defenceAdd > 0f)
				{
					return string.Format("{0}([54CA58]+{1}[-])", itemData.GetActivePoint(), (int)Math.Truncate((double)this.defenceAdd));
				}
				if (this.defenceAdd < 0f)
				{
					return string.Format("{0}([F22613]{1}[-])", itemData.GetActivePoint(), (int)Math.Truncate((double)this.defenceAdd));
				}
				return itemData.GetActivePoint().ToString();
			}
			return "";
		}

		public object DeepCopy()
		{
			FieldItem fieldItem = new FieldItem();
			fieldItem.fieldItemCode = this.fieldItemCode;
			fieldItem.item = this.item;
			fieldItem.loadingQuantity = this.loadingQuantity;
			fieldItem.attachedItem = new List<int>();
			fieldItem.attachedItem.AddRange(this.attachedItem);
			fieldItem.quantity = this.quantity;
			fieldItem.offence = this.offence;
			fieldItem.offenceAdd = this.offenceAdd;
			fieldItem.weaponAlmostBroken = this.weaponAlmostBroken;
			return fieldItem;
		}

		public int GetItemCode()
		{
			int result;
			if (!int.TryParse(this.fieldItemCode, out result))
			{
				return 0;
			}
			return result;
		}

		public ItemSubType GetItemSubType()
		{
			return GameDB.ItemDB.Instance.Find(this.item).itemSubType;
		}

		public bool IsPVELoadableForWeapon(LoadableType loadableType, int loadingQuantity)
		{
			return this.ItemData != null && this.ItemData.itemType == ItemType.WEAPON && this.ItemData.IsPVEProjectileWeapon() && this.ItemData.loadableType == loadableType && this.ItemData.loadingCapacity - loadingQuantity > 0;
		}

		public int GetLoadableCount()
		{
			if (this.ItemData.loadableType == LoadableType.NONE)
			{
				return 0;
			}
			return this.ItemData.loadingCapacity - this.loadingQuantity;
		}

		public int GetLoadableCount(int ammoCount)
		{
			if (this.ItemData.loadableType == LoadableType.NONE)
			{
				return 0;
			}
			return (int)MathF.Min(this.ItemData.loadingCapacity - this.loadingQuantity, ammoCount);
		}

		public void ClearPvEItemSkillDataForBattleEffect()
		{
			if (this._pveItemSkillData != null)
			{
				this._pveItemSkillData.Clear();
			}
		}

		[JsonPropertyName("fin")]
		public string fieldItemCode { get; set; }

		[JsonPropertyName("itm")]
		public int item { get; set; }

		[JsonPropertyName("lqt")]
		public int loadingQuantity { get; set; }

		[JsonPropertyName("aiids")]
		public List<int> attachedItem { get; set; }

		[JsonPropertyName("bqt")]
		public int quantity { get; set; }

		[JsonPropertyName("ofc")]
		public float offence { get; set; }

		[JsonPropertyName("ofe")]
		public float offenceAdd { get; set; }

		[JsonPropertyName("dfc")]
		public float defence { get; set; }

		[JsonPropertyName("dfe")]
		public float defenceAdd { get; set; }

		[JsonPropertyName("alb")]
		public bool weaponAlmostBroken { get; set; }

		[JsonPropertyName("sil")]
		public bool useSilencer { get; set; }

		private ItemData itemData { get; set; }

		private AcPvEItemSkillData _pveItemSkillData { get; set; }
	}
