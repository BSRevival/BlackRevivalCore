using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackRevival.APIServer.Database;

public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CharacterNum { get; set; }
    [ForeignKey("User")]
    public long? UserNum { get; set; }
    public string UserNickname { get; set; } = "";
    public int CharacterClass { get; set; } = 4;
    public int CharacterGrade { get; set; } = 1;
    public int ActiveCharacterSkinType { get; set; } = 401;
    public bool ActiveLive2D { get; set; } = false;
    public int EnhanceExp { get; set; } = 0;
    public int CharacterPurchaseType { get; set; } = 0;
    public int RankPlayCount { get; set; } = 0;
    public int RankWinCount { get; set; } = 0;
    public int NormalPlayCount { get; set; } = 0;
    public int NormalWinCount { get; set; } = 0;
    public int TeamNumber { get; set; } = 0;
    public int PotentialSkillId { get; set; } = 0;
    public int Pmn { get; set; } = 0;
    public int Pfr { get; set; } = 0;
    public int Psd { get; set; } = 0;
    public bool Host { get; set; } = false;
    public int CharacterStatus { get; set; } = 1;
    public int ToNormalRemainSeconds { get; set; } = 0;

    public virtual User User { get; set; }
}
