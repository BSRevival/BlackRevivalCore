using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class BgmType
{
    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public string p_fileName
    {
        get
        {
            return this._fileName;
        }
    }

    public BgmType()
    {
    }

    public BgmType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] BgmType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("FileName", ref this._fileName))
        {
            Log.Error("[DataLoad] BgmType - DataLoad Failed !!! -  FileName");
        }
    }

    private string _type = string.Empty;

    private string _fileName = string.Empty;
    
}