using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;

namespace BlackRevival.Common.Model;

public class GameModeStatus
{
    [JsonPropertyName("bmd")]
    public PlayMode mode { get; set; }

    [JsonPropertyName("gst")]
    public GameStatus status { get; set; }

    [JsonPropertyName("bdtm")]
    public long beginDtm  { get; set; }

    [JsonPropertyName("edtm")]
    public long endDtm { get; set; }
}