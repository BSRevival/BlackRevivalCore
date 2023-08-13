using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Xml;
using Serilog;

namespace BlackRevival.Common.Util;

public class AcXmlNode
{
	public XmlElement p_xmlElement
	{
		get
		{
			return this._xmlElement;
		}
	}

	public string p_InnerXml
	{
		get
		{
			if (this._xmlElement != null)
			{
				return this._xmlElement.InnerXml;
			}
			return string.Empty;
		}
		set
		{
			if (this._xmlElement != null)
			{
				this._xmlElement.InnerXml = value;
			}
		}
	}

	public AcXmlNode(XmlElement xmlElement)
	{
		this._xmlElement = xmlElement;
	}

	public AcXmlNode AddNode(string strNodeName)
	{
		XmlElement xmlElement = this._xmlElement.OwnerDocument.CreateElement(strNodeName);
		this._xmlElement.AppendChild(xmlElement);
		return new AcXmlNode(xmlElement);
	}

	public void AddAttribute(string strAttrName, string strValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.OwnerDocument.CreateAttribute(strAttrName);
		xmlAttribute.Value = strValue;
		this._xmlElement.SetAttributeNode(xmlAttribute);
	}

	public AcXmlNode AddNodeAttribute(string strNodeName, string strAttrName, string strValue)
	{
		AcXmlNode acXmlNode = this.AddNode(strNodeName);
		acXmlNode.AddAttribute(strAttrName, strValue);
		return acXmlNode;
	}

	public bool RemoveNode(AcXmlNode removeNode)
	{
		this._xmlElement.RemoveChild(removeNode._xmlElement);
		return true;
	}

	public bool RemoveAttribute(string strAttrName)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		this._xmlElement.RemoveAttributeNode(xmlAttribute);
		return true;
	}

	public bool HasChild()
	{
		return this._xmlElement.HasChildNodes;
	}

	public AcXmlNode GetChild(string strNodeName)
	{
		XmlElement xmlElement = this._xmlElement.SelectSingleNode(strNodeName) as XmlElement;
		if (xmlElement == null)
		{
			return null;
		}
		return new AcXmlNode(xmlElement);
	}

	public List<AcXmlNode> GetChilds(string strNodeName)
	{
		XmlNodeList xmlNodeList = this._xmlElement.SelectNodes(strNodeName);
		if (xmlNodeList.Count <= 0)
		{
			return null;
		}
		List<AcXmlNode> list = new List<AcXmlNode>();
		foreach (object obj in xmlNodeList)
		{
			XmlNode xmlNode = (XmlNode)obj;
			if (xmlNode.NodeType != XmlNodeType.Comment)
			{
				AcXmlNode item = new AcXmlNode(xmlNode as XmlElement);
				list.Add(item);
			}
		}
		return list;
	}

	public List<AcXmlNode> GetChilds()
	{
		XmlNodeList childNodes = this._xmlElement.ChildNodes;
		if (childNodes.Count <= 0)
		{
			return null;
		}
		List<AcXmlNode> list = new List<AcXmlNode>();
		foreach (object obj in childNodes)
		{
			XmlNode xmlNode = (XmlNode)obj;
			if (xmlNode.NodeType != XmlNodeType.Comment)
			{
				AcXmlNode item = new AcXmlNode(xmlNode as XmlElement);
				list.Add(item);
			}
		}
		return list;
	}

	public bool HasAttr(string strAttrName)
	{
		return this._xmlElement.HasAttribute(strAttrName);
	}

	public bool TryGet(string strAttrName, ref string strValue)
	{
		return this.GetAttr(strAttrName, ref strValue);
	}

	public bool TryGetAttr(string strAttrName, out string strValue)
	{
		strValue = string.Empty;
		return this.GetAttr(strAttrName, ref strValue);
	}

	public bool GetAttr(string strAttrName, ref string strValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			strValue = xmlAttribute.Value;
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			strValue = xmlAttribute.Value.ToString();
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out byte byValue)
	{
		byValue = 0;
		return this.GetAttr(strAttrName, ref byValue);
	}

	public bool GetAttr(string strAttrName, ref byte byValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			byValue = Convert.ToByte(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			byValue = byte.Parse(xmlAttribute.Value);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out int iValue)
	{
		iValue = 0;
		return this.GetAttr(strAttrName, ref iValue);
	}

	public bool GetAttr(string strAttrName, ref int iValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			iValue = Convert.ToInt32(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			iValue = int.Parse(xmlAttribute.Value);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out uint iValue)
	{
		iValue = 0U;
		return this.GetAttr(strAttrName, ref iValue);
	}

	public bool GetAttr(string strAttrName, ref uint iValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			iValue = Convert.ToUInt32(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			iValue = uint.Parse(xmlAttribute.Value);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out ulong re_value)
	{
		re_value = 0UL;
		return this.GetAttr(strAttrName, ref re_value);
	}

	public bool GetAttr(string strAttrName, ref ulong re_value)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			re_value = Convert.ToUInt64(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			re_value = ulong.Parse(xmlAttribute.Value);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out float fValue)
	{
		fValue = 0f;
		return this.GetAttr(strAttrName, ref fValue);
	}

	public bool GetAttr(string strAttrName, ref float fValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			fValue = Convert.ToSingle(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			fValue = float.Parse(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out ushort fValue)
	{
		fValue = 0;
		return this.GetAttr(strAttrName, ref fValue);
	}

	public bool GetAttr(string strAttrName, ref ushort fValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			fValue = Convert.ToUInt16(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
			fValue = ushort.Parse(xmlAttribute.Value);
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out bool bValue)
	{
		bValue = false;
		return this.GetAttr(strAttrName, ref bValue);
	}

	public bool GetAttr(string strAttrName, ref bool bValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			bValue = false;
			if (xmlAttribute.Value.ToUpper() == "TRUE")
			{
				bValue = true;
			}
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out Vector3 vecValue)
	{
		vecValue = default(Vector3);
		return this.GetAttr(strAttrName, ref vecValue);
	}

	public bool GetAttr(string strAttrName, ref Vector3 vecValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			string[] array = xmlAttribute.Value.Trim(new char[] { '(', ')' }).Replace(" ", "").Split(new char[] { ',' });
			vecValue.X = float.Parse(array[0]);
			vecValue.Y = float.Parse(array[1]);
			vecValue.Z = float.Parse(array[2]);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out Vector4 vecValue)
	{
		vecValue = default(Vector4);
		return this.GetAttr(strAttrName, ref vecValue);
	}

	public bool GetAttr(string strAttrName, ref Vector4 vecValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			string[] array = xmlAttribute.Value.Trim(new char[] { '(', ')', ' ' }).Split(new char[] { ',' });
			vecValue.X = float.Parse(array[0]);
			vecValue.Y = float.Parse(array[1]);
			vecValue.Z = float.Parse(array[2]);
			vecValue.W = float.Parse(array[3]);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return true;
	}

	public bool TryGetAttr(string strAttrName, out Color vecValue)
	{
		vecValue = default(Color);
		return this.GetAttr(strAttrName, ref vecValue);
	}

	public bool GetAttr(string strAttrName, ref Color vecValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			return false;
		}
		try
		{
			string[] array = xmlAttribute.Value.Trim(new char[] { '(', ')', ' ', 'R', 'G', 'B', 'A' }).Split(new char[] { ',' });
			vecValue = Color.FromArgb(int.Parse(array[3])*255, int.Parse(array[0])*255, int.Parse(array[1])*255, int.Parse(array[2])*255);
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return true;
	}

	public bool TryGetAttr<T>(string strAttrName, out T enumValue)
	{
		enumValue = default(T);
		return this.GetAttr<T>(strAttrName, ref enumValue);
	}

	public bool GetAttr<T>(string strAttrName, ref T enumValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			enumValue = default(T);
			return false;
		}
		try
		{
			if (AcEnum.IsDefined<T>(xmlAttribute.Value))
			{
				enumValue = AcEnum.Convert<T>(xmlAttribute.Value);
				return true;
			}
			if (AcEnum.IsDefined<T>(xmlAttribute.Value.ToUpper()))
			{
				enumValue = AcEnum.Convert<T>(xmlAttribute.Value.ToUpper());
				return true;
			}
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return false;
	}

	public bool TryGetAttr(string strAttrName, out DateTime dateTimeValue)
	{
		dateTimeValue = default(DateTime);
		return this.GetAttr(strAttrName, ref dateTimeValue);
	}

	public bool GetAttr(string strAttrName, ref DateTime dateTimeValue)
	{
		XmlAttribute xmlAttribute = this._xmlElement.Attributes.GetNamedItem(strAttrName) as XmlAttribute;
		if (xmlAttribute == null)
		{
			dateTimeValue = default(DateTime);
			return false;
		}
		try
		{
			DateTimeOffset dateTimeOffset;
			if (DateTimeOffset.TryParse(xmlAttribute.Value, AcXmlNode.FIX_CULTURE_INFO, DateTimeStyles.None, out dateTimeOffset))
			{
				dateTimeValue = dateTimeOffset.DateTime;
				return true;
			}
			dateTimeValue = default(DateTime);
		}
		catch (Exception ex)
		{
			Log.Fatal(ex.Message);
			Log.Error(string.Format("[Xml] Error!!! xml load failed - Code : {0}, Key : {1}, Value : {2}", this._xmlElement.Name, strAttrName, xmlAttribute.Value));
		}
		return false;
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref string strValue)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		return child != null && child.GetAttr(strAttrName, ref strValue);
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref int iValue)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		return child != null && child.GetAttr(strAttrName, ref iValue);
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref uint iValue)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		return child != null && child.GetAttr(strAttrName, ref iValue);
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref ulong re_value)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		return child != null && child.GetAttr(strAttrName, ref re_value);
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref float fValue)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		return child != null && child.GetAttr(strAttrName, ref fValue);
	}

	public bool GetChildAttr(string strNodeName, string strAttrName, ref bool bValue)
	{
		AcXmlNode child = this.GetChild(strNodeName);
		if (child == null)
		{
			return false;
		}
		string empty = string.Empty;
		if (!child.GetAttr(strAttrName, ref empty))
		{
			return false;
		}
		bValue = false;
		if (empty.ToUpper() == "TRUE")
		{
			bValue = true;
		}
		return true;
	}

	public AcXmlNode GetParentNode()
	{
		return new AcXmlNode(this._xmlElement.ParentNode as XmlElement);
	}

	private XmlElement _xmlElement;

	private static readonly CultureInfo FIX_CULTURE_INFO = new CultureInfo("en-US");
}