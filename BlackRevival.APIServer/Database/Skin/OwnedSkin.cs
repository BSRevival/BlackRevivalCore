using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Database;

public class OwnedSkin
{    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OwnedSkinId { get; set; }
    
    [ForeignKey("User")]
    [JsonPropertyName("unm")]
    public long UserNum { get; set; }
    
    [JsonPropertyName("cls")]
    public int CharacterClass { get; set; }
    
    [JsonPropertyName("ckt")]
    public int CharacterSkinType { get; set; }
    
    [JsonPropertyName("own")]
    public bool Owned { get; set; } = true; // Defaulting to true based on property name.
    
    [JsonPropertyName("live")]
    public bool ActiveLive2D { get; set; }
    
    [JsonPropertyName("setp")]
    public SkinEnableType SkinEnableType { get; set; }
    
    // Navigational property for the related User.
    public virtual User User { get; set; }

}