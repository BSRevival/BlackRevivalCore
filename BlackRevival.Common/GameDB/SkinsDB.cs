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
    
    
    private  List<CharacterSkin> characterSkins = new List<CharacterSkin>();

    public class Model
    {
        public List<CharacterSkin> Skins { get; set; }
    }
}