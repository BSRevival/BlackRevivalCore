using BlackRevival.Common.Apis;
using BlackRevival.Common.GameDB.Skills;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.Responses;

public class PotentialSkillListResult
{
    public List<UserPotentialSkill> list { get; set; }

    public List<PerkApi.PerkPreset> perkList { get; set; }
}