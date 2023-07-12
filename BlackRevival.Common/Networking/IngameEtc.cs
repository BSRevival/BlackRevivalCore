using BlackRevival.Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Networking
{
	public enum IngameRequestStates
	{
		Unsent,
		Sent,
		Done,
		Error,
		TimedOut
	}
	public enum IngameState
	{
		// Token: 0x04003BA8 RID: 15272
		NONE,
		// Token: 0x04003BA9 RID: 15273
		BASIC,
		// Token: 0x04003BAA RID: 15274
		ITEMPOPUP,
		// Token: 0x04003BAB RID: 15275
		REMAMBER_BOX,
		// Token: 0x04003BAC RID: 15276
		MAKE_ITEM,
		// Token: 0x04003BAD RID: 15277
		ALIVE_LIST,
		// Token: 0x04003BAE RID: 15278
		MINI_MAP,
		// Token: 0x04003BAF RID: 15279
		STANCE,
		// Token: 0x04003BB0 RID: 15280
		SUPPLY,
		// Token: 0x04003BB1 RID: 15281
		STARTING_SET,
		// Token: 0x04003BB2 RID: 15282
		REST,
		// Token: 0x04003BB3 RID: 15283
		CHARACTER,
		// Token: 0x04003BB4 RID: 15284
		BATTLE,
		// Token: 0x04003BB5 RID: 15285
		CORPSE,
		// Token: 0x04003BB6 RID: 15286
		NAVIGATOR,
		// Token: 0x04003BB7 RID: 15287
		CHAT,
		// Token: 0x04003BB8 RID: 15288
		CASTRING,
		// Token: 0x04003BB9 RID: 15289
		ITEM_DIC,
		// Token: 0x04003BBA RID: 15290
		HACKING,
		// Token: 0x04003BBB RID: 15291
		GAME_OVER,
		// Token: 0x04003BBC RID: 15292
		RESULT
	}
	public enum IngameClientStates
	{
		// Token: 0x040012DE RID: 4830
		Unconnected,
		// Token: 0x040012DF RID: 4831
		Connecting,
		// Token: 0x040012E0 RID: 4832
		ConnectingIpv6,
		// Token: 0x040012E1 RID: 4833
		Connected,
		// Token: 0x040012E2 RID: 4834
		Closing,
		// Token: 0x040012E3 RID: 4835
		Closed
	}
}
public static class IngameRequestStatesExtensions
{
	// Token: 0x06001B40 RID: 6976 RVA: 0x00014B44 File Offset: 0x00012D44
	public static bool IsFinal(this IngameRequestStates state)
	{
		return state >= IngameRequestStates.Done;
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x00014B4D File Offset: 0x00012D4D
	public static bool IsDone(this IngameRequestStates state)
	{
		return state == IngameRequestStates.Done;
	}
}