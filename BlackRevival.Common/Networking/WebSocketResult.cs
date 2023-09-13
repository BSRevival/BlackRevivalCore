
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Networking
{
	public class WebSocketResult<T>
	{
		// Token: 0x0400130C RID: 4876
		[JsonPropertyName("rst")]
		public T result {get; set;}
	}
}
