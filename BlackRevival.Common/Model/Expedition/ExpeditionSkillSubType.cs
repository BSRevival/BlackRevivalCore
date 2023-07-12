using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionSkillSubType
    {
        // Token: 0x040058AE RID: 22702
        NONE,
        // Token: 0x040058AF RID: 22703
        EFFECT_STATUS = 101,
        // Token: 0x040058B0 RID: 22704
        EFFECT_ACTION_COST,
        // Token: 0x040058B1 RID: 22705
        EFFECT_DECR_DMG_RATE,
        // Token: 0x040058B2 RID: 22706
        EFFECT_ADD_GUARD_RATE,
        // Token: 0x040058B3 RID: 22707
        EFFECT_EQUIPMENT = 111,
        // Token: 0x040058B4 RID: 22708
        EFFECT_BACKPACK,
        // Token: 0x040058B5 RID: 22709
        EFFECT_STUN = 201,
        // Token: 0x040058B6 RID: 22710
        EFFECT_DOT_DAMAGE = 301,
        // Token: 0x040058B7 RID: 22711
        EFFECT_CARD_DRAW = 401,
        // Token: 0x040058B8 RID: 22712
        EFFECT_TARGET_CARD_DRAW_1,
        // Token: 0x040058B9 RID: 22713
        EFFECT_CRITICAL_COUNT_1 = 501,
        // Token: 0x040058BA RID: 22714
        EFFECT_HAVE_CARD_COUNT = 601,
        // Token: 0x040058BB RID: 22715
        EFFECT_USED_STAMINA_FOR_SKILL = 1001,
        // Token: 0x040058BC RID: 22716
        EFFECT_NOT_DEADLY_HIT = 701,
        // Token: 0x040058BD RID: 22717
        EFFECT_RECOVERY = 801,
        // Token: 0x040058BE RID: 22718
        EFFECT_COUNTER_ATTACK = 901,
        // Token: 0x040058BF RID: 22719
        EFFECT_IMMUNE = 1001,
        // Token: 0x040058C0 RID: 22720
        EFFECT_PROVOKE = 1101,
        // Token: 0x040058C1 RID: 22721
        EFFECT_CARD_GRADE_UP = 1201
    }
}
