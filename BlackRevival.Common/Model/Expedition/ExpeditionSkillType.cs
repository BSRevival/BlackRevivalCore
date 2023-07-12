using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionSkillType
    {
        // Token: 0x040058D8 RID: 22744
        NONE,
        // Token: 0x040058D9 RID: 22745
        DAMAGE = 101,
        // Token: 0x040058DA RID: 22746
        ADD_EFFECT = 201,
        // Token: 0x040058DB RID: 22747
        ADD_STATUS,
        // Token: 0x040058DC RID: 22748
        CHANGE_EFFECT,
        // Token: 0x040058DD RID: 22749
        CHANGE_STATUS,
        // Token: 0x040058DE RID: 22750
        RECOVERY = 301,
        // Token: 0x040058DF RID: 22751
        RECOVERY_ACTION_COST,
        // Token: 0x040058E0 RID: 22752
        BUFF = 401,
        // Token: 0x040058E1 RID: 22753
        DEBUFF = 501,
        // Token: 0x040058E2 RID: 22754
        EFFECT_STATUS,
        // Token: 0x040058E3 RID: 22755
        EFFECT_EQUIPMENT,
        // Token: 0x040058E4 RID: 22756
        EFFECT_BACKPACK,
        // Token: 0x040058E5 RID: 22757
        STACK = 601,
        // Token: 0x040058E6 RID: 22758
        REMOVE = 701,
        // Token: 0x040058E7 RID: 22759
        REMOVE_RANDOM_CARD_1,
        // Token: 0x040058E8 RID: 22760
        COPY_ITEM = 801,
        // Token: 0x040058E9 RID: 22761
        ADD_MASTERY = 901,
        // Token: 0x040058EA RID: 22762
        ADD_CARD_RANDOM = 1001,
        // Token: 0x040058EB RID: 22763
        ADD_CARD_TARGET,
        // Token: 0x040058EC RID: 22764
        CONSUME = 1101
    }
}
