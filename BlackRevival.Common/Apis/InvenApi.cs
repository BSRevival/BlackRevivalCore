using BlackRevival.Common.Model;

namespace BlackRevival.Common.Apis;

public class InvenApi
{
    public class LabInfo
    {
        public LabGoods labInfo { get; set; }
        public LabProduction labProductionInfo { get; set; }
    }
    
    public class LabResult
    {
        public List<LabGoods> labList { get; set; }
        public List<LabProduction> labProductList { get; set; }
    }
}