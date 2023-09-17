using BlackRevival.Common.GameDB.Sns;
using Serilog;

namespace BlackRevival.Common.GameDB;

public class SnsDB
{
    public static SnsDB Instance { get; set; }
    public SnsDB()
    {
        this.snsLinks = new List<SnsLink>();
        Instance = this;
    }

    public SnsDB(SnsDB.Model data)
    {
        this.snsLinks = data.snsLinks;
        Instance = this;
    }

    public string FindLink(string platform, string language)
    {
        List<SnsLink> list = this.snsLinks.FindAll((SnsLink x) => x.platform.Equals(platform));
        if (list == null || list.Count <= 0)
        {
            Log.Error("[SnsDB.FindLink] platform is not exist");
            return string.Empty;
        }
        SnsLink snsLink = list.Find((SnsLink x) => x.language.Equals(language));
        if (snsLink != null)
        {
            return snsLink.link;
        }
        return this.GetDefualtLink(platform);
    }

    public string GetDefualtLink(string platform)
    {
        List<SnsLink> list = this.snsLinks.FindAll((SnsLink x) => x.platform.Equals(platform));
        if (list == null || list.Count <= 0)
        {
            Log.Error("[SnsDB.GetDefualtLink] platform is not exist");
            return string.Empty;
        }
        SnsLink snsLink = list.Find((SnsLink x) => x.language.Equals("En"));
        if (snsLink != null)
        {
            return snsLink.link;
        }
        return string.Empty;
    }

    public List<SnsLink> snsLinks;

    public class Model
    {
        public List<SnsLink> snsLinks;
    }
}