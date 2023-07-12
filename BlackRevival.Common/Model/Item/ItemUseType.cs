using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum ItemUseType
    {
        // Token: 0x04005A7C RID: 23164
        None,
        // Token: 0x04005A7D RID: 23165
        Get,
        // Token: 0x04005A7E RID: 23166
        Mix,
        // Token: 0x04005A7F RID: 23167
        Abandon,
        // Token: 0x04005A80 RID: 23168
        Use,
        // Token: 0x04005A81 RID: 23169
        Drop,
        // Token: 0x04005A82 RID: 23170
        UnEquip,
        // Token: 0x04005A83 RID: 23171
        Equip,
        // Token: 0x04005A84 RID: 23172
        Install,
        // Token: 0x04005A85 RID: 23173
        CastingToGet,
        // Token: 0x04005A86 RID: 23174
        DropSupplyItem,
        // Token: 0x04005A87 RID: 23175
        Upload,
        // Token: 0x04005A88 RID: 23176
        Download
    }
}
