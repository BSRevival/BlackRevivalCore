using System.Text.Json.Nodes;

namespace BlackRevival.APIServer.Classes;

public class WebResponseHeader
{
    public int Cod { get; set; }
    public string Msg { get; set; }
    public object Rst { get; set; }
    public int Eac { get; set; }

}