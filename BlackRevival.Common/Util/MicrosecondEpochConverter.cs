using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Util
{
	public class MicrosecondEpochConverter : JsonConverter<DateTime>
	{
		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.Number)
			{
				throw new JsonException();
			}

			long microseconds = reader.GetInt64();
			return MicrosecondEpochConverter.Epoch.AddMilliseconds(microseconds).ToLocalTime();
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			var millisecondsSinceEpoch = (long)(value.ToUniversalTime() - Epoch).TotalMilliseconds;
			writer.WriteNumberValue(millisecondsSinceEpoch);
		}
	}
}
