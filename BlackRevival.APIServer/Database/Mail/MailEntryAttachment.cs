using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Database;

public class MailEntryAttachment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonPropertyName("man")]
    public long mailAttachmentNum { get; set; }

    [JsonPropertyName("mnm")]
    public long mailNum { get; set; }

    [JsonPropertyName("gs")]
    public Goods goods { get; set; }
}