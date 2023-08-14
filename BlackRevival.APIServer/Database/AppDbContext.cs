using Microsoft.EntityFrameworkCore;

namespace BlackRevival.APIServer.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserAsset> UserAssets { get; set; }
    public DbSet<Character> Characters { get; set; }
    
    public DbSet<OwnedSkin> OwnedSkins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=blackrevival;Uid=root;Pwd=johnsond;";
        ServerVersion version = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, version);
    }


}