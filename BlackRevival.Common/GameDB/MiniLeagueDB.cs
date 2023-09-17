using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.GameDB.MiniLeague;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB;

public class MiniLeagueDB
{
    public MiniLeagueDB()
    {
        this.rewards = new List<MiniLeagueReward>();
        this.tier = new List<MiniLeagueTierData>();
    }

    public MiniLeagueDB(MiniLeagueDB.Model data)
    {
        this.rewards = data.rewards;
        this.tier = data.tier;
    }

    public MiniLeagueStatus GetMiniLeagueStatus(MiniLeagueTier tier, int rank)
    {
        MiniLeagueTierData miniLeagueTierData = this.tier.Find((MiniLeagueTierData x) => x.code == (int)tier);
        if (miniLeagueTierData == null)
        {
            return MiniLeagueStatus.NONE;
        }

        if (rank <= miniLeagueTierData.promotionRank)
        {
            return MiniLeagueStatus.PROMOTION;
        }
        
        if (rank >= miniLeagueTierData.relegationRank)
        {
            return MiniLeagueStatus.RELEGATION;
        }

        return MiniLeagueStatus.KEEP;
    }
    


    public MiniLeagueReward FindMiniLeagueReward(MiniLeagueTier tier, int rank)
    {
        MiniLeagueReward miniLeagueReward =
            this.rewards.Find((MiniLeagueReward x) => x.tier == tier && x.IsInnerRank(rank));
        if (miniLeagueReward == null)
        {
            return null;
        }

        return miniLeagueReward;
    }

    public List<MiniLeagueReward> FindMiniLeagueRewards(MiniLeagueTier tier)

    {
        List<MiniLeagueReward> list = this.rewards.FindAll((MiniLeagueReward x) => x.tier == tier);
        if (list == null || list.Count <= 0)
        {
            return null;
        }
        return list;
    }

    public Goods FindTierTopReward(MiniLeagueTier tier)
    {
        MiniLeagueReward miniLeagueReward =
            this.rewards.Find((MiniLeagueReward x) => x.tier == tier && x.startRank == 1);
        if (miniLeagueReward == null)
        {
            return null;
        }

        return miniLeagueReward.rewardGoods;
    }

    public List<MiniLeagueTierData> tier;

    public List<MiniLeagueReward> rewards;

    public class Model
    {
        public List<MiniLeagueReward> rewards;

        public List<MiniLeagueTierData> tier;
    }
}