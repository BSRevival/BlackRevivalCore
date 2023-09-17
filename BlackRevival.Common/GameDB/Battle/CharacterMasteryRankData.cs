using System.Text.Json.Serialization;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Battle;

public class CharacterMasteryRankData
{
    public float GetFamiliarityExp()
    {
       /* if (Ingame.inst != null)
        {
            GameContext game = Ingame.inst.game;
            if (game != null && game.GetMapType == MapType.SEOUL)
            {
                return this.teamFamiliarityExp;
            }
        }*/
        return this.familiarityExp;
    }

    public float GetFamiliarityExp(bool isTeam)
    {
        if (!isTeam)
        {
            return this.familiarityExp;
        }
        return this.teamFamiliarityExp;
    }

    [JsonPropertyName("mid")]
    public int masteryId { get; set; }

    [JsonPropertyName("wpt")]
    public AcE_WEAPON_TYPE weaponType { get; set; }

    [JsonPropertyName("grd")]
    public VeteranGrade grade { get; set; }

    [JsonPropertyName("fex")]
    public float familiarityExp { get; set; }

    [JsonPropertyName("tfex")]
    public float teamFamiliarityExp { get; set; }
}