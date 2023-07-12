using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionSkillStep
    {
        // Token: 0x04005883 RID: 22659
        NONE,
        // Token: 0x04005884 RID: 22660
        ALL,
        // Token: 0x04005885 RID: 22661
        BATTLE_START_1 = 10,
        // Token: 0x04005886 RID: 22662
        USE_CARD_START = 100,
        // Token: 0x04005887 RID: 22663
        USE_CARD_EFFECT_1,
        // Token: 0x04005888 RID: 22664
        USE_CARD_EFFECT_2,
        // Token: 0x04005889 RID: 22665
        USE_CARD_EFFECT_3,
        // Token: 0x0400588A RID: 22666
        USE_CARD_EFFECT_4,
        // Token: 0x0400588B RID: 22667
        USE_CARD_EFFECT_5,
        // Token: 0x0400588C RID: 22668
        USE_CARD_DAMAGE_1 = 201,
        // Token: 0x0400588D RID: 22669
        USE_CARD_DAMAGE_2,
        // Token: 0x0400588E RID: 22670
        USE_CARD_DAMAGE_3,
        // Token: 0x0400588F RID: 22671
        USE_CARD_DAMAGE_4,
        // Token: 0x04005890 RID: 22672
        USE_CARD_DAMAGE_5,
        // Token: 0x04005891 RID: 22673
        USE_CARD_AFTER_EFFECT_1 = 301,
        // Token: 0x04005892 RID: 22674
        USE_CARD_AFTER_EFFECT_2,
        // Token: 0x04005893 RID: 22675
        USE_CARD_AFTER_EFFECT_3,
        // Token: 0x04005894 RID: 22676
        USE_CARD_AFTER_EFFECT_4,
        // Token: 0x04005895 RID: 22677
        USE_CARD_AFTER_EFFECT_5,
        // Token: 0x04005896 RID: 22678
        USE_CARD_END = 400,
        // Token: 0x04005897 RID: 22679
        INITIAL_START_MY_TURN = 1001,
        // Token: 0x04005898 RID: 22680
        START_MY_TURN,
        // Token: 0x04005899 RID: 22681
        INITIAL_START_ENEMY_TURN,
        // Token: 0x0400589A RID: 22682
        START_ENEMY_TURN,
        // Token: 0x0400589B RID: 22683
        INITIAL_USE_CARD,
        // Token: 0x0400589C RID: 22684
        AFTER_INITIAL_USE_CARD = 1015,
        // Token: 0x0400589D RID: 22685
        USE_CARD = 1006,
        // Token: 0x0400589E RID: 22686
        INITIAL_USE_COMBAT_CARD,
        // Token: 0x0400589F RID: 22687
        USE_COMBAT_CARD,
        // Token: 0x040058A0 RID: 22688
        INITIAL_END_MY_TURN,
        // Token: 0x040058A1 RID: 22689
        END_MY_TURN,
        // Token: 0x040058A2 RID: 22690
        AFTER_INITIAL_USE_COMBAT_CARD = 1017,
        // Token: 0x040058A3 RID: 22691
        INITIAL_HIT_MYSELF = 2001,
        // Token: 0x040058A4 RID: 22692
        HIT_MYSELF,
        // Token: 0x040058A5 RID: 22693
        AFTER_HIT_MYSELF,
        // Token: 0x040058A6 RID: 22694
        TARGET_CRITICAL_ATK = 2011,
        // Token: 0x040058A7 RID: 22695
        ACTIVE_GUARD,
        // Token: 0x040058A8 RID: 22696
        USE_INVENTORY_ITEM = 3001,
        // Token: 0x040058A9 RID: 22697
        INITIAL_TARGET_DEAD = 4001,
        // Token: 0x040058AA RID: 22698
        TARGET_DEAD,
        // Token: 0x040058AB RID: 22699
        END_DAMAGE_STEP = 10001,
        // Token: 0x040058AC RID: 22700
        EQUIP_ITEM_DAMAGE
    }
}
