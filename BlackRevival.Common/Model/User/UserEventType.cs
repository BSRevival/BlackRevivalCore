using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public enum UserEventType
    {
        // Token: 0x04005CDD RID: 23773
        NONE,
        // Token: 0x04005CDE RID: 23774
        Search_Item,
        // Token: 0x04005CDF RID: 23775
        Search_Trap,
        // Token: 0x04005CE0 RID: 23776
        Search_Exp,
        // Token: 0x04005CE1 RID: 23777
        Search_Nothing,
        // Token: 0x04005CE2 RID: 23778
        Char_Equip,
        // Token: 0x04005CE3 RID: 23779
        Char_Exhaust,
        // Token: 0x04005CE4 RID: 23780
        Char_Stamina,
        // Token: 0x04005CE5 RID: 23781
        Char_HealthPoint,
        // Token: 0x04005CE6 RID: 23782
        Char_LevelUp = 10,
        // Token: 0x04005CE7 RID: 23783
        ChangeStance_Normal,
        // Token: 0x04005CE8 RID: 23784
        ChangeStance_Attack,
        // Token: 0x04005CE9 RID: 23785
        ChangeStance_Hide,
        // Token: 0x04005CEA RID: 23786
        ChangeStance_Search,
        // Token: 0x04005CEB RID: 23787
        Rest_Sleep,
        // Token: 0x04005CEC RID: 23788
        Rest_Cure,
        // Token: 0x04005CED RID: 23789
        Rest_FirstAid,
        // Token: 0x04005CEE RID: 23790
        MakeItem,
        // Token: 0x04005CEF RID: 23791
        Item_Silencer = 20,
        // Token: 0x04005CF0 RID: 23792
        Item_BlackIron_Ok,
        // Token: 0x04005CF1 RID: 23793
        Item_BlackIron_Blunt,
        // Token: 0x04005CF2 RID: 23794
        Item_BlackIron_Fail,
        // Token: 0x04005CF3 RID: 23795
        Item_Stone_Ok,
        // Token: 0x04005CF4 RID: 23796
        Item_Stone_Blunt,
        // Token: 0x04005CF5 RID: 23797
        Item_Stone_Fail,
        // Token: 0x04005CF6 RID: 23798
        Item_InstallTrap,
        // Token: 0x04005CF7 RID: 23799
        Item_Reload,
        // Token: 0x04005CF8 RID: 23800
        Fight_Wound = 91,
        // Token: 0x04005CF9 RID: 23801
        Fight_Blunt,
        // Token: 0x04005CFA RID: 23802
        Fight_Broken,
        // Token: 0x04005CFB RID: 23803
        HackingMap_Ok = 101,
        // Token: 0x04005CFC RID: 23804
        HackingMap_Fail,
        // Token: 0x04005CFD RID: 23805
        HackingMap_Nothing
    }
}
