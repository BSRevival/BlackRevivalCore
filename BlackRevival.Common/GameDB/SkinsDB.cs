using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB;

public class SkinsDB
{
    public SkinsDB()
    {
        this.characterSkins = new List<CharacterSkin>();
    }
	
	

    public SkinsDB(SkinsDB.Model model)
    {
        this.characterSkins = model.Skins;
    }
    
    public List<CharacterSkin> GetAllSkins()
    {
        return this.characterSkins;
    }
    
    public List<CharacterSkin> GetSkinsByClass(AcE_CharacterClass characterClass)
    {
        return this.characterSkins.FindAll(x => x.characterClass == (int)characterClass);
    }

    public CharacterSkin GetDefaultSkinByClass(AcE_CharacterClass characterClass)
    {
        var skinType = GetFirstSkinId((int)characterClass);
        return this.characterSkins.Find(x => x.characterSkinType == skinType);
    }
    
    public int GetFirstSkinId(int classId)
    {
        return classId < 10 ? (classId * 100) + 1 : (classId * 100) + 1;
    }
    
    private  List<CharacterSkin> characterSkins = new List<CharacterSkin>();

    public class Model
    {
        public List<CharacterSkin> Skins { get; set; }
    }
}