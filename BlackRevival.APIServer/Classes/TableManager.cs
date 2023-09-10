﻿using System.Text.Json;
using BlackRevival.Common.GameDB;
using Serilog;

namespace BlackRevival.APIServer.Classes;

public static class TableManager
{
    public static void Init()
    {
        string json = System.IO.File.ReadAllText("Data/GameDB/character.json");
        //Serailize json to CharacterDB
        Log.Information("Loading character.json...");
        characterDb = new CharacterDB(JsonSerializer.Deserialize<CharacterDB.Model>(json));
        
        json = System.IO.File.ReadAllText("Data/GameDB/signature.json");
        //Serailize json to SignatureDB
        Log.Information("Loading signature.json...");
        signatureDb = new SignatureDB(JsonSerializer.Deserialize<SignatureDB.Model>(json));
        
        json = System.IO.File.ReadAllText("Data/GameDB/skins.json");
        //Serailize json to SkinsDB
        Log.Information("Loading skins.json...");
        skinsDb = new SkinsDB(JsonSerializer.Deserialize<SkinsDB.Model>(json));

        
        Log.Information("TableManager initialized.");

    }
    
    

    public static CharacterDB characterDb;
    public static SignatureDB signatureDb;
    public static SkinsDB skinsDb;


}
