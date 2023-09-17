namespace BlackRevival.Common.GameDB;

public class ConstantsDB
{
    public static ConstantsDB Instance { get; set; }
    public ConstantsDB()
    {
        Instance = this;
    }

    public ConstantsDB(ConstantsDB data)
    {
        this.FREE_BP_ROULETTE_HOURS = data.FREE_BP_ROULETTE_HOURS;
        Instance = this;
    }

    public int FREE_BP_ROULETTE_HOURS { get; set; }
}