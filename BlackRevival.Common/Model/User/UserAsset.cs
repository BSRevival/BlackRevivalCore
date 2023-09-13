
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
	public class UserAsset
	{		
		[JsonPropertyName("bpt")]
		public int bearPoint{ get; set; }
		
		[JsonPropertyName("asc")]
		public int agliaScore{ get; set; }


		[JsonPropertyName("gld")]
		public int gold{ get; set; }

		[JsonPropertyName("gem")]
		public int gem{ get; set; }


		[JsonPropertyName("cd")]
		public int credit{ get; set; }

		[JsonPropertyName("ma")]
		public int mileage{ get; set; }

		[JsonPropertyName("em")]
		public int experimentMemory{ get; set; }

		[JsonPropertyName("tp")]
		public int tournamentPoint{ get; set; }

		[JsonPropertyName("tt")]
		public int tournamentTicket{ get; set; }

		[JsonPropertyName("vt")]
		public int voteTicket{ get; set; }

		[JsonPropertyName("vs")]
		public int voteStamp{ get; set; }

		[JsonPropertyName("lp")]
		public int labyrinthPoint{ get; set; }

		public void updateAsset(UserAsset userAsset)
		{
			gold = userAsset.gold;
			gem = userAsset.gem;
			bearPoint = userAsset.bearPoint;
			credit = userAsset.credit;
			mileage = userAsset.mileage;
			experimentMemory = userAsset.experimentMemory;
			tournamentPoint = userAsset.tournamentPoint;
			tournamentTicket = userAsset.tournamentTicket;
			voteTicket = userAsset.voteTicket;
			voteStamp = userAsset.voteStamp;
			labyrinthPoint = userAsset.labyrinthPoint;
		}

		public void setAssetValue(AssetType assetType, int value)
		{
			switch (assetType)
			{
				case AssetType.GOLD:
					gold = value;
					break;
				case AssetType.GEM:
					gem = value;
					break;
				case AssetType.BEARPOINT:
					bearPoint = value;
					break;
				case AssetType.CREDIT:
					credit = value;
					break;
				case AssetType.MILEAGE:
					mileage = value;
					break;
				case AssetType.EXPERIMENT_MEMORY:
					experimentMemory = value;
					break;
				case AssetType.TOURNAMENT_POINT:
					tournamentPoint = value;
					break;
				case AssetType.TOURNAMENT_TICKET:
					tournamentTicket = value;
					break;
				case AssetType.VOTE_TICKET:
					voteTicket = value;
					break;
				case AssetType.VOTE_STAMP:
					voteStamp = value;
					break;
				case AssetType.LABYRINTH_POINT:
					labyrinthPoint = value;
					break;
				case (AssetType)4:
					break;
			}
		}

		public int getAssetValue(AssetType assetType)
		{
			switch (assetType)
			{
				case AssetType.GOLD:
					return gold;
				case AssetType.GEM:
					return gem;
				case AssetType.BEARPOINT:
					return bearPoint;
				case AssetType.CREDIT:
					return credit;
				case AssetType.MILEAGE:
					return mileage;
				case AssetType.EXPERIMENT_MEMORY:
					return experimentMemory;
				case AssetType.TOURNAMENT_POINT:
					return tournamentPoint;
				case AssetType.TOURNAMENT_TICKET:
					return tournamentTicket;
				case AssetType.VOTE_TICKET:
					return voteTicket;
				case AssetType.VOTE_STAMP:
					return voteStamp;
				case AssetType.LABYRINTH_POINT:
					return labyrinthPoint;
				default:
					return 0;
			}
		}
	}
}
