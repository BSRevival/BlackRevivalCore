using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model
{
	public class StartWaitngTime
	{
		// Token: 0x04005E48 RID: 24136
		public bool startInstant;

		// Token: 0x04005E49 RID: 24137
		[JsonConverter(typeof(MicrosecondEpochConverter))]
		public DateTime startAfterWaiting;
	}
}
