using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class InvenGoods
{
    public string c { get; set; }
    
    public int a { get; set; }
    [JsonPropertyName("n")]
    public long num{ get; set; }

    [JsonPropertyName("un")]
    public long userNum{ get; set; }

    [JsonPropertyName("ia")]
    public bool isActivated{ get; set; }

    public bool activated{ get; set; }

    [JsonPropertyName("ed")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    [JsonIgnore]
    public DateTime expireDtm{ get; set; }
}