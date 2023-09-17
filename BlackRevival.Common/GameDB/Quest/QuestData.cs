using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.GameDB.Quest;

public class QuestData
{
	

	public string getQuestTypeTitle()
	{
		return LocalizationDB.Instance.StringFormat(string.Format("QuestTitle_{0}", (int)this.type), new object[] { this.param1 });
	}
	[JsonPropertyName("qid")]
	public int questId { get; set; }

	[JsonPropertyName("gid")]
	public int groupId { get; set; }

	[JsonPropertyName("t")]
	public QuestType type { get; set; }

	[JsonPropertyName("p1")]
	public int param1 { get; set; }

	[JsonPropertyName("p2")]
	public int param2 { get; set; }

	[JsonPropertyName("cnt")]
	public int count { get; set; }

	[JsonPropertyName("rt")]
	public QuestRenewalType questRenewalType { get; set; }

	[JsonPropertyName("qt")]
	public QuestTarget questTarget { get; set; }

	[JsonPropertyName("rgs")]
	public Goods rewardGoods { get; set; }

	[JsonPropertyName("st")]
	public QuestSceneType questScenetype { get; set; }

	[JsonPropertyName("qgn")]
	public QuestGroupName questGroupName { get; set; }

	[JsonPropertyName("qd")]
	public QuestDifficulty questDifficulty { get; set; }

	[JsonPropertyName("bgs")]
	public Goods bonusGoods { get; set; }
}