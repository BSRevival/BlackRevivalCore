using System.Text.Json.Serialization;
using BlackRevival.Common.Model;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Apis;

public class PickUpApi
{
    public class PickUpEventGoods
    {
        [JsonPropertyName("idx")]
        public int index{ get; set; }

        [JsonPropertyName("gra")]
        public RouletteGoodsGradeData grade{ get; set; }

        [JsonPropertyName("prb")]
        public float prob{ get; set; }

        [JsonPropertyName("rwd")]
        public Goods rewardGoods{ get; set; }
    }
    
    public class UserPickUpEvent
    {
        [JsonPropertyName("eid")]
        public int eventId{ get; set; }

        [JsonPropertyName("rlst")]
        public List<int> rewardedIndexList { get; set; }
    }
    
    public class PickUpEvent
    {
        public bool IsProgress()
        {
            return DateTime.Now < this.endDtm;
        }

        [JsonPropertyName("eid")]
        public int eventId{ get; set; }

        [JsonPropertyName("pmtd")]
        public List<PurchaseMethod> purchaseMethod{ get; set; }

        [JsonPropertyName("pri")]
        public List<float> price{ get; set; }

        [JsonPropertyName("bdtm")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime startDtm{ get; set; }

        [JsonPropertyName("edtm")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        [JsonIgnore]
        public DateTime endDtm{ get; set; }

        [JsonPropertyName("gl")]
        public List<PickUpApi.PickUpEventGoods> goodsList{ get; set; }

        [JsonPropertyName("baimg")]
        
        public string bannerImage{ get; set; }

        [JsonPropertyName("baihs")]
        public string bannerImageHash{ get; set; }

        [JsonPropertyName("bigimg")]
        public string bigSizeImage{ get; set; }

        [JsonPropertyName("bigihs")]
        public string bigSizeImageHash{ get; set; }
    }
   
}