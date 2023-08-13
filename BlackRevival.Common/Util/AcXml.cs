using System.Xml;
using Serilog;

namespace BlackRevival.Common.Util;

public class AcXml
{
	public string p_InnerXml
	{
		get
		{
			if (this._doc != null)
			{
				return this._doc.InnerXml;
			}
			return string.Empty;
		}
	}

	public bool IsLoad
	{
		get
		{
			return this._doc != null;
		}
	}

	public void Save(string strFileName)
	{
		this._doc.Save(strFileName);
	}

	public AcXmlNode CreateRootNode(string strNodeName)
	{
		this._doc = new XmlDocument();
		this._doc.AppendChild(this._doc.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
		XmlElement xmlElement = this._doc.CreateElement(strNodeName);
		this._doc.AppendChild(xmlElement);
		return new AcXmlNode(xmlElement);
	}

	public bool Load(string strFileName, bool bLoadResMgr = false)
	{
		this._doc = new XmlDocument();
		if (bLoadResMgr)
		{
			XmlReader reader = XmlReader.Create(new FileStream(strFileName, FileMode.Open, FileAccess.Read));
			try
			{
				this._doc.Load(reader);
				return true;
			}
			catch (Exception ex)
			{
				Log.Error("xml load error : " + strFileName);
				Log.Error(ex.ToString());
				return false;
			}
		}
		try
		{
			this._doc.Load(strFileName);
		}
		catch (Exception ex2)
		{
			Log.Error("xml load error : " + strFileName);
			Log.Error(ex2.ToString());
			return false;
		}
		return true;
	}

	public void LoadXml(string strXml)
	{
		this._doc = new XmlDocument();
		this._doc.LoadXml(strXml);
	}

	public AcXmlNode GetRootChild(string strNodeName)
	{
		if (this._doc == null)
		{
			return null;
		}
		return new AcXmlNode(this._doc.SelectSingleNode(strNodeName) as XmlElement);
	}

	public List<AcXmlNode> GetAllChildData(string rootType, bool includeComment = false)
	{
		List<AcXmlNode> list = new List<AcXmlNode>();
		XmlNodeList childNodes = this.GetRootChild(rootType).p_xmlElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			XmlNode xmlNode = childNodes.Item(i);
			if (includeComment || (!xmlNode.OuterXml.Contains("<!--") && !xmlNode.OuterXml.Contains("-->")))
			{
				list.Add(new AcXmlNode(xmlNode as XmlElement));
			}
		}
		return list;
	}

	public List<AcXmlNode> GetAllChildData(string rootType, string nodeType, string nodeFormat, bool includeComment = false)
	{
		List<AcXmlNode> list = new List<AcXmlNode>();
		AcXmlNode rootChild = this.GetRootChild(rootType);
		XmlNodeList childNodes = rootChild.p_xmlElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			XmlNode xmlNode = childNodes.Item(i);
			if (includeComment || (!xmlNode.OuterXml.Contains("<!--") && !xmlNode.OuterXml.Contains("-->")))
			{
				AcXmlNode acXmlNode = new AcXmlNode(xmlNode as XmlElement);
				string empty = string.Empty;
				if (!acXmlNode.GetAttr(nodeType, ref empty))
				{
					Log.Error(string.Format("[DataLoad] Error 1 !!!  Not found NodeData   rootType - {0}, nodeType - {1}", rootType, nodeType));
				}
				else
				{
					string text = string.Format(nodeFormat, empty);
					AcXmlNode child = rootChild.GetChild(text);
					if (child == null)
					{
						Log.Error(string.Format("[DataLoad] Error 2 !!! Not found NodeData   nodeType - {0}, formatType - {1}", nodeType, text));
					}
					else
					{
						list.Add(child);
					}
				}
			}
		}
		return list;
	}

	private XmlDocument _doc;

	public bool dumpXmls;
}