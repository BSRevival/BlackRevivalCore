using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Classes;

public static class ProductManager
{
    
    
    public static bool IsAvailableProduct(string productId)
    {
        return _availableProducts != null && _availableProducts.Exists((Product x) => x.productId == productId);
    }

    public static bool IsAvailableProduct(string productId, AcE_ROULETTE_TYPE rouletteType)
    {
        return _availableProducts != null && _availableProducts.Exists((Product x) => x.productId == productId && x.goods.subType == rouletteType.ToString());
    }

    public static void UpdateAllProduct(List<NewProduct> newProduct, List<Promotion> promotions,
        List<Promotion> userPromotions, List<PurchaseHistory> purchaseHistories, List<Character> ownCharacters,
        List<CharacterSkin> ownSkins, List<string> productIds)
    {
        _newProducts = newProduct;
        _promotions = promotions;
        _userPromotions = userPromotions;
        
        SetAvailableProductList(productIds);
    }
    
    public static void SetAvailableProductList(List<string> availableProductIds)
    {
        if (_availableProducts != null && _availableProducts.Count > 0)
        {
            _availableProducts.Clear();
        }
        if (availableProductIds == null)
        {
            return;
        }
        foreach (string productId in availableProductIds)
        {
            Product product = TableManager.productsDb.Find(productId);
            if (product != null)
            {
                _availableProducts.Add(product);
            }
        }
    }
    private static List<CharacterSkin> _cacheAllSkinList { get; set; }= new List<CharacterSkin>();

    private static List<UserDailyProduct> _dailyProductList { get; set; }= new List<UserDailyProduct>();

    private static List<NewProduct> _newProducts { get; set; }= new List<NewProduct>();

    private static List<Promotion> _promotions { get; set; }= new List<Promotion>();

    private static List<Promotion> _userPromotions { get; set; }= new List<Promotion>();

    private static List<Product> _availableProducts { get; set; }= new List<Product>();

}