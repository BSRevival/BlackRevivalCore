using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class InvenResult : CommunityRequsetResult
{
    public List<InvenGoods> invenGoodsList { get; set; }

    public long tournamentStartDtm { get; set; }
}