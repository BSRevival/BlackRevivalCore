using BlackRevival.APIServer.Database.MiniLeague;
using Microsoft.EntityFrameworkCore;

namespace BlackRevival.APIServer.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserAsset> UserAssets { get; set; }
    public DbSet<Character> Characters { get; set; }
    
    public DbSet<OwnedSkin> OwnedSkins { get; set; }
    
    public DbSet<QuestProgress> QuestProgresses { get; set; }
    
    public DbSet<InventoryGoods> InventoryGoods { get; set; }
    
    public DbSet<MailEntry> MailEntries { get; set; }
    public DbSet<MailEntryAttachment> MailEntryAttachments { get; set; }

    public DbSet<MiniLeague.MiniLeague> MiniLeagues { get; set; }
    public DbSet<MiniLeagueGroup> MiniLeagueGroups { get; set; }
    public DbSet<MiniLeagueStatus> MiniLeagueStatuses { get; set; }
    public DbSet<MiniLeagueUser> MiniLeagueUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=blackrevival;Uid=root;";
        ServerVersion version = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, version);
    }


}