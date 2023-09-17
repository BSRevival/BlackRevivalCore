using BlackRevival.Common.GameDB.Aglaia;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB;

public class AglaiaPassDB
{
	public static AglaiaPassDB Instance { get; private set; }
	public AglaiaPassDB()
	{
		this.aglaiaPass = new List<AglaiaPassData>();
		AglaiaPassDB.Instance = this;
	}

	public AglaiaPassDB(AglaiaPassDB.Model data)
	{
		this.aglaiaPass = data.aglaiaPass;
		foreach (AglaiaPassData aglaiaPassData in this.aglaiaPass)
		{
			if (aglaiaPassData.goods != null && aglaiaPassData.goods.goodsType == GoodsType.LIVE2D_SKIN_TICKET)
			{
				this.listLive2dSkinTicket.Add(aglaiaPassData.goods);
			}
		}
		AglaiaPassDB.Instance = this;
	}

	public int GetStep(int episode, int point)
	{
		int step = 0;
		this.aglaiaPass.FindAll((AglaiaPassData x) => x.episode == episode).ForEach(delegate(AglaiaPassData x)
		{
			if (point >= x.point)
			{
				step = x.step;
			}
		});
		return step;
	}

	public List<int> GetAglaiaPassEpisodeList()
	{
		List<int> list = new List<int>();
		foreach (AglaiaPassData aglaiaPassData in this.aglaiaPass)
		{
			if (!list.Contains(aglaiaPassData.episode))
			{
				list.Add(aglaiaPassData.episode);
			}
		}
		list.Sort();
		return list;
	}

	public int GetAglaiaPassEpisodeCount(int episode)
	{
		return this.aglaiaPass.Count((AglaiaPassData x) => x.episode == episode) / 2;
	}

	public List<int> GetTestList()
	{
		return (from x in this.aglaiaPass
			select x.episode).Distinct<int>().ToList<int>();
	}

	public AglaiaPassData GetAglaiaPassData(int episode, int step)
	{
		return this.aglaiaPass.Find((AglaiaPassData x) => x.episode == episode && x.step == step);
	}

	public bool IsClearEpisode(int episode, int point)
	{
		return this.aglaiaPass.Find((AglaiaPassData x) => x.episode == episode && x.point > point) == null;
	}

	public bool IsExistEpisode(int episode)
	{
		return this.aglaiaPass.Exists((AglaiaPassData x) => x.episode == episode);
	}

	public string GetDate(int episode)
	{
		AglaiaPassData aglaiaPassData = this.aglaiaPass.Find((AglaiaPassData x) => x.episode == episode);
		if (aglaiaPassData == null)
		{
			return null;
		}
		return aglaiaPassData.date;
	}

	public List<AglaiaPassData> GetEpisodeData(int episode)
	{
		return this.aglaiaPass.FindAll((AglaiaPassData x) => x.episode == episode);
	}

	public Goods GetSkinTicket(int skinCode)
	{
		return this.listLive2dSkinTicket.Find((Goods item) => item.GetIntSubType() == skinCode);
	}

	public bool IsSkinWithTicket(int skinCode)
	{
		return this.GetSkinTicket(skinCode) != null;
	}

	public List<AglaiaPassData> aglaiaPass { get; set; }

	public List<Goods> listLive2dSkinTicket = new List<Goods>();

	public class Model
	{
		public List<AglaiaPassData> aglaiaPass { get; set; }
	}
}