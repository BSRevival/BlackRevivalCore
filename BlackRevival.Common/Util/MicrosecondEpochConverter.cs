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
			return Epoch.AddTicks(microseconds * 10);
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			TimeSpan timeSpan = value.ToUniversalTime() - Epoch;
			long microseconds = (long)timeSpan.TotalMilliseconds * 1000;
			writer.WriteNumberValue(microseconds);
		}
	}
}
