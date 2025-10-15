<table>
  <tr>
    <td align="left" width="50%">
      <img width="100%" alt="gif1" src="https://github.com/Koala-Terbang/Fail_Safe/blob/main/Assets/Assets/gif/FSgif.gif">
    </td>
    <td align="right" width="50%">
      <img width="100%" alt="gif2" src="https://github.com/Koala-Terbang/Fail_Safe/blob/main/Assets/Assets/gif/FSgif1.gif">
    </td>
  </tr>
</table>

##  Scripts and Features

This game have a lot of mechanics from each minigame thanks to all the various script implemented in the game.<br>

Here are some of the main mechanic in this game
|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `CameraManager.cs` | Responsible for switching camera |
| `SortfileMinigame.cs` | Responsible for spawner for each file type |
| `SwipingMinigame.cs`  | Responsible for news minigame |
| `CodingMinigame.cs`  | Responsible for accepting input and matching it to the correct code |
| `HackerManager.cs`  | Responsible for detecting the wire to be cut |
| `IPManager.cs`  | Responsible for dividing safe and threat IP address |
| `etc`  | |

<br>

## About
A casual party game where players start as an IT intern, completing minigames like sorting files and choosing strong passwords. As the story progresses, the challenges grow, teaching digital safety and SDG Goal 4: Quality Education in an engaging, easy-to-understand way.
<br>

## Developer & Contributions
- Bryant Chandra (Game Programmer)
- Raditya Daryl Raspati (Game Designer)
- Oscar Bagus Putra Penn Klopper (2D Game Artist)
<br>

```
├── FailSafe                          # Contain everything needed for Please Survive to works.
   ├── .vscode                        # Contains configuration files for Visual Studio Code (VSCode) when it's used as the code editor for the project.
      ├── extensions.json             # Contains settings and configurations for debugging, code formatting, and IntelliSense. This folder is related to Visual Studio Code integration.
      ├── launch.json                 # Contains the configuration necessary to start debugging Unity C# scripts within VSCode.                     
      ├── setting.json                # Contains workspace-specific settings for VSCode that are applied when working within the Unity project.
   ├── Assets                         # Contains every assets that have been worked with unity to create the game like the scripts and the art.
      ├── Assets                      # Contains all the game art like the sprites, background, even the character.
      ├── Audio                       # Contains every sound used for the game like music and sound effects.
      ├── Scenes                      # Contains all scenes that exist in the game for it to interconnected with each other.
      ├── Script                      # Contains all scripts needed to make the gane get goings like PlayerMovement scripts.
      ├── TextMesh Pro                # Contains TextMesh Pro plugin.
   ├── Packages                       # Contains game packages that responsible for managing external libraries and packages used in your project.
      ├── Manifest.json               # Contains the lists of all the packages that your project depends on and their versions.
      ├── Packages-lock.json          # Contains packages that ensuring your project always uses the same versions of all dependencies and their sub-dependencies.
   ├── Project Settings               # Contains the configuration of your game to control the quality settings, icon, or even the cursor settings
├── README.md                         # The description of Please Survive file from About til the developers and the contribution for this game.
```

## Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| Left Click        | UI Interact       |

<br>
