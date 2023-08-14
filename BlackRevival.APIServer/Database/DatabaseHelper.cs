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
    
    //Set user active character
public async Task SetUserActiveCharacter(long num, long characterNum)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        user.ActiveCharacterNum = characterNum;
        await _context.SaveChangesAsync();
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
    
    //Update nickname for Usernum
    public async Task UpdateNickname(long num, string nickname)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        user.Nickname = nickname;
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
  
    
}