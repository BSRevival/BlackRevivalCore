using System.Text.Json.Serialization;

namespace BlackRevival.Common.GameDB.Perks;

public class PerkData
{
    public string GetCategoryNum(string format = "")
	{
		return (this.category / 10000).ToString(format);
	}

    public bool isBasePerk()
	{
		return this.level == 1;
	}

	[JsonPropertyName("rid")]
	public int id { get; set; }

	[JsonPropertyName("pcg")]
	public int category { get; set; }

	[JsonPropertyName("plv")]
	public int level { get; set; }

	[JsonPropertyName("ski")]
	public int skill_id { get; set; }
}