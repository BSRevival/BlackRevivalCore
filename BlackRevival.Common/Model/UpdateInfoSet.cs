using System.Text.Json.Serialization;
using BlackRevival.Common.GameDB.Item;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackSurvival.Model.Spectator
{
    public class UpdateInfoSet
    {
        [JsonPropertyName("chp")]
        public float currenHp;
        
        [JsonPropertyName("mhp")]
        public float maxHp;
        
        [JsonPropertyName("cst")]
        public float currenSt;
        
        [JsonPropertyName("mst")]
        public float maxSt;
        
        [JsonPropertyName("cto")]
        public float offence;
        
        [JsonPropertyName("ctd")]
        public float defence;
        
        [JsonPropertyName("iit")]
        public List<FieldItem> inventoryItems;
        
        [JsonPropertyName("eit")]
        public List<FieldItem> equipmentItems;
        
        [JsonPropertyName("lv")]
        public int level;
        
        [JsonPropertyName("wtp")]
        public AcE_WEAPON_TYPE weaponType;
        
        [JsonPropertyName("vg")]
        public VeteranGrade veteranGrade;
    }
}