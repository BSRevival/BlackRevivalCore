
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Util
{
    public static class Helpers
    {
        public static string ByteArrayToStringHex(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.Append("0x");
                hex.AppendFormat("{0:X2} ", b);
            }
            return hex.ToString();
        }
        public static string ByteArrayToStringD(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0} ", b);
            }
            return hex.ToString();
        }



    }
}
