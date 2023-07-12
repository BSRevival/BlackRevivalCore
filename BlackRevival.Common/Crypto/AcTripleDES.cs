using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Crypto
{
	public static class AcTripleDES
	{
		public static byte[] CreateSecret(string key)
		{
			return AcTripleDES.CreateSecret(key, Encoding.UTF8);
		}

		public static byte[] CreateSecret(string key, Encoding encoding)
		{
			return new MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(key));
		}

		// Token: 0x060044BE RID: 17598 RVA: 0x00153D2C File Offset: 0x00151F2C
		public static string EncodeTripleDES(string strKey, string strValue)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(strValue);
			return Convert.ToBase64String(new TripleDESCryptoServiceProvider
			{
				Key = AcTripleDES.CreateSecret(strKey),
				Mode = CipherMode.ECB
			}.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
		}

		// Token: 0x060044BF RID: 17599 RVA: 0x00153D74 File Offset: 0x00151F74
		public static string DecodeTripleDES(string strKey, string strValue)
		{
			if (strValue.Length <= 0)
			{
				return "";
			}
			byte[] array = Convert.FromBase64String(strValue);
			byte[] bytes = new TripleDESCryptoServiceProvider
			{
				Key = AcTripleDES.CreateSecret(strKey),
				Mode = CipherMode.ECB
			}.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x060044C0 RID: 17600 RVA: 0x00153DCC File Offset: 0x00151FCC
		public static string EncodeTripleDES(string strKey, string strValue, Encoding encodingType)
		{
			byte[] bytes = encodingType.GetBytes(strValue);
			return Convert.ToBase64String(new TripleDESCryptoServiceProvider
			{
				Key = AcTripleDES.CreateSecret(strKey, encodingType),
				Mode = CipherMode.ECB
			}.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
		}

		// Token: 0x060044C1 RID: 17601 RVA: 0x00153E10 File Offset: 0x00152010
		public static string DecodeTripleDES(string strKey, string strValue, Encoding encodingType)
		{
			byte[] array = Convert.FromBase64String(strValue);
			byte[] bytes = new TripleDESCryptoServiceProvider
			{
				Key = AcTripleDES.CreateSecret(strKey, encodingType),
				Mode = CipherMode.ECB
			}.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			return encodingType.GetString(bytes);
		}
	}
}
