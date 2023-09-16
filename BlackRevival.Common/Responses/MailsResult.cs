using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class MailsResult
{
    [JsonPropertyName("ms")]
    public List<Mail> mails { get; set; }

}