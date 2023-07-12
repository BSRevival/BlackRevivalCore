using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackRevival.Common.Util
{
	public class KeyValueList : List<KeyValuePair<string, object>>
	{
		// Token: 0x06006CA3 RID: 27811 RVA: 0x0004B87C File Offset: 0x00049A7C
		public KeyValueList()
		{
		}

		// Token: 0x06006CA4 RID: 27812 RVA: 0x0004B884 File Offset: 0x00049A84
		public KeyValueList(List<KeyValuePair<string, object>> list)
			: base(list)
		{
		}

		// Token: 0x06006CA6 RID: 27814 RVA: 0x001E2CF8 File Offset: 0x001E0EF8
		public KeyValueList(IDictionary dict)
		{
			foreach (object obj in dict.Keys)
			{
				this.Add(obj as string, dict[obj]);
			}
		}

		// Token: 0x06006CA7 RID: 27815 RVA: 0x001E2D60 File Offset: 0x001E0F60
		public KeyValueList(params object[] args)
		{
			int num = args.Length;
			for (int i = 0; i < num; i += 2)
			{
				this.Add(args[i] as string, (i + 1 >= num) ? null : args[i + 1]);
			}
		}

		// Token: 0x06006CA8 RID: 27816 RVA: 0x001E2DA0 File Offset: 0x001E0FA0
		public List<KeyValuePair<string, string>> ToStringValueList()
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (KeyValuePair<string, object> keyValuePair in this)
			{
				object value = keyValuePair.Value;
				if (value != null && value is IList)
				{
                    IEnumerator enumerator = (value as IList).GetEnumerator();
					IEnumerator? enumerator2 = enumerator;
					{
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							list.Add(new KeyValuePair<string, string>(keyValuePair.Key, (obj == null) ? null : obj.ToString()));
						}
						continue;
					}
				}
				list.Add(new KeyValuePair<string, string>(keyValuePair.Key, (value == null) ? null : value.ToString()));
			}
			return list;
		}

		// Token: 0x06006CAB RID: 27819 RVA: 0x001E2EF4 File Offset: 0x001E10F4
		public Hashtable ToHashtable()
		{
			Hashtable hashtable = new Hashtable();
			foreach (KeyValuePair<string, object> keyValuePair in this)
			{
				if (hashtable.ContainsKey(keyValuePair.Key))
				{
					object obj = hashtable[keyValuePair.Key];
					if (obj != null && obj is IList)
					{
						((IList)obj).Add(keyValuePair.Value);
					}
					else
					{
						List<object> list = new List<object>();
						list.Add(obj);
						list.Add(keyValuePair.Value);
						hashtable[keyValuePair.Key] = list;
					}
				}
				else
				{
					hashtable.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
			return hashtable;
		}

		// Token: 0x06006CAC RID: 27820 RVA: 0x0004B8C8 File Offset: 0x00049AC8
		public void Add(string key, object value)
		{
			base.Add(new KeyValuePair<string, object>(key, value));
		}

		// Token: 0x06006CAD RID: 27821 RVA: 0x001E2FC8 File Offset: 0x001E11C8
		public void Set(string key, string value)
		{
			int num = base.FindLastIndex((KeyValuePair<string, object> m) => m.Key == key);
			if (num < 0)
			{
				this.Add(key, value);
				return;
			}
			base[num] = new KeyValuePair<string, object>(key, value);
		}

		// Token: 0x06006CAE RID: 27822 RVA: 0x001E301C File Offset: 0x001E121C
		public object Get(string key)
		{
			int num = base.FindIndex((KeyValuePair<string, object> m) => m.Key == key);
			if (num >= 0)
			{
				return base[num].Value;
			}
			return null;
		}

		// Token: 0x06006CAF RID: 27823 RVA: 0x001E3060 File Offset: 0x001E1260
		public object GetLast(string key)
		{
			int num = base.FindLastIndex((KeyValuePair<string, object> m) => m.Key == key);
			if (num >= 0)
			{
				return base[num].Value;
			}
			return null;
		}

		// Token: 0x06006CB0 RID: 27824 RVA: 0x001E30A4 File Offset: 0x001E12A4
		public List<object> GetAll(string key)
		{
			return base.FindAll((KeyValuePair<string, object> m) => m.Key == key).ConvertAll<object>((KeyValuePair<string, object> p) => p.Value);
		}
	}
}
