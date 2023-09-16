using System.Text.Json.Serialization;

namespace BlackRevival.Common.Model;

public class MailAttachment
{
    [JsonPropertyName("man")]
    public long mailAttachmentNum { get; set; }

    [JsonPropertyName("mnm")]
    public long mailNum { get; set; }

    [JsonPropertyName("gs")]
    public Goods goods { get; set; }
}