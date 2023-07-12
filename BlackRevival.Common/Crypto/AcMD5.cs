using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Crypto
{
    public static class AcMD5
    {
		public static string EncodeMD5(string strValue)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(strValue)))
			{
				stringBuilder.Append(b.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
