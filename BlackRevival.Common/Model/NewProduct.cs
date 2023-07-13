using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class NewProduct
{
    [JsonPropertyName("pid")]
    public string productId{ get; set; }

    [JsonPropertyName("ty")]
    public NewProductType type{ get; set; }

    [JsonPropertyName("lt")]
    public NewProductLeagueType leagueType{ get; set; }

    [JsonPropertyName("cdt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime? createDtm{ get; set; }

    [JsonPropertyName("bdt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime? beginDtm{ get; set; }

    [JsonPropertyName("edt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime? endDtm{ get; set; }
}