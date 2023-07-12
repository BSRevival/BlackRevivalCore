using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum GameInfoType
    {
        // Token: 0x04005DD8 RID: 24024
        NONE,
        // Token: 0x04005DD9 RID: 24025
        RANDOM_ITEM_DROP = 11,
        // Token: 0x04005DDA RID: 24026
        MONSTER_APPEAR = 21,
        // Token: 0x04005DDB RID: 24027
        MONSTER_DEAD,
        // Token: 0x04005DDC RID: 24028
        MONSTER_REGEN,
        // Token: 0x04005DDD RID: 24029
        MASTERY_ARRIVE = 31,
        // Token: 0x04005DDE RID: 24030
        ARRIVE_LEVEL
    }
}
