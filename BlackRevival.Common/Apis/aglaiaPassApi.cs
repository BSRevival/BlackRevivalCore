using BlackRevival.Common.Model;

namespace BlackRevival.Common.Apis;

public class aglaiaPassApi
{
    public class ProgressListResult
    {
        public List<AglaiaPassProgress> aglaiaPassProgressList;
    }

    public class ProgressResult
    {
        public AglaiaPassProgress aglaiaPassProgress;
    }

    public class RewardResult
    {
        public AglaiaPassReward aglaiaPassReward;
    }

    public class getProgressResult
    {
        public AglaiaPassProgress aglaiaPassProgress;

        public List<AglaiaPassReward> aglaiaPassRewardList;
    }
}