using System.Runtime.CompilerServices;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.ProductRelated;
using BlackRevival.Common.GameDB.Roulette;
using BlackRevival.Common.GameDB.Skills;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;
using Serilog;
using TicketType = BlackRevival.Common.GameDB.ProductRelated.TicketType;

namespace BlackRevival.Common.GameDB;

public class ProductDB
{
    	public ProductDB()
	{
	}

	public ProductDB(ProductDB.Model model)
	{
		products = model.products;
		roulettes = model.roulettes;
		rouletteGrades = model.rouletteGrades;
		potentialSkills = model.potentialSkills;
		packs = model.packs;
		tickets = model.tickets;
		offlineGoods = model.offlines;
		DataLoad();
		SkinTicketList();
	}

	public void DataLoad()
	{
		AcXml acXml = new AcXml();
		if (acXml.Load("Data/Xmls/FurnitureData.xml", true))
		{
			acXml.GetAllChildData("FurnitureData", "Code", "Furniture_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				furniture.Add(new FurnitureType(item));
			});
		}
		if (acXml.Load("Data/Xmls/BackgroundTypeData.xml", true))
		{
			acXml.GetAllChildData("BackgroundTypeData", "BackgroundType", "BackgroundType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				background.Add(new BackgroundType(item));
			});
		}
		if (acXml.Load("Data/Xmls/AvatarTypeData.xml", true))
		{
			acXml.GetAllChildData("AvatarTypeData", "AvatarType", "AvatarType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				avatars.Add(new AvatarType(item));
			});
		}
		if (acXml.Load("Data/Xmls/CharacterVoiceTypeData.xml", true))
		{
			acXml.GetAllChildData("CharacterVoiceTypeData", "Type", "CharacterVoiceType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				characterVoices.Add(new CharacterVoiceType(item));
			});
		}
		if (acXml.Load("Data/Xmls/BgmTypeData.xml", true))
		{
			acXml.GetAllChildData("BgmTypeData", "Type", "BgmType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				bgms.Add(new BgmType(item));
			});
		}
		if (acXml.Load("Data/Xmls/EmoticonTypeData.xml", true))
		{
			acXml.GetAllChildData("EmoticonTypeData", "Type", "EmoticonType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				emoticons.Add(new EmoticonType(item));
			});
		}
		if (acXml.Load("Data/Xmls/LanternTypeData.xml", true))
		{
			acXml.GetAllChildData("LanternTypeData", "Type", "LanternType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				lanterns.Add(new LanternType(item));
			});
		}
		if (acXml.Load("Data/Xmls/AnnounceTypeData.xml", true))
		{
			acXml.GetAllChildData("AnnounceTypeData", "Type", "AnnounceType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				announces.Add(new AnnounceType(item));
			});
		}
		if (acXml.Load("Data/Xmls/MonologueTypeData.xml", true))
		{
			acXml.GetAllChildData("MonologueTypeData", "Type", "MonologueType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				monologues.Add(new MonologueType(item));
			});
		}
		if (acXml.Load("Data/Xmls/ResearcherTitleTypeData.xml", true))
		{
			acXml.GetAllChildData("ResearcherTitleTypeData", "Code", "ResearcherTitleType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				researcherTitles.Add(new ResearcherTitleType(item));
			});
		}
		if (acXml.Load("Data/Xmls/PowcampDecoTypeData.xml", true))
		{
			acXml.GetAllChildData("PowcampDecoTypeData", "Code", "PowcampDecoType_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				powcampDecos.Add(new PowcampDecoType(item));
			});
		}
		if (acXml.Load("Data/Xmls/MatchingCardTypeData.xml", true))
		{
			acXml.GetAllChildData("MatchingCardTypeData", "BackgroundType", "MatchingCard_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				matchingCards.Add(new MatchingCardType(item));
			});
		}
	}

	private void SkinTicketList()
	{
		for (int i = 0; i < products.Count; i++)
		{
			Product product = products[i];
			if (product.goods.goodsType == GoodsType.LIVE2D_SKIN_TICKET)
			{
				skinTicket.Add(product);
			}
		}
	}

	public bool IsSkinWithTicket(int skinCode)
	{
		return GetSkinTicket(skinCode) != null;
	}

	public Product GetSkinTicket(int skinCode)
	{
		return skinTicket.Find((Product item) => item.goods.GetIntSubType() == skinCode);
	}

	public Product Find(string productId)
	{
		Product product = products.Find((Product data) => data.productId == productId);
		if (product == null)
		{
			Log.Error("[ProductDB.Find data is null] productId = " + productId);
		}
		return product;
	}

	public List<Product> FindAllByType(GoodsType GoodsType)
	{
		return products.FindAll((Product data) => data.goods.goodsType == GoodsType);
	}

	public Product FindIdByType(GoodsType goodsType, string productId)
	{
		return FindAllByType(goodsType).Find((Product x) => x.productId == productId);
	}

	public bool TryFindType(GoodsType goodsType, string subType, out Product product)
	{
		product = FindType(goodsType, subType);
		return product != null;
	}

	public Product FindType(GoodsType goodsType, string subType)
	{
		Product product = products.Find((Product data) => data.goods.goodsType == goodsType && data.goods.subType == subType);
		if (product == null)
		{
			Log.Error(string.Concat(new object[] { "[ProductDB.FindType data is null] GoodsType = ", goodsType, "  subType = ", subType }));
		}
		return product;
	}

	public Product FindCharacter(int characterClass, PurchaseMethod purchaseMethod)
	{
		Product product = products.Find((Product data) => data.goods.goodsType == GoodsType.CHARACTER && data.goods.GetIntSubType() == characterClass && data.purchaseMethod == purchaseMethod);
		if (product == null)
		{
			Log.Error(string.Concat(new object[] { "[ProductDB.FindCharacter data is null] characterClass = ", characterClass, "  PurchaseMethod = ", purchaseMethod }));
		}
		return product;
	}

	public bool TryFindRoulette(AcE_ROULETTE_TYPE rouletteType, out Product product)
	{
		product = FindRoulette(rouletteType);
		return product != null;
	}

	public Product FindRoulette(AcE_ROULETTE_TYPE rouletteType)
	{
		Product product = FindType(GoodsType.ROULETTE, rouletteType.ToString());
		if (product == null)
		{
			Log.Error(string.Format("[ProductDB.FindRoulett data is null] {0} = {1}", "AcE_ROULETTE_TYPE", rouletteType));
		}
		return product;
	}

	public Product FindRoulette(PurchaseMethod purchaseMethod, int amount)
	{
		Product product = products.Find((Product data) => data.goods.goodsType == GoodsType.ROULETTE && data.purchaseMethod == purchaseMethod && data.goods.amount == amount);
		if (product == null)
		{
			Log.Error(string.Concat(new object[] { "[ProductDB.FindRoulett data is null] purchaseMethod = ", purchaseMethod, "  amount = ", amount }));
		}
		return product;
	}

	public List<Product> FindRouletteList(PurchaseMethod purchaseMethod, int amount)
	{
		return products.FindAll((Product data) => data.goods.goodsType == GoodsType.ROULETTE && data.purchaseMethod == purchaseMethod && data.goods.amount == amount);
	}

	public bool TryFindRouletteData(AcE_ROULETTE_TYPE type, out RouletteData rouletteData)
	{
		rouletteData = FindRouletteData(type);
		return rouletteData != null;
	}

	public RouletteData FindRouletteData(AcE_ROULETTE_TYPE type)
	{
		return FindRouletteData(type.ToString());
	}

	public RouletteData FindRouletteData(string rouletteType)
	{
		RouletteData rouletteData = roulettes.Find((RouletteData data) => data.type == rouletteType);
		if (rouletteData == null)
		{
			Log.Error("[ProductDB.FindRouletteData data is null] rouletteType = " + rouletteType);
		}
		return rouletteData;
	}

	public List<RouletteData> FindRouletteDataList(AcE_ROULETTE_TYPE type)
	{
		return FindRouletteDataList(type.ToString());
	}

	public List<RouletteData> FindRouletteDataList(string rouletteType)
	{
		List<RouletteData> list = roulettes.FindAll((RouletteData data) => data.type == rouletteType);
		if (list.Count <= 0)
		{
			Log.Error("[ProductDB.FindRouletteData data is Zero] rouletteType = " + rouletteType);
		}
		return list;
	}

	public bool TryFindRouletteInfo(AcE_ROULETTE_TYPE type, out ValueTuple<Product, RouletteData> info)
	{
		info = FindRouletteInfo(type);
		ValueTuple<Product, RouletteData> valueTuple = info;
		return valueTuple.Item1 != null || valueTuple.Item2 != null;
	}

	public ValueTuple<Product, RouletteData> FindRouletteInfo(AcE_ROULETTE_TYPE type)
	{
		return new ValueTuple<Product, RouletteData>(FindRoulette(type), FindRouletteData(type));
	}

	public bool CheckSchedule(AcE_ROULETTE_TYPE rouletteType)
	{
		RouletteData rouletteData = FindRouletteData(rouletteType.ToString());
		return rouletteData != null && DateTime.Compare(DateTime.Now, rouletteData.startDtm) > 0 && DateTime.Compare(DateTime.Now, rouletteData.endDtm) < 0;
	}

	public bool CheckServerTimeSchedule(AcE_ROULETTE_TYPE rouletteType)
	{
		RouletteData rouletteData = FindRouletteData(rouletteType.ToString());
		return rouletteData != null && DateTime.Compare(DateTime.UtcNow, rouletteData.startDtm) > 0 && DateTime.Compare(DateTime.UtcNow, rouletteData.endDtm) < 0;
	}

	public DateTime GetExpiredTime(AcE_ROULETTE_TYPE rouletteType)
	{
		RouletteData rouletteData = FindRouletteData(rouletteType.ToString());
		if (rouletteData != null && DateTime.Compare(DateTime.Now, rouletteData.endDtm) < 0)
		{
			return rouletteData.endDtm;
		}
		return DateTime.Now;
	}

	public RouletteGoodsGradeData FindRouletteGradeData(AcE_RouletteGoodsGrade gradeType)
	{
		return FindRouletteGradeData(gradeType.ToString());
	}

	public RouletteGoodsGradeData FindRouletteGradeData(string rouletteGrade)
	{
		RouletteGoodsGradeData rouletteGoodsGradeData = rouletteGrades.Find((RouletteGoodsGradeData data) => data.grade == rouletteGrade);
		if (rouletteGoodsGradeData == null)
		{
			Log.Error("[ProductDB.FindRouletteGradeData data is null] rouletteGrade = " + rouletteGrade);
		}
		return rouletteGoodsGradeData;
	}

	public Product FindCharacterSkin(int characterSkinType)
	{
		List<Product> list = products.FindAll((Product data) => (data.goods.goodsType == GoodsType.CHARACTER_SKIN || data.goods.goodsType == GoodsType.LIVE2D_SKIN) && data.goods.GetIntSubType() == characterSkinType);
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Product product = list.Find((Product x) => x.purchaseMethod > PurchaseMethod.NONE);
		if (product != null)
		{
			return product;
		}
		return list[0];
	}

	public Product FindCharacterRecover()
	{
		Product product = products.Find((Product data) => data.goods.goodsType == GoodsType.INSTANT && data.goods.subType == InstantType.CHARACTER_RECOVER.ToString());
		if (product == null)
		{
			Log.Error("[ProductDB.FindCharacterRecover data is null]");
		}
		return product;
	}

	public Product FindSupplyBox(string supplyBoxType)
	{
		Product product = products.Find((Product data) => data.goods.goodsType == GoodsType.SUPPLY_BOX && data.goods.subType == supplyBoxType);
		if (product == null)
		{
			Log.Error("[ProductDB.FindSupplyBox data is null] supplyBoxType = " + supplyBoxType);
		}
		return product;
	}

	public PotentialSkillData FindPotentialSkillData(string subType)
	{
		PotentialSkillData potentialSkillData = potentialSkills.Find((PotentialSkillData data) => data.type == subType);
		if (potentialSkillData == null)
		{
			Log.Error("[ProductDB.FindPotentialSkillData data is null] subType = " + subType);
		}
		return potentialSkillData;
	}

	public PackData FindPackData(string subType)
	{
		PackData packData = packs.Find((PackData data) => data.type == subType);
		if (packData == null)
		{
			Log.Error("[ProductDB.FindPackData data is null] subType = " + subType);
		}
		return packData;
	}

	public bool TryGetPackData(string productId, out PackData packData)
	{
		packData = null;
		Product product = products.Find((Product x) => x.productId == productId);
		if (product == null)
		{
			return false;
		}
		packData = packs.Find((PackData x) => x.type == product.goods.subType);
		return packData != null;
	}

	public FurnitureType FindFurniture(string subType)
	{
		FurnitureType furnitureType = furniture.Find((FurnitureType data) => data.p_type == subType);
		if (furnitureType == null)
		{
			Log.Error("[ProductDB.FindFurniture data is null] subType = " + subType);
		}
		return furnitureType;
	}

	public BackgroundType FindBackground(string subType)
	{
		BackgroundType backgroundType = background.Find((BackgroundType data) => data.p_type == subType);
		if (backgroundType == null)
		{
			Log.Error("[ProductDB.FindBackground data is null] subType = " + subType);
		}
		return backgroundType;
	}

	public AnnounceType FindAnnounce(string subType)
	{
		AnnounceType announceType = announces.Find((AnnounceType data) => data.p_type == subType);
		if (announceType == null)
		{
			Log.Error("[ProductDB.FindAnnounce data is null] subType = " + subType);
		}
		return announceType;
	}

	public LanternType FindLantern(string subType)
	{
		LanternType lanternType = lanterns.Find((LanternType data) => data.p_type == subType);
		if (lanternType == null)
		{
			Log.Error("[ProductDB.FindLantern data is null] subType = " + subType);
		}
		return lanternType;
	}

	public bool TryFindCharacterVoice(string subType, out CharacterVoiceType voiceType)
	{
		voiceType = FindCharacterVoice(subType);
		return voiceType != null;
	}

	public CharacterVoiceType FindCharacterVoice(string subType)
	{
		CharacterVoiceType characterVoiceType = characterVoices.Find((CharacterVoiceType data) => data.p_type == subType);
		if (characterVoiceType == null)
		{
			Log.Error("[ProductDB.FindCharacterVoice data is null] subType = " + subType);
		}
		return characterVoiceType;
	}

	public CharacterVoiceType FindCharacterVoiceBySkinCode(int skinCode)
	{
		CharacterVoiceType characterVoiceType = characterVoices.Find((CharacterVoiceType data) => data.p_skinCode == skinCode);
		if (characterVoiceType == null)
		{
			Log.Error("[ProductDB.FindCharacterVoiceBySkinCode data is null] skinCode = " + skinCode);
		}
		return characterVoiceType;
	}

	public AvatarType FindAvatar(string subType)
	{
		AvatarType avatarType = avatars.Find((AvatarType data) => data.p_type == subType);
		if (avatarType == null)
		{
			Log.Error("[ProductDB.FindAvatar data is null] subType = " + subType);
		}
		return avatarType;
	}

	public EmoticonType FindEmoticon(string subType)
	{
		EmoticonType emoticonType = emoticons.Find((EmoticonType data) => data.p_type == subType);
		if (emoticonType == null)
		{
			Log.Error("[ProductDB.FindEmoticon data is null] subType = " + subType);
		}
		return emoticonType;
	}

	public TicketType FindTicket(string subType)
	{
		var ticketType = tickets.Find((TicketType data) => data.type == subType);
		if (ticketType == null)
		{
			Log.Error("[ProductDB.FindTicket data is null] subType = " + subType);
		}
		return ticketType;
	}

	public Product GetAglaiaPassTicket(int episode)
	{
		string passName = string.Format("AGLAIA_PASS_{0}", episode);
		Product product = FindAllByType(GoodsType.TICKET).Find((Product x) => x.goods.subType.Equals(passName) && x.goods.amount.Equals(1));
		if (product == null)
		{
			Log.Error("[ProductDB.GetAglaiaPassTicket data is null] episode = " + episode);
		}
		return product;
	}

	public Product GetAglaiaPassTicket(int episode, bool isPaid)
	{
		string passName = string.Format("AGLAIA_PASS_{0}", episode);
		Product product = FindAllByType(GoodsType.TICKET).Find((Product x) => x.goods.subType == passName && x.goods.amount != 1 == isPaid);
		if (product == null)
		{
			Log.Error("[ProductDB.GetAglaiaPassTicket data is null] episode = " + episode);
		}
		return product;
	}

	public Product GetPremiumAglaiaPassTicket(int episode)
	{
		string passName = string.Format("AGLAIA_PASS_{0}", episode);
		Product product = FindAllByType(GoodsType.TICKET).Find((Product x) => x.goods.subType.Equals(passName) && x.goods.amount > 1);
		if (product == null)
		{
			Log.Error("[ProductDB.GetPremiumAglaiaPassTicket data is null] episode = " + episode);
		}
		return product;
	}

	public Product GetChangeTicket(string subType)
	{
		List<Product> list = FindAllByType(GoodsType.CHANGE_TICKET);
		Product product = ((list != null) ? list.Find((Product x) => x.goods.subType.EqualsFast(subType)) : null);
		if (product == null)
		{
			Log.Error("[ProductDB.GetChangeTicket data is null] subType = " + subType);
		}
		return product;
	}

	public BgmType FindBGM(string subType)
	{
		BgmType bgmType = bgms.Find((BgmType data) => data.p_type == subType);
		if (bgmType == null)
		{
			Log.Error("[ProductDB.FindBGM data is null] subType = " + subType);
		}
		return bgmType;
	}

	public MonologueType FindMonologue(string subType)
	{
		MonologueType monologueType = monologues.Find((MonologueType x) => x.p_type == subType);
		if (monologueType == null)
		{
			Log.Error("[ProductDB.FindMonologue data is null] subType = " + subType);
		}
		return monologueType;
	}

	public MonologueType FindMonologueBySkinType(int skinCode)
	{
		MonologueType monologueType = monologues.Find((MonologueType x) => x.p_characterSkinType == skinCode);
		if (monologueType == null)
		{
			Log.Error("[ProductDB.FindMonologueBySkinType data is null] skinCode = " + skinCode);
		}
		return monologueType;
	}

	public PowcampDecoType FindPowcampDeco(string subType)
	{
		PowcampDecoType powcampDecoType = powcampDecos.Find((PowcampDecoType x) => x.p_type == subType);
		if (powcampDecoType == null)
		{
			Log.Error("[ProductDB.FindPowcampDeco data is null] subType = " + subType);
		}
		return powcampDecoType;
	}

	public ResearcherTitleType FindResearcherTitle(string subType)
	{
		ResearcherTitleType researcherTitleType = researcherTitles.Find((ResearcherTitleType x) => x.p_type == subType);
		if (researcherTitleType == null)
		{
			Log.Error("[ProductDB.FindResearcherTitle data is null] subType = " + subType);
		}
		return researcherTitleType;
	}

	public ResearcherTitleType FindResearcherTitle(int id)
	{
		if (id == 0)
		{
			return null;
		}
		return researcherTitles.Find((ResearcherTitleType x) => x.p_code == id);
	}

	public OfflineType FindOfflineGoods(string subType)
	{
		OfflineType offlineType = offlineGoods.Find((OfflineType x) => x.type == subType);
		if (offlineType == null)
		{
			Log.Error("[ProductDB.FindOfflineGoods data is null] subType = " + subType);
		}
		return offlineType;
	}

	public MatchingCardType FindMatchingCard(int code)
	{
		if (code >= 0)
		{
			return matchingCards.Find((MatchingCardType x) => x.p_code == code);
		}
		return null;
	}

	public MatchingCardType FindMatchingCard(string subType)
	{
		MatchingCardType matchingCardType = matchingCards.Find((MatchingCardType x) => x.p_type == subType);
		if (matchingCardType == null)
		{
			Log.Error("[ProductDB.FindOfflineGoods data is null] subType = " + subType);
		}
		return matchingCardType;
	}
    
    public List<Product> products { get; set; }

    public List<RouletteData> roulettes { get; set; }

    public List<RouletteGoodsGradeData> rouletteGrades { get; set; }

    public List<PotentialSkillData> potentialSkills { get; set; }

    public List<PackData> packs{ get; set; }

    public List<FurnitureType> furniture { get; set; }= new List<FurnitureType>();

    public List<BackgroundType> background { get; set; }= new List<BackgroundType>();

    public List<AnnounceType> announces { get; set; }= new List<AnnounceType>();

    public List<MonologueType> monologues { get; set; }= new List<MonologueType>();

    public List<LanternType> lanterns { get; set; }= new List<LanternType>();

    public List<CharacterVoiceType> characterVoices { get; set; }= new List<CharacterVoiceType>();

    public List<AvatarType> avatars { get; set; }= new List<AvatarType>();

    public List<EmoticonType> emoticons { get; set; }= new List<EmoticonType>();

    public List<TicketType> tickets { get; set; } = new List<TicketType>();

    public List<BgmType> bgms { get; set; }= new List<BgmType>();

    public List<PowcampDecoType> powcampDecos { get; set; } = new List<PowcampDecoType>();

    public List<ResearcherTitleType> researcherTitles { get; set; } = new List<ResearcherTitleType>();

    public List<OfflineType> offlineGoods { get; set; }

    public List<MatchingCardType> matchingCards { get; set; }= new List<MatchingCardType>();

    public List<Product> skinTicket  { get; set; } = new List<Product>();
    
    public class Model
    {
        public List<Product> products{ get; set; }

        public List<RouletteData> roulettes{ get; set; }

        public List<RouletteGoodsGradeData> rouletteGrades{ get; set; }

        public List<PotentialSkillData> potentialSkills{ get; set; }

        public List<PackData> packs{ get; set; }

        public List<FurnitureType> furniture{ get; set; }

        public List<BackgroundType> background{ get; set; }

        public List<AnnounceType> announces{ get; set; }

        public List<MonologueType> monologues{ get; set; }

        public List<LanternType> lanterns{ get; set; }

        public List<CharacterVoiceType> characterVoices{ get; set; }

        public List<EmoticonType> emoticons{ get; set; }

        public List<TicketType> tickets{ get; set; }

        public List<BgmType> bgms{ get; set; }

        public List<PowcampDecoType> powcampeDecos{ get; set; }

        public List<ResearcherTitleType> researcherTitles{ get; set; }

        public List<OfflineType> offlines{ get; set; }
    }
}