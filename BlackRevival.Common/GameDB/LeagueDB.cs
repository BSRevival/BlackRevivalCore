using BlackRevival.Common.Model;
using BlackRevival.Common.GameDB.Leagues;
using BlackRevival.Common.Util;
using Serilog;
using System.ComponentModel;

namespace BlackRevival.Common.GameDB;

public class LeagueDB
{

	public LeagueDB()
	{
        Instance = this;
	}
	public LeagueDB(LeagueDB.Model model)
	{
		this.DataLoad();
        Instance = this;
	}

	public void DataLoad()
	{
		AcXml acXml = new AcXml();
		if (acXml.Load("Data/Xmls/LeagueTypeData.xml", true))
		{
			acXml.GetAllChildData("LeagueTypeData", "Code", "LeagueData_{0}", false).ForEach(delegate(AcXmlNode item)
			{
				this.leaguers.Add(new LeagueData(item));
			});
		}
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x000A3034 File Offset: 0x000A1234
	public string GetLevelMarkSprite(Common.Model.League league)
	{
		LeagueData leagueData = this.Find(league);
		if (leagueData != null)
		{
			return leagueData.GetLevelMarkSprite();
		}
		return "";
	}

	public LeagueData Find(League league)
	{
		return this.leaguers.Find((LeagueData data) => data.p_code == (int)league);
	}

	public List<LeagueData> Find(LeagueType leagueType)
	{
		return this.leaguers.FindAll((LeagueData data) => data.p_leagueType == leagueType);
	}

	public int GetLeagueByPoint(int point)
	{
		int result = 0;
		foreach (LeagueData leagueData in this.leaguers)
		{
			if (leagueData.p_rankPointUpperLimit >= point)
			{
				result = leagueData.p_code;
				break;
			}
		}
		return result;
	}

	public int GetPointFromServer(bool isCarnivorousLeague, int serverPoint)
	{
		if (isCarnivorousLeague)
		{
			return serverPoint - this.Find(League.ELEPHANT1).p_rankPointUpperLimit;
		}
		return serverPoint;
	}

	public LeagueTypeDetail GetCarnivorousLeagueBorder(int leagueBoarder)
	{
		List<LeagueData> list = this.leaguers.FindAll((LeagueData data) => data.p_leagueTypeDetail == AcEnum.ConvertInt<LeagueTypeDetail>(leagueBoarder + 5));
		LeagueTypeDetail? leagueTypeDetail;
		if (list == null)
		{
			leagueTypeDetail = null;
		}
		else
		{
			LeagueData leagueData = list.FirstOrDefault<LeagueData>();
			leagueTypeDetail = ((leagueData != null) ? new LeagueTypeDetail?(leagueData.p_leagueTypeDetail) : null);
		}
		LeagueTypeDetail? leagueTypeDetail2 = leagueTypeDetail;
		if (leagueTypeDetail2 == null)
		{
			return LeagueTypeDetail.NONE;
		}
		return leagueTypeDetail2.GetValueOrDefault();
	}

	private readonly List<LeagueData> leaguers = new List<LeagueData>();

    public static LeagueDB Instance { get; private set; }
	public class Model
	{
		public List<LeagueData> leaguers { get; set; }
	}
}
