using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class CharacterSkin
{
    [JsonPropertyName("unm")]
    public long userNum{ get; set; }

    [JsonPropertyName("cls")]
    public int characterClass{ get; set; }

    [JsonPropertyName("ckt")]
    public int characterSkinType{ get; set; }

    [JsonPropertyName("own")]
    public bool owned{ get; set; }

    [JsonPropertyName("live")]
    public bool activeLive2D{ get; set; }

    [JsonPropertyName("ps")]
    [JsonIgnore]

    public int parentSkin{ get; set; }

    [JsonPropertyName("setp")]
    public SkinEnableType skinEnableType{ get; set; }

    [JsonPropertyName("edtm")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    [JsonIgnore]
    public DateTime enableDtm{ get; set; }

    [JsonPropertyName("wtgl")]
    [JsonIgnore]

    public AcE_WayToGet wayToGet{ get; set; }
}