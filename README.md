
# Black Revival
[![AGPL License](http://img.shields.io/badge/license-AGPL-brightgreen.svg)](https://opensource.org/licenses/AGPL-3.0)

[![Discord Chat](https://dcbadge.vercel.app/api/server/XEbTFqB)](https://discord.gg/XEbTFqB)
--------------

# Black Survival Server Emulation Suite #

This server software to revive a now defunct game, that was taken offline due to the niche popularity of the game. 

We are striving to bring back this game for those people who loved it. 

This is a rewrite in asp.net core and .net 7 using modern programming techniques and fixing the bad programming of the original project.

# Setup Instructions #

If you're not familiar with github, you'll want to download every files listed in the repository
Simply press Download ZIP
![there](https://arrcival.s-ul.eu/13oBzVUQ)

## Client side ##

1. Download the game through Steam
2. Locate where the game is installed. It's usually in the Steam folder, then you can find the game in \steamapps\common\Black Survival
3. Go to the ClientFiles Folder in the repo.
4. Copy the files and folders to your \steamapps\common\Black Survival folder overwriting anything if it asks
5. Run the game.


## Server side ##

1. Download the Patch server files from [this link](https://mega.nz/file/kNZUmY6Y#x_tq2oACNSyL_uArldZ74SWd4gGPq5hh8hXlFBcZxck)
2. You'll want to download [Visual Studio Community](https://visualstudio.microsoft.com/) and install it
3. When asked what components to install, you'll want to install the .NET desktop development tool.
![this](https://arrcival.s-ul.eu/aoqrQWuU)
4. Once the server files downloaded and Visual Studio installed, extract the folder to "Repo"\BlackRevival.APIServer\Data\PatchData where bundlelist.txt resides
Repo being the zip you downloaded earlier to get the patched files for the client.
5. Open visual studio.
6. Open the .sln files from the same folder from before; this is actually the server source code and what's visible from Github
7. Build the server then run from visual studio. You should only have to press "BlackRevivalServer" with the green triangle.
![this](https://arrcival.s-ul.eu/wfQpWZOc)
8. Then run the game.

It should automatically connect to your server. 

# Current Progress #

The current progress of the server is farily incomplete in its implementation. 

It needs quite a bit of work to get to a playable state, Currently all WebAPI data is statically served. 

There is no database. 

The WebSocket servers for the actual game server are mostly static as well. 