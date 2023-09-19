
# Black Revival
[![AGPL License](http://img.shields.io/badge/license-AGPL-brightgreen.svg)](https://opensource.org/licenses/AGPL-3.0)

[![Discord Chat](https://dcbadge.vercel.app/api/server/XEbTFqB)](https://discord.gg/XEbTFqB)
--------------

# Black Survival Server Emulation Suite #

This server software to revive a now defunct game, that was taken offline due to the niche popularity of the game. 

We are striving to bring back this game for those people who loved it. 

This is a rewrite in ASP.NET Core and .NET 7 using modern programming techniques and fixing the bad programming of the original project.

# Setup Instructions #

If you're not familiar with github, you'll want to download every files listed in the repository
Simply press Download ZIP
![there](https://arrcival.s-ul.eu/13oBzVUQ)

### Install Guide with JetBrains
1. Download and Install GitHub Desktop and Clone the [repo](https://github.com/BSRevival/BlackRevivalCore) (code drop down -> open with GitHub Desktop)
2. [Download](https://www.jetbrains.com/rider/) JetBrains Rider
3. [Download](https://mariadb.org/download/) and Install MariaDB
4. Open BlackRevivalV2.sln with Rider
5. Install https://plugins.jetbrains.com/plugin/18147-entity-framework-core-ui to Rider
6. Adjust config files (appSettings.development.json, appSettings.json), BlackRevival.APIServer/Context/MyDbContext.cs, BlackRevival.APIServer/DataBase/AppDbContext.cs to match your MariaDB set up.
7. Make sure MariaDB is running, in Rider right click BlackRevival.APIServer -> Tools -> Entity Framework Core -> Update Database
8. Download the Patch files from [here](https://mega.nz/file/kNZUmY6Y#x_tq2oACNSyL_uArldZ74SWd4gGPq5hh8hXlFBcZxck)
9. Move the patch files to BlackRevivalCore/BlackRevival.APIServer/Data/PatchData
10. Download the game through Steam
11. Move the files from BlackRevivalCore/ClientFiles to your games root directory, overwriting anything if it asks.
12. Return to Rider and at the top of the screen click the green play putton next to BlackRevival.APIServer
13. Start BlackSurvival.exe and authorize the Discord bot

### Install Guide with Visual Studio Community
1. Download and Install GitHub Desktop and Clone the [repo](https://github.com/BSRevival/BlackRevivalCore) (code drop down -> open with GitHub Desktop)
2. [Download](https://visualstudio.microsoft.com/) Visual Studio Community
3. When asked what components to install, you'll want to install the .NET desktop development tool.
![this](https://arrcival.s-ul.eu/aoqrQWuU)
4. [Download](https://mariadb.org/download/) and Install MariaDB
5. Open BlackRevivalV2.sln with Visual Studio
6. Adjust config files (appSettings.development.json, appSettings.json), BlackRevival.APIServer/Context/MyDbContext.cs, BlackRevival.APIServer/DataBase/AppDbContext.cs to match your MariaDB set up.
7. Make sure MariaDB is running, in VS click on "Tools -> CommandLine -> Developer Powershell" and paste the following code in the Powershell console: "dotnet ef database update"
8. Download the Patch files from [here](https://mega.nz/file/kNZUmY6Y#x_tq2oACNSyL_uArldZ74SWd4gGPq5hh8hXlFBcZxck)
9. Move the patch files to BlackRevivalCore/BlackRevival.APIServer/Data/PatchData
10. Download the game through Steam
11. Move the files from BlackRevivalCore/ClientFiles to your games root directory, overwriting anything if it asks.
12. Choose the "http" option in the dropdown and then press the green triangle. Press "BlackRevivalServer" with the green triangle if you have an old version of Visual Studio.
![this](https://arrcival.s-ul.eu/wfQpWZOc)
13. Start BlackSurvival.exe and authorize the Discord bot
It should automatically connect to your server. 


# Current Progress #

The current progress of the server is farly incomplete in its implementation. 

It needs quite a bit of work to get to a playable state, Currently all WebAPI data is statically served. 

There is no database. 

The WebSocket servers for the actual game server are mostly static as well. 