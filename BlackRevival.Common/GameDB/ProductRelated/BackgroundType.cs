using BlackRevival.Common.Enums;
using BlackRevival.Common.Util;
using Serilog;

namespace BlackRevival.Common.GameDB.ProductRelated;

    public class BackgroundType
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

        public bool p_hasFurniture
        {
            get
            {
                return this._hasFurniture;
            }
        }

        public AcE_BackgroundAppearanceType p_appearanceType
        {
            get
            {
                return this._appearanceType;
            }
        }

        public BackgroundType()
        {
        }

        public BackgroundType(AcXmlNode rootNode)
        {
            if (!rootNode.GetAttr("BackgroundType", ref this._type))
            {
                Log.Error("[DataLoad] BackgroundType - DataLoad Failed !!! -  BackgroundType");
            }
            if (!rootNode.GetAttr("Texture", ref this._texture))
            {
                Log.Error("[DataLoad] BackgroundType - DataLoad Failed !!! -  Texture");
            }
            if (!rootNode.GetAttr("HasFurniture", ref this._hasFurniture))
            {
                Log.Error("[DataLoad] BackgroundType - DataLoad Failed !!! -  HasFurniture");
            }
            if (!rootNode.GetAttr<AcE_BackgroundAppearanceType>("AppearanceType", ref this._appearanceType))
            {
                this._appearanceType = AcE_BackgroundAppearanceType.ANY_SHOW;
            }
        }

        private string _type = string.Empty;

        private string _texture = string.Empty;

        private bool _hasFurniture;

        private AcE_BackgroundAppearanceType _appearanceType;
}