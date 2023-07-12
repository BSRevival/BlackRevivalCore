using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model
{
	public class User : UserAsset
	{
		public int activatedPotentialSkillId{ get; set; }

		[JsonPropertyName("unm")]
		public long userNum { get; set; }

		[JsonPropertyName("rpm")]
		public bool receivePushMsg{ get; set; }

		[JsonPropertyName("npa")]
		public bool newPostArrived{ get; set; }

		[JsonPropertyName("tag")]
		public bool termsAgree{ get; set; }

		[JsonPropertyName("nnm")]
		public string nickname{ get; set; }
		
		[JsonPropertyName("bgm")]
		public bool bgm{ get; set; }

		[JsonPropertyName("sef")]
		public bool soundEffect{ get; set; }

		[JsonPropertyName("lwd")]
		public string lastword{ get; set; }

		[JsonPropertyName("wwd")]
		public string watchword{ get; set; }

		[JsonPropertyName("tpg")]
		public int tutorialProgress{ get; set; }

		[JsonPropertyName("lrp")]
		public int leaguePoint{ get; set; }
		[JsonPropertyName("re")]
		public int researcherExp{ get; set; }


		[JsonPropertyName("acn")]
		public long activeCharacterNum{ get; set; }

		[JsonPropertyName("alc")]
		public string appLanguageCode{ get; set; }

		[JsonPropertyName("rvn")]
		public int adViewCount{ get; set; }
		

		


		[JsonPropertyName("vlc")]
		[JsonIgnore]
		public string voiceLanguageCode{ get; set; }

		[JsonPropertyName("tw")]
		[JsonIgnore]
		public bool todayWin{ get; set; }

		[JsonPropertyName("th")]
		[JsonIgnore]
		public bool todayHighRank{ get; set; }
		
		public bool lto { get; set; }
		public bool ltt { get; set; }
		public bool lte { get; set; }
		public bool ltf { get; set; }
		public bool ltv { get; set; }
		public bool ltr { get; set; }
		
		
		[JsonPropertyName("rtc")]
		public int researcherTitleCode{ get; set; }

		[JsonPropertyName("mcc")]
		public int matchingCardCode{ get; set; }
		
		
		
		public int sigg { get; set; }
		public int sigc { get; set; }
		[JsonPropertyName("leg")]
		public League league{ get; set; }

		
		//Also Activated potential skill id;
		public int aps{ get; set; }

		[JsonPropertyName("mrn")]
		public int maxAdViewCount{ get; set; }
		
		public string rtn { get; set; }


		//public SkillData GetActivatedPotentialSkillData()
		//{
		//	return GameDB.skill.Find(activatedPotentialSkillId);
		//}

		public string GetUserNumName()
		{
			return string.Format("{0}_{1}", userNum, nickname);
		}

		public bool IsAvailableAd()
		{
			return adViewCount > 0;
		}

		public int GetRemainAdsViewCount()
		{
			return adViewCount;
		}

		public bool IsCarnivorousLeague()
		{
			return league >= League.FOX5;
		}

	

		public bool IsGreaterThanLegaue(int leagueNum)
		{
			return (int)league > leagueNum;
		}
	}
}
