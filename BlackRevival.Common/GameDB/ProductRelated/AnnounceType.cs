using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

public class AnnounceType
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

        public AnnounceType()
        {
        }

        public AnnounceType(AcXmlNode rootNode)
        {
            if (!rootNode.GetAttr("Type", ref this._type))
            {
                Log.Error("[DataLoad] AnnounceType - DataLoad Failed !!! -  Type");
            }
            if (!rootNode.GetAttr("Texture", ref this._texture))
            {
                Log.Error("[DataLoad] AnnounceType - DataLoad Failed !!! -  Texture");
            }
        }

        public AnnounceType(string type, string texture)
        {
            this._type = type;
            this._texture = texture;
        }

        protected string _type = string.Empty;

        protected string _texture = string.Empty;
}