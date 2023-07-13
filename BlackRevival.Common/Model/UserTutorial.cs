using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class UserTutorial
{
    public string tutorial { get; set; }
    
    [JsonPropertyName("unm")]
    public long userNum { get; set; }

    [JsonPropertyName("ttn")]
    public int tutorialNum { get; set; }

    [JsonPropertyName("clr")]
    public bool cleared { get; set; }
}