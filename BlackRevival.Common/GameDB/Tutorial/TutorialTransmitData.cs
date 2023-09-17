using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Tutorial;

public class TutorialTransmit
{
	[JsonPropertyName("cod")]
	public int code { get; set; }

	[JsonPropertyName("ttn")]
	public int tutorialNum { get; set; }

	[JsonPropertyName("gds")]
	public Goods[] goods { get; set; }
}