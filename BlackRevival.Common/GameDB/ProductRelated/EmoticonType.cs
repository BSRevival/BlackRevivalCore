using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class EmoticonType
{
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

        public EmoticonType()
        {
        }

        public EmoticonType(AcXmlNode rootNode)
        {
            if (!rootNode.GetAttr("Type", ref this._type))
            {
                Log.Error("[DataLoad] EmoticonType - DataLoad Failed !!! -  Type");
            }
            if (!rootNode.GetAttr("Texture", ref this._texture))
            {
                Log.Error("[DataLoad] EmoticonType - DataLoad Failed !!! -  Texture");
            }
        }

        private string _type = string.Empty;

        private string _texture = string.Empty;
}