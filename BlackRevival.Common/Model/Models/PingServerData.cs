using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model.Models;

public class PingServerData
{
    [JsonPropertyName("rgd")]
    public string regionDetail { get; set; }

    [JsonPropertyName("rg")]
    public  string region { get; set; }

    [JsonPropertyName("ip")] 
    public  string ipAddr { get; set; }

    public int pingTime;
}