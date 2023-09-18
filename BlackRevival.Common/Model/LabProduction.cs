using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

    public class LabProduction
    {
        [ForeignKey("User")]
        [JsonPropertyName("unm")]
        public long userNum { get; private set; }
        
        [Key]
        [JsonPropertyName("lnm")]
        public long labNum { get; private set; }

        [JsonPropertyName("cps")]
        public string components { get; private set; }

        [JsonPropertyName("sdtm")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime startDtm { get; private set; }

        [JsonPropertyName("edtm")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime endDtm { get; private set; }

        [JsonPropertyName("pcnt")]
        public int productCount { get; private set; }

        [JsonPropertyName("acq")]
        public bool acquire { get; private set; }

        [JsonPropertyName("nts")]
        public int needTimeSec { get; private set; }

        public LabProduction.State GetState()
        {
            if (this.needTimeSec > 0)
            {
                return LabProduction.State.Wait;
            }
            bool flag = this.needTimeSec == 0 && DateTime.Now < this.endDtm;
            if (flag)
            {
                return LabProduction.State.InProgress;
            }
            if (!flag && !this.acquire)
            {
                return LabProduction.State.Complete;
            }
            return LabProduction.State.None;
        }

        public double GetTotalSeconds()
        {
            return (this.endDtm - this.startDtm).TotalSeconds;
        }

        public double GetExpireSeconds()
        {
            return (this.endDtm - DateTime.Now).TotalSeconds;
        }

        public bool IsExpired()
        {
            return DateTime.Now >= this.endDtm;
        }

        public enum State
        {
            None,
            Wait,
            InProgress,
            Complete
        }
    }