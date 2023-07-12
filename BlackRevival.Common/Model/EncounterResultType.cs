using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum EncounterResultType
    {
        // Token: 0x04005583 RID: 21891
        NONE,
        // Token: 0x04005584 RID: 21892
        DEAD,
        // Token: 0x04005585 RID: 21893
        DAMAGED_AND_COUNTERATTACK_FAILED,
        // Token: 0x04005586 RID: 21894
        DAMAGED_AND_ENEMY_AVOID,
        // Token: 0x04005587 RID: 21895
        DAMAGED_AND_ENEMY_DAMAGED,
        // Token: 0x04005588 RID: 21896
        DAMAGED_AND_ENEMY_DEAD,
        // Token: 0x04005589 RID: 21897
        AVOID_AND_COUNTERATTACK_FAILED,
        // Token: 0x0400558A RID: 21898
        AVOID_AND_ENEMY_AVOID,
        // Token: 0x0400558B RID: 21899
        AVOID_AND_ENEMY_DAMAGED,
        // Token: 0x0400558C RID: 21900
        AVOID_AND_ENEMY_DEAD,
        // Token: 0x0400558D RID: 21901
        FIND
    }
}
