using BlackRevival.Common.GameDB.Collection;

namespace BlackRevival.Common.GameDB;

public class CollectionDB
{
    public static CollectionDB Instance { get; set; }
    public CollectionDB()
    {
        this.skinCollectionList = new List<SkinCollectionData>();
        Instance = this;
    }

    public CollectionDB(CollectionDB.Model model)
    {
        this.skinCollectionList = model.skinCollectionList;
        Instance = this;
    }

    public SkinCollectionData GetSkinCollectionData(int code)
    {
        return this.skinCollectionList.Find((SkinCollectionData data) => data.code == code);
    }

    private List<SkinCollectionData> skinCollectionList { get; set; } 

    public class Model
    {
        public List<SkinCollectionData> skinCollectionList { get; set; }
    }
}