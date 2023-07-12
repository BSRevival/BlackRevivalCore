using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackRevival.Common.Model;

namespace BlackRevival.Common.Networking
{
	public class IngameException : Exception
	{
		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x00014A1A File Offset: 0x00012C1A
		// (set) Token: 0x06001B28 RID: 6952 RVA: 0x00014A22 File Offset: 0x00012C22
		public int Code { get; private set; }

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x00014A2B File Offset: 0x00012C2B
		// (set) Token: 0x06001B2A RID: 6954 RVA: 0x00014A33 File Offset: 0x00012C33
		public BattleActionErrorType ErrorType { get; private set; }

		// Token: 0x06001B2B RID: 6955 RVA: 0x000C11C0 File Offset: 0x000BF3C0
		public IngameException(WebSocketMessage msg)
			: base(msg.msg)
		{
			this.Code = msg.code;
			this.ErrorType = (BattleActionErrorType)this.Code;
			Log.Error(string.Concat(new object[] { "[ERROR] ", this.Code, " || ", this.ErrorType }));
		}
	}
}
