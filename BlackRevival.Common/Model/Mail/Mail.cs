using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class Mail
{
    [JsonPropertyName("mnm")]
    public long mailNum { get; set; }

    [JsonPropertyName("typ")]
    public MailType type { get; set; }

    [JsonPropertyName("tit")]
    public string title { get; set; }

    [JsonPropertyName("ctt")]
    public string content { get; set; }

    [JsonPropertyName("sts")]
    public MailStatus status { get; set; }

    [JsonPropertyName("snm")]
    public int senderNum { get; set; }

    [JsonPropertyName("snk")]
    public string senderNickname { get; set; }

    [JsonPropertyName("enm")]
    public int eventNum { get; set; }

    [JsonPropertyName("cdt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime createDtm { get; set; }

    [JsonPropertyName("rdt")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime readDtm { get; set; }

    [JsonPropertyName("attachement")]
    public MailAttachment attachment { get; set; }

    [JsonPropertyName("epd")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime expireDtm { get; set; }

    [JsonPropertyName("lnk")]
    public string publishId { get; set; }

    [JsonPropertyName("sbt")]
    public string subTitle { get; set; }

    [JsonPropertyName("wlnk")]
    public string webLink { get; set; }
}