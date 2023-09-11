using BlackRevival.Common.Model.Labyrinth;

namespace BlackRevival.Common.Responses;

public class LabyrinthResult
{
    
    public long startDtm { get; set; }

    public string roomKey { get; set; }

    public LabyrinthData data { get; set; }
}