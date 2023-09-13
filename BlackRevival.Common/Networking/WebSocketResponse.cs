using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Networking;

	public class WebSocketResponse
	{
		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06001B50 RID: 6992 RVA: 0x00014BEC File Offset: 0x00012DEC
		
		[JsonPropertyName("rid")]
		public long id { get; set; }

		// Token: 0x04001307 RID: 4871
		[JsonPropertyName("tme")]
		public long time { get; set; }

		// Token: 0x04001308 RID: 4872
		[JsonPropertyName("cod")]
		public int code { get; set; }

	}

