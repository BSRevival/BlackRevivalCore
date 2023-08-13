using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class CharacterDetailInfoResult
{
    public Character character { get; set; }

    public List<CharacterSkin> characterSkins { get; set; }

    public List<CharacterSignature> characterSignatureList { get; set; }

    public CharacterDocument characterDocument { get; set; }

}