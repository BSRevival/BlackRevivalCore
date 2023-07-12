using System.Text.Json.Serialization;
using BlackRevival.Common.Util;

namespace BlackRevival.Common.Model;

public class Notice
{
	// Token: 0x04005F29 RID: 24361
	[JsonIgnore]
	public int id { get; set; }

	// Token: 0x04005F2A RID: 24362
	[JsonPropertyName("typ")]
	public NoticeType type{ get; set; }

	// Token: 0x04005F2B RID: 24363
	[JsonPropertyName("loc")]
	public string locale{ get; set; }

	// Token: 0x04005F2C RID: 24364
	[JsonPropertyName("tit")]
	public string title{ get; set; }

	// Token: 0x04005F2D RID: 24365
	[JsonPropertyName("ctt")]
	public string content{ get; set; }

	// Token: 0x04005F2E RID: 24366
	[JsonPropertyName("bsi")]
	public string bigSizeImage{ get; set; }

	// Token: 0x04005F2F RID: 24367
	[JsonPropertyName("bvl")]
	public int buttonValue{ get; set; }

	// Token: 0x04005F30 RID: 24368
	[JsonPropertyName("lif")]
	public string linkInformationButtonFirst{ get; set; }

	// Token: 0x04005F31 RID: 24369
	[JsonPropertyName("lis")]
	public string linkInformationButtonSecond{ get; set; }

	// Token: 0x04005F32 RID: 24370
	[JsonPropertyName("fbt")]
	public string firstButtonInText{ get; set; }

	// Token: 0x04005F33 RID: 24371
	[JsonPropertyName("sbt")]
	public string secondButtonInText{ get; set; }

	// Token: 0x04005F34 RID: 24372
	[JsonPropertyName("wfp")]
	public int widthButtonFirst{ get; set; }

	// Token: 0x04005F35 RID: 24373
	[JsonPropertyName("hfp")]
	public int hightButtonFirst{ get; set; }

	// Token: 0x04005F36 RID: 24374
	[JsonPropertyName("wsp")]
	public int widthButtonSecond{ get; set; }

	// Token: 0x04005F37 RID: 24375
	[JsonPropertyName("hwp")]
	public int hightButtonSecond{ get; set; }

	// Token: 0x04005F38 RID: 24376
	[JsonPropertyName("pxp")]
	public int posXButtonFirst{ get; set; }

	// Token: 0x04005F39 RID: 24377
	[JsonPropertyName("pyf")]
	public int posYButtonFirst{ get; set; }

	// Token: 0x04005F3A RID: 24378
	[JsonPropertyName("pxs")]
	public int posXButtonSecond{ get; set; }

	// Token: 0x04005F3B RID: 24379
	[JsonPropertyName("pys")]
	public int posYButtonSecond{ get; set; }

	// Token: 0x04005F3C RID: 24380
	[JsonPropertyName("ihs")]
	public string imageHash{ get; set; }

	// Token: 0x04005F3D RID: 24381
	[JsonPropertyName("styp")]
	public string subType{ get; set; }

	// Token: 0x04005F3E RID: 24382
	[JsonPropertyName("cdt")]
	[JsonConverter(typeof(MicrosecondEpochConverter))]
	public DateTime createDtm{ get; set; }
}