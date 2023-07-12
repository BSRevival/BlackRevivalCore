using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ExpeditionStepCondition
    {
        // Token: 0x040058EE RID: 22766
        NONE,
        // Token: 0x040058EF RID: 22767
        COMPLETE_EFFECT = 1011,
        // Token: 0x040058F0 RID: 22768
        TARGET_HEALTH = 201,
        // Token: 0x040058F1 RID: 22769
        TARGET_HEALTH_UNDER,
        // Token: 0x040058F2 RID: 22770
        TARGET_HEALTH_UPPER,
        // Token: 0x040058F3 RID: 22771
        TARGET_HAVE_EFFECT = 301,
        // Token: 0x040058F4 RID: 22772
        TARGET_NOT_HAVE_EFFECT,
        // Token: 0x040058F5 RID: 22773
        TARGET_SKILL = 402,
        // Token: 0x040058F6 RID: 22774
        TARGET_NEW_TURN,
        // Token: 0x040058F7 RID: 22775
        ON_EFFECT_KILL_ENEMY = 401,
        // Token: 0x040058F8 RID: 22776
        USE_FOOD_ITEM = 501,
        // Token: 0x040058F9 RID: 22777
        PROBABILITY = 601,
        // Token: 0x040058FA RID: 22778
        HAND_HAVE_CARD = 701,
        // Token: 0x040058FB RID: 22779
        TARGET_COUNT_1 = 801,
        // Token: 0x040058FC RID: 22780
        TARGET_UNIT_CLASS_WILD_ANIMAL,
        // Token: 0x040058FD RID: 22781
        TARGET_UNIT_CLASS_ENEMY_CHARACTER,
        // Token: 0x040058FE RID: 22782
        ACTIVATE_TARGET_SKILL = 1001,
        // Token: 0x040058FF RID: 22783
        DAMAGE_AFTER_TARGET_HEALTH_UNDER = 10001,
        // Token: 0x04005900 RID: 22784
        TARGET_DEADLY_HIT,
        // Token: 0x04005901 RID: 22785
        TARGET_BEING_EFFECT = 1301,
        // Token: 0x04005902 RID: 22786
        TARGET_BEING_NOT_EFFECT
    }
}
