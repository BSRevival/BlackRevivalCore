using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
    public class Honor
    {
		[JsonPropertyName("num")]
		public int honorNum;

		[JsonPropertyName("sou")]
		public int userNum;

		[JsonPropertyName("nic")]
		public string nickname;

		[JsonPropertyName("sop")]
		public int rankPoint;

		public int rank;
	}
}
