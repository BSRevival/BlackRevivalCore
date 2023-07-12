using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum BattleSearchResultType
    {
        // Token: 0x0400550B RID: 21771
        NONE,
        // Token: 0x0400550C RID: 21772
        BURNOUT,
        // Token: 0x0400550D RID: 21773
        TRAP,
        // Token: 0x0400550E RID: 21774
        ENCOUNTER_ENEMY,
        // Token: 0x0400550F RID: 21775
        ENCOUNTER_MONSTER,
        // Token: 0x04005510 RID: 21776
        FIND_DEAD_ENEMY,
        // Token: 0x04005511 RID: 21777
        FIND_DEAD_MONSTER,
        // Token: 0x04005512 RID: 21778
        FIND_FIELD_ITEM,
        // Token: 0x04005513 RID: 21779
        EXP_ACQUISITION,
        // Token: 0x04005514 RID: 21780
        FIND_CLUE
    }
}
