using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;


namespace BlackRevival.Common.Responses;

public class ProductAllResult
{
    public List<NewProduct> newProduct { get; set; }

    public List<Promotion> promotions { get; set; }

    public List<Promotion> userPromotions { get; set; }

    public List<PurchaseHistory> purchaseHistories { get; set; }

    public List<Character> ownCharacters { get; set; }

    public List<CharacterSkin> ownSkins { get; set; }

    public List<string> productIds { get; set; }

    [JsonConverter(typeof(MicrosecondEpochConverter))]
    [JsonIgnore]
    public long tournamentStartDtm { get; set; }
}