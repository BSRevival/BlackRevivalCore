using System.Text.Json.Serialization;
using BlackRevival.Common.Enums;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.GameDB.Tutorial;

public class TutorialTransmit
{
	[JsonPropertyName("cod")]
	public int code;

	[JsonPropertyName("ttn")]
	public int tutorialNum;

	[JsonPropertyName("gds")]
	public Goods[] goods;
}