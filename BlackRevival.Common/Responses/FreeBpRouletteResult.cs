using BlackRevival.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Responses
{
    public class FreeBpRouletteResult
    {
        // Token: 0x04001217 RID: 4631
        public ProvideResult provideResult { get; set; }

        // Token: 0x04001218 RID: 4632
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime lastFreeBpRouletteDtm { get; set; }
    }
}