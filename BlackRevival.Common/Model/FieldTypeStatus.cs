using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class FieldTypeStatus
{
    [JsonPropertyName("ftp")]
    public int fieldType { get;set; }

    [JsonPropertyName("ski")]
    public int skillId { get;set; }
}