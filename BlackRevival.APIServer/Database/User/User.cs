using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Database;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserNum { get; set; }
    public bool ReceivePushMsg { get; set; } = true;
    public bool NewPostArrived { get; set; } = true;
    public bool TermsAgree { get; set; } = true;
    public string Nickname { get; set; }
    public int TutorialProgress { get; set; } = 0;
    public bool Bgm { get; set; } = true;
    public bool SoundEffect { get; set; } = true;
    public string Lastword { get; set; } = "How can I die here...";
    public string Watchword { get; set; } = "Come at me";
    public long ActiveCharacterNum { get; set; }
    public string AppLanguageCode { get; set; } = "en";
    public int LeaguePoint { get; set; } = 0;
    public int AdViewCount { get; set; } = 10;
    public int MaxAdViewCount { get; set; } = 10;
    public int ActivatedPotentialSkillId { get; set; } = 0;
    public int ResearcherExp { get; set; } = 0;
    public int ResearcherTitleCode { get; set; } = 0;
    public int MatchingCardCode { get; set; } = 0;
    public bool Lto { get; set; } = false;
    public bool Ltt { get; set; } = false;
    public bool Lte { get; set; } = false;
    public bool Ltf { get; set; } = false;
    public bool Ltv { get; set; } = false;
    public bool Ltr { get; set; } = false;
    public int Sigc { get; set; } = 0;
    public int Sigg { get; set; } = 0;
    public string Rtn { get; set; } = "NONE";
    public int Aps { get; set; } = 6001;
    public League League { get; set; } = League.MOUSE5; // Assuming League is a string; you can change it to an enum if needed

    public virtual UserAsset UserAsset { get; set; }
}
