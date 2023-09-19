using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.AvatarBonus;
using Serilog;
using BlackRevival.Common.GameDB.ProductRelated;
using Serilog.Core;

namespace BlackRevival.Common.GameDB;

public class AvatarBonusDB
{

    private List<AvatarBonusData> data { get; set; } = new List<AvatarBonusData>();

    public AvatarBonusDB()
    {
    }

    public AvatarBonusDB(AvatarBonusDB.Model model)
    {
        this.data = model.avatarBonus;
        if (this.data == null)
        {
            Log.Error("Failed to load AvatarBonusDB.");
        }
    }

    public AvatarBonusData Find(Predicate<AvatarBonusData> match)
    {
        return this.data.Find(match);
    }

    public AvatarBonusData FindByProductId(string productId)
    {
        return this.data.Find((AvatarBonusData x) => x.productId.Equals(productId));
    }

    public AvatarBonusData FindByAvatarType(string avatarType)
    {
        return this.data.Find((AvatarBonusData x) => x.avatarType.Equals(avatarType));
    }

    public AvatarBonusData FindByInvenGoods(InvenGoods invenGoods)
    {
        if (invenGoods == null)
        {
            Log.Error("InvenGoods is null.");
            return null;
        }
        AvatarType avatarType = ProductDB.Instance.FindAvatar(invenGoods.subType);
        if (avatarType == null)
        {
            Log.Error($"AvatarType[{invenGoods.subType}] is null.");
            return null;
        }
        AvatarBonusData avatarBonusData = this.FindByAvatarType(avatarType.p_type);
        if (avatarBonusData == null)
        {
            Log.Error($"AvatarBonusData[{avatarType.p_type}] is null.");
            return null;
        }
        return avatarBonusData;
    }

    public class Model
    {
        public List<AvatarBonusData> avatarBonus { get; set; }
    }
}
