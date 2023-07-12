using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionSkillDamageType
    {
        // Token: 0x04005646 RID: 22086
        NONE,
        // Token: 0x04005647 RID: 22087
        MYSELF_SKILL_DMG_P,
        // Token: 0x04005648 RID: 22088
        MYSELF_HP_DMG_P,
        // Token: 0x04005649 RID: 22089
        MYSELF_LOSS_HP_DMG_S_DIVISION,
        // Token: 0x0400564A RID: 22090
        MYSELF_STACK_SKILL_DMG_P_MULTIPLY,
        // Token: 0x0400564B RID: 22091
        ENEMY_MAX_HP_SKILL_DMG_P,
        // Token: 0x0400564C RID: 22092
        ENEMY_STACK_SKILL_DMG_P_MULTIPLY,
        // Token: 0x0400564D RID: 22093
        MYSELF_LOSS_HP_SKILL_DMG_P,
        // Token: 0x0400564E RID: 22094
        ENEMY_MAX_HP_SKILL_DMG_S,
        // Token: 0x0400564F RID: 22095
        MYSELF_CARD_COUNT_DMG_P,
        // Token: 0x04005650 RID: 22096
        MYSELF_CURRENCY_HP_P_MULTIPLY_2,
        // Token: 0x04005651 RID: 22097
        LOSE_MY_HP,
        // Token: 0x04005652 RID: 22098
        ENEMY_ADD_DMG_COUNT_MULTIPLY = 13,
        // Token: 0x04005653 RID: 22099
        ENEMY_LOSS_HP_DMG_S = 31,
        // Token: 0x04005654 RID: 22100
        MYSELF_CURRENCY_HP_P
    }
}
