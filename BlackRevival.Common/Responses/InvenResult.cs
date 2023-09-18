using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Responses;

public class InvenResult : CommunityRequsetResult
{
    public List<InvenGoods> invenGoodsList { get; set; }

    [JsonConverter(typeof(MicrosecondEpochConverter))]
    public DateTime tournamentStartDtm;
}