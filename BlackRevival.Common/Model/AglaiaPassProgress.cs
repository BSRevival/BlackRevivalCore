using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class AglaiaPassProgress
{
    [JsonPropertyName("un")]
    public  long userNum{ get; set; }

    [JsonPropertyName("es")]
    public  int episode{ get; set; }

    [JsonPropertyName("pt")]
    public int point{ get; set; }

    [JsonPropertyName("ss")]
    public int status{ get; set; }

    [JsonPropertyName("pa")]
    public bool paid{ get; set; }

    [JsonPropertyName("cd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public  DateTime createDtm{ get; set; }

    [JsonPropertyName("ud")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public  DateTime updateDtm{ get; set; }

    [JsonPropertyName("ed")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public  DateTime expireDtm{ get; set; }
}