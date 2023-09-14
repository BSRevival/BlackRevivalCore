using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.InGame;

public class BattleOptionParam
{
    [JsonPropertyName("pds")]
    public List<Product> products { get; set; }

    [JsonPropertyName("gsl")]
    public List<Goods> goodsList { get; set; }

    [JsonPropertyName("tll")]
    public List<string> targetLocationList { get; set; }

    [JsonPropertyName("uob")]
    public bool useObserver  { get; set; }

    [JsonPropertyName("ht")]
    public bool host { get; set; }

    [JsonPropertyName("pl")]
    public List<int> perkIds { get; set; }

    [JsonPropertyName("sid")]
    public List<int> startIds { get; set; }
}