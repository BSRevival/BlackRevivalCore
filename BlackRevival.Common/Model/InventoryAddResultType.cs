using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum InventoryAddResultType
    {
        // Token: 0x04005A28 RID: 23080
        NONE,
        // Token: 0x04005A29 RID: 23081
        PARTIAL_ADDED,
        // Token: 0x04005A2A RID: 23082
        SUCCESS,
        // Token: 0x04005A2B RID: 23083
        NO_AVAILABLE_SLOT,
        // Token: 0x04005A2C RID: 23084
        ZERO_QTY
    }
}
