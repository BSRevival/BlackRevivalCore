using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class CharactersResult
{
    public List<Character> characters{ get; set; }

    public List<NewProduct> newProduct{ get; set; }

    public List<Promotion> promotions{ get; set; }

    public List<Promotion> userPromotions{ get; set; }

    public List<PurchaseHistory> purchaseHistories{ get; set; }

    public List<Character> ownCharacters{ get; set; }

    public List<CharacterSkin> ownSkins{ get; set; }

    public List<string> productIds{ get; set; }
}