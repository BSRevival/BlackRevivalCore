using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
	public class BattleRecord
	{
		[JsonPropertyName("hbt")]
		public int herbivBattle;

		[JsonPropertyName("cbt")]
		public int carnivBattle;

		[JsonPropertyName("hrb")]
		public int highRankBattle;

		[JsonPropertyName("avg")]
		public float averageRank;

		[JsonPropertyName("rw")]
		public int rankWin;

		[JsonPropertyName("nw")]
		public int normalWin;

		[JsonPropertyName("hss")]
		public int hackingSuccess;

		[JsonPropertyName("ckl")]
		public int characterKill;

		[JsonPropertyName("dea")]
		public int death;

		[JsonPropertyName("fst")]
		public long fieldShift;

		[JsonPropertyName("cps")]
		public int characterPurchase;

		[JsonPropertyName("bct")]
		public int totalBattle;

		[JsonPropertyName("blp")]
		public int bestLeaguePoint;

		[JsonPropertyName("mpc")]
		public AcE_CharacterClass mostPlayedCharacter;

		[JsonPropertyName("mpcnt")]
		public int mostPlayedCount;
	}

}
