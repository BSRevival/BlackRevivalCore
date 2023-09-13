
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public class Goods
    {
		private GoodsType _goodsType;

		private string _subType;

		[JsonPropertyName("c")]
		private string goodsCode;

		[JsonPropertyName("a")]
		public int amount;

		public GoodsType goodsType
		{
			get
			{
				if (_goodsType == GoodsType.NONE)
				{
					extractFromCode();
				}
				return _goodsType;
			}
			private set
			{
				_goodsType = value;
			}
		}

		public string subType
		{
			get
			{
				if (string.IsNullOrEmpty(_subType))
				{
					extractFromCode();
				}
				return _subType;
			}
			set
			{
				_subType = value;
			}
		}

		private void extractFromCode()
		{
			string[] array = goodsCode.Split("-".ToCharArray(), 2);
			if (array.Length >= 2)
			{
				goodsType = (GoodsType)int.Parse(array[0]);
				subType = array[1];
			}
		}

		public Goods()
		{
		}

		public Goods(GoodsType goodsType, string subType, int amount)
		{
			this.goodsType = goodsType;
			this.subType = subType;
			this.amount = amount;
			goodsCode = string.Format("{0}-{1}", Convert.ToInt32(goodsType), subType);
		}

		public Goods(Goods goods)
		{
			goodsType = goods.goodsType;
			subType = goods.subType;
			amount = goods.amount;
			goodsCode = string.Format("{0}-{1}", Convert.ToInt32(goods.goodsType), goods.subType);
		}

		private void Init()
		{
		}

		//public string GetDetailName()
		//{
		//	StringUtil.ClearText();
		//	switch (goodsType)
		//	{
		//		case GoodsType.CHARACTER_SKIN:
		//			return StringUtil.AppendText(GetName(), " " + LocalizationDB.IgnoreDynamic("스킨"));
		//		case GoodsType.LIVE2D_SKIN:
		//			return StringUtil.AppendText(GetName(), " Live2D");
		//		default:
		//			return GetName();
		//	}
		//}

		//public string GetName()
		//{
		//	switch (goodsType)
		//	{
		//		case GoodsType.ASSET:
		//			switch (AcEnum.Convert<AssetType>(subType))
		//			{
		//				case AssetType.BEARPOINT:
		//					return LocalizationDB.Dynamic("베어포인트");
		//				case AssetType.GEM:
		//					return LocalizationDB.Dynamic("보석");
		//				case AssetType.GOLD:
		//					return LocalizationDB.Dynamic("금화");
		//				case AssetType.CREDIT:
		//					return LocalizationDB.Dynamic("크레딧");
		//				case AssetType.MILEAGE:
		//					return LocalizationDB.Dynamic("마일리지");
		//				case AssetType.EXPERIMENT_MEMORY:
		//					return LocalizationDB.Dynamic("GoodsName/EXPERIMENT_MEMORY");
		//				case AssetType.TOURNAMENT_POINT:
		//					return LocalizationDB.Dynamic("GoodsName/TOURNAMENT_POINT");
		//				case AssetType.TOURNAMENT_TICKET:
		//					return LocalizationDB.Dynamic("GoodsName/TOURNAMENT_TICKET");
		//				case AssetType.VOTE_TICKET:
		//					return LocalizationDB.Dynamic("GoodsName/SEASON_VOTE");
		//				case AssetType.VOTE_STAMP:
		//					return LocalizationDB.Dynamic("GoodsName/VOTE_STAMP");
		//				case AssetType.LABYRINTH_POINT:
		//					return LocalizationDB.Dynamic("Not Implemnt");
		//				default:
		//					return "Error";
		//			}
		//		case GoodsType.CHARACTER:
		//		case GoodsType.CHARACTER_MAXGRADE:
		//			return GameDB.character.GetCharacterName(GetIntSubType());
		//		case GoodsType.CHARACTER_SKIN:
		//		case GoodsType.LIVE2D_SKIN:
		//			return GameDB.character.GetSkinName(GetIntSubType());
		//		case GoodsType.POTENTIAL_SKILL:
		//			{
		//				PotentialSkillData potentialSkillData = GameDB.product.FindPotentialSkillData(subType);
		//				return GameDB.skill.Find(potentialSkillData.characterSpecialty).GetName();
		//			}
		//		case GoodsType.LIVE2D_SKIN_TICKET:
		//			return string.Format(LocalizationDB.Dynamic("GoodsName/LIVE2D_SKIN_TICKET"), GameDB.character.GetSkinName(GetIntSubType()));
		//		case GoodsType.FURNITURE:
		//			{
		//				FurnitureType furnitureType = GameDB.product.FindFurniture(subType);
		//				if (furnitureType != null)
		//				{
		//					return LocalizationDB.Dynamic(string.Format("Furniture/Name/{0}", furnitureType.p_code));
		//				}
		//				return string.Empty;
		//			}
		//		case GoodsType.AVATAR:
		//			{
		//				AvatarType avatarType = GameDB.product.FindAvatar(subType);
		//				if (avatarType != null)
		//				{
		//					return LocalizationDB.Dynamic(string.Format("GoodsName/AVATAR/{0:00000}", avatarType.p_code));
		//				}
		//				return string.Empty;
		//			}
		//		case GoodsType.EXPERIENCE_TICKET:
		//			return string.Format(LocalizationDB.Dynamic("GoodsName/EXPERIENCE_TICKET"), GameDB.character.GetSkinName(GetIntSubType()));
		//		case GoodsType.EXPERIENCE_SKIN:
		//			return string.Format(LocalizationDB.Dynamic("GoodsName/EXPERIENCE_SKIN"), GameDB.character.GetSkinName(GetIntSubType()));
		//		case GoodsType.PACK:
		//			{
		//				PackData packData = GameDB.product.FindPackData(subType);
		//				return ((packData != null) ? packData.GetName() : null) ?? GetDefaultName();
		//			}
		//		case GoodsType.DNA:
		//			{
		//				ValueTuple<string, string> subTypeInfo;
		//				if (IsValidSampleType() || !TryGetExtractSubType(out subTypeInfo))
		//				{
		//					return GetDefaultName();
		//				}
		//				return AcSingleton<AcPlayerInfo>.Instance.p_signatureManager.GetSignatureName(subTypeInfo.Item1, subTypeInfo.Item2);
		//			}
		//		default:
		//			return GetDefaultName();
		//	}
		//}

		//private string GetDefaultName()
		//{
		//	string text = LocalizationDB.Dynamic("GoodsName/" + goodsType.ToString() + "/" + subType);
		//	if (!string.IsNullOrEmpty(text))
		//	{
		//		return text;
		//	}
		//	return "Error";
		//}

		//public string GetDesc()
		//{
		//	switch (goodsType)
		//	{
		//		case GoodsType.POTENTIAL_SKILL:
		//			{
		//				PotentialSkillData potentialSkillData = GameDB.product.FindPotentialSkillData(subType);
		//				return GameDB.skill.Find(potentialSkillData.characterSpecialty).GetDesc();
		//			}
		//		case GoodsType.LIVE2D_SKIN_TICKET:
		//			return string.Format(LocalizationDB.Dynamic("GoodsDesc/LIVE2D_SKIN_TICKET"), GameDB.character.GetSkinName(GetIntSubType()));
		//		case GoodsType.FURNITURE:
		//			{
		//				FurnitureType furnitureType = GameDB.product.FindFurniture(subType);
		//				if (furnitureType != null)
		//				{
		//					return LocalizationDB.Dynamic(string.Format("Furniture/Desc/{0}", furnitureType.p_code));
		//				}
		//				return string.Empty;
		//			}
		//		case GoodsType.AVATAR:
		//			{
		//				AvatarType avatarType = GameDB.product.FindAvatar(subType);
		//				if (avatarType != null)
		//				{
		//					return LocalizationDB.Dynamic(string.Format("GoodsDesc/AVATAR/{0:00000}", avatarType.p_code));
		//				}
		//				return string.Empty;
		//			}
		//		case GoodsType.EXPERIENCE_TICKET:
		//			return string.Format(LocalizationDB.Dynamic("GoodsDesc/EXPERIENCE_TICKET"), GameDB.character.GetSkinName(GetIntSubType()));
		//		case GoodsType.EXPERIENCE_SKIN:
		//			return string.Format(LocalizationDB.Dynamic("GoodsDesc/EXPERIENCE_SKIN"), GameDB.character.GetSkinName(GetIntSubType()), GetAmount());
		//		case GoodsType.CHARACTER_SKIN:
		//			return LocalizationDB.Dynamic(string.Format("skinDesc_{0:00000}", GetIntSubType()));
		//		case GoodsType.MEMBERSHIP:
		//			{
		//				MembershipType outType;
		//				if (AcEnum.TryGetValue<MembershipType>(subType, out outType) && outType == MembershipType.LABYRINTH_MEMBERSHIP)
		//				{
		//					return LocalizationDB.StringFormat(string.Format("GoodsDesc/{0}/{1}", goodsType, subType), AcSingleton<AcPlayerInfo>.Instance.p_invenManager.GetPvEMembershipTicketCount());
		//				}
		//				return LocalizationDB.Dynamic("GoodsDesc/" + goodsType.ToString() + "/" + subType);
		//			}
		//		case GoodsType.PACK:
		//			{
		//				PackData packData = GameDB.product.FindPackData(subType);
		//				return ((packData != null) ? packData.GetDesc() : null) ?? GetDefaultDesc();
		//			}
		//		case GoodsType.DNA:
		//			{
		//				InvenGoods invenGoods;
		//				ValueTuple<string, string> subTypeInfo;
		//				if (IsValidSampleType() || (invenGoods = this as InvenGoods) == null || !invenGoods.TryGetExtractSubType(out subTypeInfo))
		//				{
		//					return GetDefaultDesc();
		//				}
		//				return LocalizationDB.StringFormat("GoodsDesc/DNA/DNA", GameDB.character.GetCharacterName(subTypeInfo.Item1), AcEnum.Convert<AcE_SignatureType>(subTypeInfo.Item2).GetTypeText());
		//			}
		//		default:
		//			return GetDefaultDesc();
		//	}
		//}

		//private string GetDefaultDesc()
		//{
		//	string text = LocalizationDB.Dynamic("GoodsDesc/" + goodsType.ToString() + "/" + subType);
		//	if (!string.IsNullOrEmpty(text))
		//	{
		//		return text;
		//	}
		//	return "Error";
		//}

		//public string GetCaution(PackData packData)
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.PACK)
		//	{
		//		return LocalizationDB.Dynamic(string.Format("GoodsCaution/{0}/{1}", this.goodsType, packData.packDetailType));
		//	}
		//	return LocalizationDB.Dynamic(string.Format("GoodsCaution/{0}/{1}", this.goodsType, subType));
		//}

		//public string GetConcept()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.CHARACTER_SKIN || goodsType == GoodsType.LIVE2D_SKIN_TICKET)
		//	{
		//		return LocalizationDB.Dynamic("Concept/Skin_Name/" + subType);
		//	}
		//	string text = LocalizationDB.Dynamic(string.Format("GoodsDesc/{0}/{1}", this.goodsType.ToString(), subType));
		//	if (string.IsNullOrEmpty(text))
		//	{
		//		return "Error";
		//	}
		//	return text;
		//}

		//public string GetDescAdd()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.AVATAR)
		//	{
		//		AvatarType avatarType = GameDB.product.FindAvatar(subType);
		//		if (avatarType == null)
		//		{
		//			return string.Empty;
		//		}
		//		return LocalizationDB.IgnoreDynamic(string.Format("GoodsDescAdd/{0}/{1:00000}", this.goodsType.ToString(), avatarType.p_code));
		//	}
		//	return LocalizationDB.IgnoreDynamic(string.Format("GoodsDescAdd/{0}/{1}", this.goodsType.ToString(), subType));
		//}

		//public INGUIAtlas GetSpriteAtlas()
		//{
		//	switch (goodsType)
		//	{
		//		case GoodsType.CHARACTER:
		//		case GoodsType.CHARACTER_MAXGRADE:
		//		case GoodsType.CHARACTER_SKIN:
		//		case GoodsType.BOOSTER:
		//		case GoodsType.BOOSTER_DURATION:
		//		case GoodsType.MEMBERSHIP:
		//		case GoodsType.CHANGE_TICKET:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.LobbyUI_4th);
		//		case GoodsType.TICKET:
		//			if (!(subType == "CHARACTER_EXP_25"))
		//			{
		//				return null;
		//			}
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.LobbyUI_4th);
		//		case GoodsType.SUPPLY_BOX:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas((!(subType == SupplyBoxType.ICE_BOX.ToString())) ? AcE_ATLAS_TYPE.LobbyUI_4th : AcE_ATLAS_TYPE.Common);
		//		case GoodsType.POTENTIAL_SKILL:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.PotentialIcons);
		//		case GoodsType.INSTANT:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas((subType == "CHARACTER_EXP_25") ? AcE_ATLAS_TYPE.LobbyUI_4th : AcE_ATLAS_TYPE.Common);
		//		case GoodsType.RESEARCHER_TITLE:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.Common_2);
		//		case GoodsType.PACK:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.LobbyUI_6th);
		//		case GoodsType.DNA:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.LobbyUI_7th);
		//		default:
		//			return AcSingleton<AcResourceManager>.Instance.LoadINGUIAtlas(AcE_ATLAS_TYPE.Common);
		//	}
		//}

		//public string GetSpriteName()
		//{
		//	switch (goodsType)
		//	{
		//		case GoodsType.ASSET:
		//			switch (AcEnum.Convert<AssetType>(subType))
		//			{
		//				case AssetType.BEARPOINT:
		//					return "Common_Icon_BearPoint";
		//				case AssetType.GEM:
		//					return "Common_Icon_Gem";
		//				case AssetType.GOLD:
		//					return "Common_Icon_Gold";
		//				case AssetType.CREDIT:
		//					return "Common_Icon_Credit";
		//				case AssetType.MILEAGE:
		//					return "Common_Icon_Mileage";
		//				case AssetType.EXPERIMENT_MEMORY:
		//					return "Common_Icon_Experimental_memory";
		//				case AssetType.TOURNAMENT_POINT:
		//					return "Tp_Icon";
		//				case AssetType.TOURNAMENT_TICKET:
		//					return "Tournament_Ticket";
		//				case AssetType.VOTE_TICKET:
		//					return "Common_VoteToken";
		//				case AssetType.VOTE_STAMP:
		//					return "Common_Icon_Vote_Stamp";
		//				case AssetType.LABYRINTH_POINT:
		//					return "Common_Icon_PvE_Point";
		//			}
		//			break;
		//		case GoodsType.CHARACTER:
		//		case GoodsType.CHARACTER_MAXGRADE:
		//		case GoodsType.CHARACTER_SKIN:
		//			return "Lobby_Shop_Characterpack_Icon";
		//		case GoodsType.TICKET:
		//			if (!(subType == "CHARACTER_EXP_25"))
		//			{
		//				return string.Empty;
		//			}
		//			return "Lobby_Shop_Icon_Confidencesyringe";
		//		case GoodsType.SUPPLY_BOX:
		//			switch (AcEnum.Convert<SupplyBoxType>(subType))
		//			{
		//				case SupplyBoxType.OFFENSIVE_BOX:
		//					return "Lobby_Shop_Item_SBGM001";
		//				case SupplyBoxType.DEFENSIVE_BOX:
		//					return "Lobby_Shop_Item_SBGM002";
		//				case SupplyBoxType.ICE_BOX:
		//					return "Lobby_Shop_Item_SBGM003";
		//			}
		//			break;
		//		case GoodsType.BOOSTER:
		//		case GoodsType.BOOSTER_DURATION:
		//			switch (AcEnum.Convert<BoosterType>(subType))
		//			{
		//				case BoosterType.GOLD:
		//					return "Lobby_Shop_Item_GBGM002";
		//				case BoosterType.CHARACTER_EXP:
		//					return "Lobby_StartOpt_Icon_Confidencebooster";
		//				case BoosterType.RANKPOINT:
		//					return "Lobby_Shop_Item_EBGM002";
		//				case BoosterType.BEARPOINT:
		//					return "Lobby_Starterpack_Pic_Bearpoint";
		//			}
		//			break;
		//		case GoodsType.POTENTIAL_SKILL:
		//			{
		//				PotentialSkillData potentialSkillData = GameDB.product.FindPotentialSkillData(subType);
		//				return GameDB.skill.Find(potentialSkillData.characterSpecialty).GetIconSprite();
		//			}
		//		case GoodsType.MEMBERSHIP:
		//			switch (AcEnum.Convert<MembershipType>(subType))
		//			{
		//				case MembershipType.REVIVE:
		//					return "Common_Icon_ArsBe";
		//				case MembershipType.RESEARCH_SUPPORT:
		//					return "Common_Icon_RSupport";
		//				case MembershipType.EXPERT_RESEARCH_SUPPORT:
		//					return "Common_Icon_ExpertRSupport";
		//				case MembershipType.TOURNAMENT_TICKET_SUPPORT:
		//					return "TournamentMembership";
		//				case MembershipType.LABYRINTH_MEMBERSHIP:
		//					return "PvE_Membership";
		//				case MembershipType.LABYRINTH_BOOSTER:
		//					return "PvE_Booster";
		//				default:
		//					return string.Empty;
		//			}
		//		case GoodsType.AGLAIA_PASS:
		//			return "Common_Icon_Apass";
		//		case GoodsType.AGLAIA_PASS_STORY:
		//			return "Common_Icon_play";
		//		case GoodsType.INSTANT:
		//			if (!(subType == "CHARACTER_EXP_25"))
		//			{
		//				return "Lobby_Mail_Icon_Giftbox";
		//			}
		//			return "Lobby_Shop_Icon_Confidencesyringe";
		//		case GoodsType.EXPERIENCE_TICKET:
		//		case GoodsType.EXPERIENCE_SKIN:
		//			return "Common_Icon_ExperienceSkin";
		//		case GoodsType.RESEARCHER_TITLE:
		//			{
		//				ResearcherTitleType researcherTitleType = GameDB.product.FindResearcherTitle(subType);
		//				if (researcherTitleType == null)
		//				{
		//					return null;
		//				}
		//				return researcherTitleType.p_texture;
		//			}
		//		case GoodsType.CHANGE_TICKET:
		//			{
		//				Product changeTicket = GameDB.product.GetChangeTicket(subType);
		//				if (changeTicket != null)
		//				{
		//					return AcProductConfig.GetProductName(changeTicket.productId).GetSpriteName();
		//				}
		//				return string.Empty;
		//			}
		//	}
		//	return "Lobby_Mail_Icon_Giftbox";
		//}

		//public string GetAmountFmt()
		//{
		//	if (goodsType.GetAmountType() == AmountType.PERIOD_DAYS)
		//	{
		//		return LocalizationDB.Dynamic("{0}일");
		//	}
		//	switch (goodsType)
		//	{
		//		case GoodsType.ASSET:
		//			if (subType == AssetType.BEARPOINT.ToString())
		//			{
		//				return LocalizationDB.Dynamic("{0}점");
		//			}
		//			if (!(subType == AssetType.GEM.ToString()))
		//			{
		//				bool flag = subType == AssetType.GOLD.ToString();
		//			}
		//			return LocalizationDB.Dynamic("{0}개");
		//		case GoodsType.CHARACTER:
		//			return LocalizationDB.Dynamic("{0}종");
		//		case GoodsType.AGLAIA_PASS:
		//			return LocalizationDB.StringFormat("SB_AP_48", amount);
		//		default:
		//			return LocalizationDB.Dynamic("{0}개");
		//	}
		//}

		//public string GetAmount()
		//{
		//	return string.Format(GetAmountFmt(), amount);
		//}

		//public string GetNameWithAmount()
		//{
		//	return string.Format(GetName() + " " + GetAmountFmt(), amount);
		//}

		//public string GetNameWithAmount2Line()
		//{
		//	return string.Format(GetName() + "\n" + GetAmountFmt(), amount);
		//}

		//public string GetMailTypeDesc()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.ASSET)
		//	{
		//		if (subType == AssetType.BEARPOINT.ToString())
		//		{
		//			return LocalizationControl.GetTextData(eTextPath_01.Lobby_LUI, eTextPath_02.Mail, "Get_BP");
		//		}
		//		if (subType == AssetType.GEM.ToString())
		//		{
		//			return LocalizationControl.GetTextData(eTextPath_01.Lobby_LUI, eTextPath_02.Mail, "Get_Jewel");
		//		}
		//		if (subType == AssetType.GOLD.ToString())
		//		{
		//			return LocalizationControl.GetTextData(eTextPath_01.Lobby_LUI, eTextPath_02.Mail, "Get_Gold");
		//		}
		//	}
		//	return LocalizationDB.Dynamic("선물상자");
		//}

		//public string GetLobby4thSprite()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.ASSET)
		//	{
		//		if (subType == AssetType.BEARPOINT.ToString())
		//		{
		//			return "Lobby_Starterpack_Pic_Bearpoint";
		//		}
		//		if (subType == AssetType.GEM.ToString())
		//		{
		//			return "Lobby_Shop_Item_GMIP001";
		//		}
		//		if (subType == AssetType.GOLD.ToString())
		//		{
		//			return "Lobby_Shop_Item_GDGM001";
		//		}
		//	}
		//	return "Lobby_Mail_Icon_Giftbox";
		//}

		//public int GetIntSubType()
		//{
		//	try
		//	{
		//		return Convert.ToInt32(subType);
		//	}
		//	catch (FormatException arg)
		//	{
		//		AcLogger.LogError(string.Format("Error || {0} || {1}", arg, subType));
		//		return 0;
		//	}
		//}

		//public string GetAglaiaPassDetail()
		//{
		//	switch (goodsType)
		//	{
		//		case GoodsType.AGLAIA_PASS_STORY:
		//			return LocalizationDB.Dynamic("SB_AP_39");
		//		case GoodsType.CHARACTER_SKIN:
		//			return LocalizationDB.Dynamic("SB_AP_40");
		//		case GoodsType.LIVE2D_SKIN_TICKET:
		//			return LocalizationDB.Dynamic("SB_AP_41");
		//		case GoodsType.BGM:
		//			return LocalizationDB.Dynamic("SB_AP_47");
		//		default:
		//			return amount.ToString();
		//	}
		//}

		//public bool IsAglaiaPassSpecialReward()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if ((uint)(goodsType - 4) <= 1u || goodsType == GoodsType.BGM)
		//	{
		//		return true;
		//	}
		//	return false;
		//}

		//public bool IsTargetAssetType(AssetType targetType)
		//{
		//	if (goodsType == GoodsType.ASSET)
		//	{
		//		return AcEnum.Convert<AssetType>(subType) == targetType;
		//	}
		//	return false;
		//}

		//public bool IsDnaType()
		//{
		//	if (IsDnaCategory())
		//	{
		//		return !IsValidSampleType();
		//	}
		//	return false;
		//}

		//public bool IsValidSampleType()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.DNA)
		//	{
		//		return subType.Contains("SAMPLE");
		//	}
		//	return false;
		//}

		//public bool IsDnaCategory()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.DNA)
		//	{
		//		return true;
		//	}
		//	return false;
		//}

		//public string GetAssetTextureName()
		//{
		//	AssetType outType;
		//	if (!AcEnum.TryGetValue<AssetType>(subType, out outType))
		//	{
		//		return "rainbow";
		//	}
		//	return outType.GetAssetTexture(amount);
		//}

		//public Texture GetAssetTexture()
		//{
		//	return AcSingleton<AcResourceManager>.Instance.LoadTexture(GetAssetTextureName());
		//}
		////public bool TryGetConvertExtractSubType([TupleElementNames(new string[] { "character", "signatureType" })] out ValueTuple<AcE_CharacterClass, AcE_SignatureType> subTypeInfo)
		//public bool TryGetConvertExtractSubType(out ValueTuple<AcE_CharacterClass, AcE_SignatureType> subTypeInfo)
		//{
		//	ValueTuple<string, string> extractSubType = GetExtractSubType();
		//	string item = extractSubType.Item1;
		//	string item2 = extractSubType.Item2;
		//	subTypeInfo = new ValueTuple<AcE_CharacterClass, AcE_SignatureType>(AcEnum.ConvertAllCase<AcE_CharacterClass>(item), AcEnum.ConvertAllCase<AcE_SignatureType>(item2));
		//	ValueTuple<AcE_CharacterClass, AcE_SignatureType> valueTuple = subTypeInfo;
		//	if (valueTuple.Item1 == AcE_CharacterClass.None)
		//	{
		//		return valueTuple.Item2 != AcE_SignatureType.NONE;
		//	}
		//	return true;
		//}
		////public bool TryGetExtractSubType([TupleElementNames(new string[] { "character", "signatureType" })] out ValueTuple<string, string> subTypeInfo)
		//public bool TryGetExtractSubType(out ValueTuple<string, string> subTypeInfo)
		//{
		//	subTypeInfo = GetExtractSubType();
		//	ValueTuple<string, string> valueTuple = subTypeInfo;
		//	string empty = string.Empty;
		//	string empty2 = string.Empty;
		//	if (!(valueTuple.Item1 != empty))
		//	{
		//		return valueTuple.Item2 != empty2;
		//	}
		//	return true;
		//}

		//public ValueTuple<string, string> GetExtractSubType()
		//{
		//	GoodsType goodsType = this.goodsType;
		//	if (goodsType == GoodsType.DNA)
		//	{
		//		string[] array = subType.Split('-');
		//		if (array.Length >= 2)
		//		{
		//			return new ValueTuple<string, string>(array.FirstOrDefault(), array.LastOrDefault());
		//		}
		//		return new ValueTuple<string, string>(string.Empty, string.Empty);
		//	}
		//	AcLogger.SimpleTrace("Wrong Call || subType == " + subType);
		//	return new ValueTuple<string, string>(string.Empty, string.Empty);
		//}
	}
}
