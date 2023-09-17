using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Vote;

namespace BlackRevival.Common.GameDB;

public class VoteDB
{
    public static VoteDB Instance { get; set; }
    public VoteDB()
    {
        this._voteReward = new List<AcPhaseReward>();
        Instance = this;
    }

    public VoteDB(VoteDB.Model model)
    {
        this._voteReward = model.voteReward;
        Instance = this;
    }

    public List<int> GetPhaseRewardRankDatas(AcE_VOTE_PHASE_TYPE phaseType)
    {
        List<int> rankList = new List<int>();
        this._voteReward.ForEach(delegate(AcPhaseReward x)
        {
            if (x.GetPhaseType() == phaseType && !rankList.Contains(x.rank))
            {
                rankList.Add(x.rank);
            }
        });
        rankList.Sort();
        return rankList;
    }

    public List<AcPhaseReward> GetPhaseRewardDatas(AcE_VOTE_PHASE_TYPE phaseType)
    {
        return this._voteReward.FindAll((AcPhaseReward x) => x.GetPhaseType() == phaseType);
    }

    private List<AcPhaseReward> _voteReward { get; set; } 

    public class Model
    {
        public List<AcPhaseReward> voteReward { get; set; }
    }
}