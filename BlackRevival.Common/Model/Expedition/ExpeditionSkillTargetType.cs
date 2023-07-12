using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionSkillTargetType
    {
        // Token: 0x040058C3 RID: 22723
        NONE,
        // Token: 0x040058C4 RID: 22724
        ALL,
        // Token: 0x040058C5 RID: 22725
        MYSELF,
        // Token: 0x040058C6 RID: 22726
        ALL_RANDOM = 11,
        // Token: 0x040058C7 RID: 22727
        OUR_RANDOM,
        // Token: 0x040058C8 RID: 22728
        ENEMY_RANDOM,
        // Token: 0x040058C9 RID: 22729
        ENEMY = 21,
        // Token: 0x040058CA RID: 22730
        ENEMY_TEAM,
        // Token: 0x040058CB RID: 22731
        ENEMY_BUFF,
        // Token: 0x040058CC RID: 22732
        OUR = 31,
        // Token: 0x040058CD RID: 22733
        OUR_TEAM,
        // Token: 0x040058CE RID: 22734
        OUR_TEAM_HP_LOWER,
        // Token: 0x040058CF RID: 22735
        OUR_TEAM_HP_STATIC,
        // Token: 0x040058D0 RID: 22736
        OUR_TEAM_HP_HIGHER,
        // Token: 0x040058D1 RID: 22737
        OUR_TEAM_COMPLETE_EFFECT,
        // Token: 0x040058D2 RID: 22738
        OUR_TEAM_NOT_COMPLETE_EFFECT,
        // Token: 0x040058D3 RID: 22739
        ATTACKED_ENEMY = 101,
        // Token: 0x040058D4 RID: 22740
        ENEMY_TEAM_RANDOM_INDEPENDENT = 113,
        // Token: 0x040058D5 RID: 22741
        ENEMY_TEAM_HAVE_EFFECT = 201,
        // Token: 0x040058D6 RID: 22742
        HAVE_DEBUFF_OUR_TEAM = 301
    }
}
