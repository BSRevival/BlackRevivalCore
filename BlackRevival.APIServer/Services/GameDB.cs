using System.Text;
using BlackRevival.APIServer.Classes;

namespace BlackRevival.APIServer.Services;

public class GameDB : IGameDatabase
{
    private string GetCRC32HashCode(string json)
    {
        string empty = string.Empty;
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        Crc32 crc = new Crc32();
        crc.Update(bytes, 0, json.Length);
        return crc.Value.ToString();
    }
}