using BlackRevival.APIServer.Classes;
using BlackRevival.Common.Model;
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
    public async Task<List<CharacterSkin>> GetOwnedCharSkins(long num)
    {
        var SkinList = new List<CharacterSkin>();
        var list = await _context.OwnedSkins.Where(o => o.UserNum == num).ToListAsync();
        foreach(var skin in list)
        {
            var skinData = new CharacterSkin
            {
                userNum = skin.UserNum,
                characterClass = skin.CharacterClass,
                characterSkinType = skin.CharacterSkinType,
                owned = skin.Owned,
                activeLive2D = skin.ActiveLive2D,
                skinEnableType = skin.SkinEnableType,
            };

            SkinList.Add(skinData);
        }

        return SkinList;


    }
    
    
    //Get owned skin by usernum and character class
    public async Task<List<CharacterSkin>> GetOwnedSkinsByCharacterClass(long num, int characterClass)
    {
        var SkinList = new List<CharacterSkin>();
        var list = await _context.OwnedSkins.Where(o => o.UserNum == num && o.CharacterClass == characterClass).ToListAsync();

        foreach(var skin in list)
        {
            var skinData = new CharacterSkin
            {
                userNum = skin.UserNum,
                characterClass = skin.CharacterClass,
                characterSkinType = skin.CharacterSkinType,
                owned = skin.Owned,
                activeLive2D = skin.ActiveLive2D,
                skinEnableType = skin.SkinEnableType,
            };

            SkinList.Add(skinData);
        }

        return SkinList ;
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
    //Get Character by usernum and Characternum
    public async Task<Character> GetCharacterByUserNumAndCharacterNum(long num, long characterNum)
    {
        return await _context.Characters.FirstOrDefaultAsync(c => c.UserNum == num && c.CharacterClass == characterNum);
    }
    
    //Set Active SKin
    public async Task SetActiveSkin(long num, int skinType)
    {
        var user = _context.Users.FirstOrDefaultAsync(u => u.UserNum == num).Result;
        //Get character by skinType CharacterSkinType
        var skin = TableManager.skinsDb.GetSkinById(skinType);
        
        
        var activeCharacter = _context.Characters.FirstOrDefaultAsync(c => c.CharacterClass == skin.characterClass && c.UserNum == user.UserNum).Result;
       
        
        activeCharacter.ActiveCharacterSkinType = skinType;
        
        user.ActiveCharacterNum = activeCharacter.CharacterNum;
        //Update the active character now
        await _context.SaveChangesAsync();
    }
    
    //Get active character
    public async Task<Common.Model.Character> GetActiveCharacterGameModel(long num)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserNum == num);
        var activeCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.CharacterNum == user.ActiveCharacterNum);

        var activeChar = new Common.Model.Character
        {
            characterNum = activeCharacter.CharacterNum,
            userNum = activeCharacter.UserNum ?? default(long),
            userNickname = activeCharacter.UserNickname,
            characterClass = activeCharacter.CharacterClass,
            characterGrade = activeCharacter.CharacterGrade,
            activeCharacterSkinType = activeCharacter.ActiveCharacterSkinType,
            activeLive2D = activeCharacter.ActiveLive2D,
            enhanceExp = activeCharacter.EnhanceExp,
            characterPurchaseType = activeCharacter.CharacterPurchaseType,
            rankPlayCount = activeCharacter.RankPlayCount,
            rankWinCount = activeCharacter.RankWinCount,
            normalPlayCount = activeCharacter.NormalPlayCount,
            normalWinCount = activeCharacter.NormalWinCount,
            teamNumber = activeCharacter.TeamNumber,
            potentialSkillId = activeCharacter.PotentialSkillId,
            pmn = activeCharacter.Pmn,
            pfr = activeCharacter.Pfr,
            psd = activeCharacter.Psd,
            host = activeCharacter.Host,
            characterStatus = activeCharacter.CharacterStatus,
            toNormalRemainSeconds = activeCharacter.ToNormalRemainSeconds

        };
        return activeChar;
    }
    
    //Get all inventory goods
    public async Task<List<InventoryGoods>> GetInventoryGoods(long num)
    {
        return await _context.InventoryGoods.Where(i => i.UserNum == num).ToListAsync();
    }
    
    //Add new inventory goods
    public async Task AddInventoryGoods(InvenGoods inventoryGoods)
    {
        var goods = new InventoryGoods
        {
            Text = inventoryGoods.c,
            Amount = inventoryGoods.a,
            UserNum = inventoryGoods.userNum,
            IsActivated = inventoryGoods.isActivated,
            Activated = inventoryGoods.activated,
            ExpireDtm = inventoryGoods.expireDtm
        };
        
        await _context.InventoryGoods.AddAsync(goods);
        await _context.SaveChangesAsync();
    }
    
    //Get all mail entries and convert to mail model
    public async Task<List<Mail>> GetMailEntries(long num)
    {
        var mailList = new List<Mail>();
        var list = await _context.MailEntries.Where(m => m.UserNum == num).ToListAsync();
        foreach(var mail in list)
        {
            var mailData = new Mail
            {
                mailNum = mail.mailNum,
                type = mail.type,
                title = mail.title,
                content = mail.content,
                status = mail.status,
                senderNum = mail.senderNum,
                senderNickname = mail.senderNickname,
                eventNum = mail.eventNum,
                createDtm = mail.createDtm,
                readDtm = mail.readDtm,
                expireDtm = mail.expireDtm,
                publishId = mail.publishId,
                subTitle = mail.subTitle,
                webLink = mail.webLink,
                attachment = new MailAttachment
                {
                    goods = mail.attachment.goods,
                    mailAttachmentNum = mail.attachment.mailAttachmentNum,
                    mailNum = mail.attachment.mailNum
                }
            };

            mailList.Add(mailData);
        }

        return mailList;
    }
    
    //Delete mail entry by mail num
    public async Task DeleteMailEntry(long num, long mailNum)
    {
        var mail = await _context.MailEntries.FirstOrDefaultAsync(m => m.UserNum == num && m.mailNum == mailNum);
        _context.MailEntries.Remove(mail);
        await _context.SaveChangesAsync();
    }
    
    //Get single mail entry by mail num and convert to mail model
    public async Task<Mail> GetMailByMailID(long num, long mailNum)
    {
        var mail = await _context.MailEntries.FirstOrDefaultAsync(m => m.UserNum == num && m.mailNum == mailNum);
        var mailData = new Mail
        {
            mailNum = mail.mailNum,
            type = mail.type,
            title = mail.title,
            content = mail.content,
            status = mail.status,
            senderNum = mail.senderNum,
            senderNickname = mail.senderNickname,
            eventNum = mail.eventNum,
            createDtm = mail.createDtm,
            readDtm = mail.readDtm,
            expireDtm = mail.expireDtm,
            publishId = mail.publishId,
            subTitle = mail.subTitle,
            webLink = mail.webLink,
            attachment = new MailAttachment
            {
                goods = mail.attachment.goods,
                mailAttachmentNum = mail.attachment.mailAttachmentNum,
                mailNum = mail.attachment.mailNum
            }
        };

        return mailData;
    }


    public async Task UpdateUserAsset(long num, UserAsset asset)
    {
        //Update user asset
        _context.UserAssets.Update(asset);
        await _context.SaveChangesAsync();
    }
    
    
    public async Task AddInventoryItem<T>(T TheItem, long userNum, Goods invenGoods,bool activated = false)
    {

        switch (invenGoods._goodsType)
        {
            case GoodsType.CHARACTER:
                break;
            case GoodsType.LAB_PRODUCT:
            case GoodsType.MATCHING_CARD:
            {
                var goods = new InventoryGoods
                {
                    Text = invenGoods.goodsCode,
                    Amount = invenGoods.amount,
                    UserNum = userNum,
                    IsActivated = activated,
                    Activated = activated,
                    ExpireDtm = DateTime.Now
                };
        
                await _context.InventoryGoods.AddAsync(goods);
                await _context.SaveChangesAsync();
                //Now create the labGoodsEntry
                
                var labGoods = new LabGoodsEntry
                {
                    userNum = userNum,
                    labType = LabType.NORMAL,
                    bgSubType = invenGoods.subType,
                    isActivated = activated,
                    components = "",
                    invenGoodsList = new List<InventoryGoods>()
                };
                labGoods.invenGoodsList.Add(goods);
                await _context.LabGoodsEntries.AddAsync(labGoods);
                await _context.SaveChangesAsync();
            }
                break;
            case GoodsType.TICKET:
            {
                var goods = new InventoryGoods
                {
                    Text = invenGoods.goodsCode,
                    Amount = invenGoods.amount,
                    UserNum = userNum,
                    IsActivated = false,
                    Activated = false,
                    ExpireDtm = DateTime.Now
                };
        
                await _context.InventoryGoods.AddAsync(goods);
                await _context.SaveChangesAsync();

            }
                break;
        }
        
    }

    
    public async Task<List<LabGoodsEntry>> GetLabGoods(long userNum)
    {
        return await _context.LabGoodsEntries.Where(l => l.userNum == userNum).ToListAsync();
    }
    
    
}