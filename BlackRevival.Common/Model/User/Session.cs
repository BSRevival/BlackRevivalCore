using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlackRevival.Common.Model
{
	public enum BuildPlatform
	{
		NIMBLE_NEURON = 0,
		ESOUL = 1,
		NETEASE = 2,
		Mobtech = 3
	}
	public enum OsType
	{
		NONE = 0,
		ANDROID = 1,
		IOS = 2,
		WINDOWS64 = 3,
		WINDOWS_DMM = 4,
		ETC = 99
	}

	public class Session
	{
		[JsonPropertyName("unm")]
		public long userNum{ get; set; }
		
		[JsonPropertyName("snm")]
		public int shardNum{ get; set; }

		[JsonPropertyName("atp")]
		[JsonIgnore]

		public AuthProvider authProvider{ get; set; }

		[JsonPropertyName("bpf")]
		public string buildPlatform{ get; set; }

		[JsonPropertyName("otp")]
		public OsType osType{ get; set; }

		[JsonPropertyName("ovs")]    
		[JsonIgnore]
		public string osVersion{ get; set; }

		[JsonPropertyName("avs")]
		[JsonIgnore]
		public string appVersion{ get; set; }

		[JsonPropertyName("gst")]
		public bool guest{ get; set; }

		[JsonPropertyName("snk")]
		public string sessionKey{ get; set; }

		[JsonPropertyName("dlc")]
		[JsonIgnore]
		public string deviceLanguageCode{ get; set; }

		[JsonPropertyName("alc")]
		[JsonIgnore]
		public string appLanguageCode{ get; set; }

		[JsonPropertyName("mkt")]
		[JsonIgnore]
		public Market market{ get; set; }

		[JsonPropertyName("atb")]
		[JsonIgnore]
		public string attribution{ get; set; }

		[JsonPropertyName("dloc")]
		[JsonIgnore]
		private string deviceLocationCode{ get; set; }

		public static Session Create(long userid, int shardNum = 0, string sessionKey = null)
		{
			
			Session session = new Session();
			session.userNum = userid;
			session.shardNum = shardNum;
			session.sessionKey = sessionKey;
			session.buildPlatform = "NIMBLE_NEURON";
			
			session.guest = false;
			session.osType = OsType.WINDOWS64;//OsTypeHelper.GetOsType();
			return session;
		}

		public void setAuthProvider(AuthProvider authProvider)
		{
			this.authProvider = authProvider;
			if (authProvider.Equals(AuthProvider.QQ) || authProvider.Equals(AuthProvider.WECHAT))
			{
				market = Market.XSOLLA;
			}
		}
	}

}
