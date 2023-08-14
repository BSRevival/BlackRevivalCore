using Microsoft.EntityFrameworkCore;

namespace BlackRevival.APIServer.Database;

public class DatabaseHelper 
{
    private readonly AppDbContext _context;
    
    public DatabaseHelper(AppDbContext context)
    {
        _context = context;
    }
    //Create New User
    public async Task<User> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    //Create New UserAsset
    public async Task<UserAsset> CreateUserAsset(UserAsset userAsset)
    {
        await _context.UserAssets.AddAsync(userAsset);
        await _context.SaveChangesAsync();
        return userAsset;
    }
    
    //Create New Character
    public async Task<Character> CreateCharacter(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();
        return character;
    }
    
    //Set Active Character
    public async Task SetActiveCharacter(long num, long characterNum)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        user.ActiveCharacterNum = characterNum;
        await _context.SaveChangesAsync();
    }
    
    //Get Active Character
    public async Task<Character> GetActiveCharacter(long num)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        return await _context.Characters.FirstOrDefaultAsync(c => c.CharacterNum == user.ActiveCharacterNum);
    }
    
    //Update nickname for Usernum
    public async Task UpdateNickname(long num, string nickname)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        user.Nickname = nickname;
        
        //Update all characters owned by this user their UserNickname
        var characters = await _context.Characters.Where(c => c.UserNum == num).ToListAsync();
        foreach (var character in characters)
        {
            character.UserNickname = nickname;
        }
        
        await _context.SaveChangesAsync();
    }
    
    public async Task<User> GetUserByNickname(string nickname)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
    }
    
    public async Task<User> GetUserByNum(long num)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
    }
    
    //nickname exists
    public async Task<bool> IsNicknameExists(string nickname)
    {
        return await _context.Users.AnyAsync(u => u.Nickname == nickname);
    }
    
    //user exists
    public async Task<bool> IsUserExists(long num)
    {
        return await _context.Users.AnyAsync(u => u.UserNum == num);
    }
    
    //Find character by user num
    public async Task<Character> GetCharacterByUserNum(long num)
    {
        return await _context.Characters.FirstOrDefaultAsync(c => c.UserNum == num);
    }
    
    //Find userasset by user num
    public async Task<UserAsset> GetUserAssetByUserNum(long num)
    {
        return await _context.UserAssets.FirstOrDefaultAsync(u => u.UserNum == num);
    }
  
    //Get owned skin by usernum
    public async Task<List<OwnedSkin>> GetOwnedSkins(long num)
    {
        return await _context.OwnedSkins.Where(o => o.UserNum == num).ToListAsync();
    }
    
    //Get owned skin by usernum and character class
    public async Task<List<OwnedSkin>> GetOwnedSkinsByCharacterClass(long num, int characterClass)
    {
        return await _context.OwnedSkins.Where(o => o.UserNum == num && o.CharacterClass == characterClass).ToListAsync();
    }
    
    //create owned skin
    public async Task<OwnedSkin> CreateOwnedSkin(OwnedSkin ownedSkin)
    {
        await _context.OwnedSkins.AddAsync(ownedSkin);
        await _context.SaveChangesAsync();
        return ownedSkin;
    }
    
    //update owned skin
    public async Task UpdateOwnedSkin(OwnedSkin ownedSkin)
    {
        _context.OwnedSkins.Update(ownedSkin);
        await _context.SaveChangesAsync();
    }
    
    //Get all owned characters
    public async Task<List<Character>> GetOwnedCharacters(long num)
    {
        return await _context.Characters.Where(c => c.UserNum == num).ToListAsync();
    }
    
}