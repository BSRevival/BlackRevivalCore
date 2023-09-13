using System;
using System.Collections;
using System.Text.Json;
using Serilog;

namespace BlackRevival.Common.Networking
{
	public class IngameRequest : IEnumerator
	{
		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06001B2C RID: 6956 RVA: 0x00014A3C File Offset: 0x00012C3C
		// (set) Token: 0x06001B2D RID: 6957 RVA: 0x00014A44 File Offset: 0x00012C44
		public long RequestId { get; protected set; }

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06001B2E RID: 6958 RVA: 0x00014A4D File Offset: 0x00012C4D
		// (set) Token: 0x06001B2F RID: 6959 RVA: 0x00014A55 File Offset: 0x00012C55
		public IngameRequestStates State { get; protected set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06001B30 RID: 6960 RVA: 0x00014A5E File Offset: 0x00012C5E
		// (set) Token: 0x06001B31 RID: 6961 RVA: 0x00014A66 File Offset: 0x00012C66
		public Type ResultType { get; protected set; }

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x00014A6F File Offset: 0x00012C6F
		// (set) Token: 0x06001B33 RID: 6963 RVA: 0x00014A77 File Offset: 0x00012C77
		public string RequestMethod { get; protected set; }

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06001B34 RID: 6964 RVA: 0x00014A80 File Offset: 0x00012C80
		// (set) Token: 0x06001B35 RID: 6965 RVA: 0x000C1230 File Offset: 0x000BF430
		public WebSocketMessage Response
		{
			get
			{
				return this.response;
			}
			internal set
			{
				if (!this.State.IsFinal())
				{
					this.response = value;
					if (this.response == null)
					{
						this.Exception = new Exception("Null response");
						return;
					}
					if (this.response.code == 200)
					{
						this.State = IngameRequestStates.Done;
						return;
					}
					this.Exception = new IngameException(this.response);
				}
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06001B36 RID: 6966 RVA: 0x00014A88 File Offset: 0x00012C88
		// (set) Token: 0x06001B37 RID: 6967 RVA: 0x00014A90 File Offset: 0x00012C90
		public Exception Exception
		{
			get
			{
				return this.exception;
			}
			set
			{
				if (!this.State.IsFinal())
				{
					this.exception = value;
					if (this.exception is TimeoutException)
					{
						this.State = IngameRequestStates.TimedOut;
						return;
					}
					this.State = IngameRequestStates.Error;
				}
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06001B38 RID: 6968 RVA: 0x00014AC2 File Offset: 0x00012CC2
		// (set) Token: 0x06001B39 RID: 6969 RVA: 0x00014ACA File Offset: 0x00012CCA
		public DateTime RequestTime
		{
			get
			{
				return this.requestTime;
			}
			internal set
			{
				if (this.State == IngameRequestStates.Unsent)
				{
					this.requestTime = value;
					this.State = IngameRequestStates.Sent;
				}
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06001B3A RID: 6970 RVA: 0x00014AE2 File Offset: 0x00012CE2
		public TimeSpan Elasped
		{
			get
			{
				return DateTime.UtcNow - this.RequestTime;
			}
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x00014AF4 File Offset: 0x00012CF4
		public IngameRequest(WebSocketRequest req, Type responseType)
		{
			this.RequestId = req.id;
			this.RequestMethod = req.method;
			this.ResultType = responseType;
			this.State = IngameRequestStates.Unsent;
		}

		// Token: 0x06001B3C RID: 6972
		public T Result<T>()
		{
			T result;
			try
			{
				result = JsonSerializer.Deserialize<WebSocketResult<T>>(this.Response.json).result;
				Log.Debug(this.Response.json);
			}
			catch (Exception ex)
			{
				Log.Error("[IngameReqest] e = {0}", new object[] { ex.Message });
				result = default(T);
			}
			return result;
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06001B3D RID: 6973 RVA: 0x0000EFB0 File Offset: 0x0000D1B0
		public object Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x00014B2D File Offset: 0x00012D2D
		public bool MoveNext()
		{
			return !this.State.IsFinal();
		}

		// Token: 0x06001B3F RID: 6975 RVA: 0x00014B3D File Offset: 0x00012D3D
		public void Reset()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040012EA RID: 4842
		protected DateTime requestTime = DateTime.UtcNow;

		// Token: 0x040012EB RID: 4843
		protected WebSocketMessage response;

		// Token: 0x040012EC RID: 4844
		protected Exception exception;
	}

}
