﻿using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class ResearcherTitleType
{
    public int p_code
    {
        get
        {
            return this._code;
        }
    }

    public string p_type
    {
        get
        {
            return this._type;
        }
    }

    public string p_texture
    {
        get
        {
            return this._texture;
        }
    }

    public ResearcherTitleType()
    {
    }

    public ResearcherTitleType(AcXmlNode rootNode)
    {
        if (!rootNode.GetAttr("Code", ref this._code))
        {
            Log.Error("[DataLoad] ResearcherTitleType - DataLoad Failed !!! -  Code");
        }
        if (!rootNode.GetAttr("Type", ref this._type))
        {
            Log.Error("[DataLoad] ResearcherTitleType - DataLoad Failed !!! -  Type");
        }
        if (!rootNode.GetAttr("Texture", ref this._texture))
        {
            Log.Error("[DataLoad] ResearcherTitleType - DataLoad Failed !!! -  Texture");
        }
    }
    
    private int _code;

    private string _type = string.Empty;

    private string _texture = string.Empty;
}