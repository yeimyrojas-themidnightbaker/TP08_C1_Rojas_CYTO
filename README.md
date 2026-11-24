# CYTØ — Unity Project

CYTØ is a 2D action platformer set inside an infected wound. You play as a macrophage, the immune system's first line of defense. Leave the capillary, cross the collagen network, engulf *Staphylococcus aureus*, and carry an antigen to a helper T cell so it opens the way to the biofilm at the heart of the infection. The biology lives in the setting, the abilities, the pickables, the enemies, and the Immune Atlas.

> The repository and project are named `TP08\_C1\_Rojas\_CYTO` because GitHub does not accept the character Ø.

## Features

### Core Gameplay

* The macrophage moves left and right with A / D and jumps with Space. It has a **double jump**, and the Calcium Pulse power-up grants a **triple jump** (keys and values configurable in `PlayerDataSo`).
* **Whip attack** with J or left click, in three directions: side, up (W + J), and down (S + J).
* **Reactive oxygen shot** with K, and **Respiratory Burst** with W + K, an area attack around the player. Both use ATP.
* **ATP orb** — the energy resource. It starts empty and fills when the whip hits or kills bacteria.
* **Healing** — hold L while standing on the ground to heal one membrane capsule. It costs a third of the ATP orb, the macrophage can't move while healing, and taking damage cancels it.
* **Health** — membrane capsules shown in the HUD. Taking damage pushes the player back and gives a short invulnerability window.
* **Goal** — find the antigen, bring it to the helper T cell to open the gate, and defeat the biofilm. If you run out of capsules, you lose.
* The camera follows the player with Cinemachine and a Confiner 2D. A minimap (Render Texture + Mask) shows the level.

### Enemies

Every enemy has a health bar, a hit flash, sounds, and a death effect with animation and particles. Defeated bacteria drop amino acids and give score. Values are set per enemy in `EnemyDataSo`.

* **Toxic Cocci** — detects the player in range, inflates as a warning, and shoots toxin projectiles.
* **Staphylococcal Cluster** — patrols. Once it detects the player, it shows a division warning and splits into two smaller clusters.
* **Biofilm (boss)** — a state machine (`enum` + `switch`). First, five matrix shields that crack with each hit must be broken. Then the core is exposed and shoots toxins. The boss has its own music, and its arena closes when the fight starts.
* **Pus puddles** — damage zones that hurt the player while they stay inside.

### Pickables \& Power-ups

Pickables float, play particles and a sound when collected, and use inheritance from an abstract `Pickable` class.

* **Amino Acids** — currency for the shop, saved between runs.
* **Glucose** — heals one capsule.
* **Antigen Fragment** — the key that opens the gate through the helper T cell.
* **IFN-γ** — temporary damage boost.
* **Heat Shock Proteins** — temporary invulnerability.
* **Calcium Pulse** — temporary extra jump.

Active power-ups show their remaining time in the HUD.

### Bone Marrow Shop (extra)

Amino acids are spent in the main menu on permanent upgrades that apply from the next run: +1 max health, more attack damage, more loot per bacteria, and a starting ATP reserve. Purchases are saved in PlayerPrefs.

### Immune Atlas (extra)

Ten entries (six pickables, three enemies, and the helper T cell) with the real biology behind each mechanic. An entry is discovered the first time you collect, defeat, or meet it. A short notice appears in game, and the full entry unlocks in the Atlas panel of the main menu. Undiscovered entries show as silhouettes.

### Online Leaderboard (extra)

PlayFab integration: anonymous login with a saved custom ID, an automatic display name, the best score sent through the Progression API (`BestScore` statistic, Max aggregation), and a global top 10 shown on the Game Over screen. Works in the Web and Windows builds.

### Visual Feedback

* Parallax background in three zones (Capillary, Collagen, Biofilm), with up to four depth layers each and a crossfade between zones.
* Animated player (idle, walk, jump, fall, three attack directions, shoot, burst, heal, hurt, lysis), enemies, boss parts, projectiles, and pickables.
* Animated How To Play slides that keep playing while the game is paused.

### Scenes \& Menus

* **Splash** screen (Player Settings).
* **Main Menu**, with Play, Settings, How To Play, Credits, Shop, Atlas, and Exit (Exit is hidden in the Web build). Panels switch with a fade.
* **How To Play** — six animated slides, reused in the Main Menu and in the Pause Menu.
* **Pause Menu**, opened with Esc, with Continue, Retry, How To Play, Settings, and Main Menu.
* **Settings**, with volume sliders, available in the Main Menu and in the Pause Menu.
* **Game Over**, with a different background for victory and defeat, the score breakdown (time bonus, capsule bonus), the record, the leaderboard, and Retry or Main Menu.

### Audio

* Music for the menu, gameplay, the boss fight, victory, and defeat.
* Sounds for every player action (steps, jump, landing, attacks, shot, burst, heal, damage, death), enemies (hit, death, division, toxins), pickables, the gate, the boss shields, and UI buttons.
* A shared AudioMixer with Master, Music, SFX, and UI groups. Volumes are set from Settings and persist between sessions.

## Architecture \& Code Quality

ScriptableObjects separate data from scene logic, split by role:

* **Configuration:** `PlayerDataSo`, `EnemyDataSo`, `PickableDataSo`, `LevelDataSo`, `GameDataSo`, `UIDataSo`, `ShopItemSo`, `AtlasEntrySo`, `ParallaxLayerSo`.
* **Runtime state:** `RunProgressSo` (score and amino acids of the current run, reset every run) and `GameResultsSo` (result and bonuses, read by the Game Over scene).
* **Persistence:** `SaveDataSo` — best score, best time, amino acids, shop upgrades, and Atlas discoveries in PlayerPrefs (one key per upgrade or entry).
* **Services and channels:** `PlayFabSo` (login, score, leaderboard) and `SfxEventSo`, an event channel that lets any object request a sound through the mixer.

Other patterns:

* **Observer pattern** with C# events for health, ATP, score, pause, enemy health, gate, boss state, purchases, and discoveries. Every `+=` has a matching `-=`.
* **Single source of truth for pause:** `GameManager` owns the pause state and `Time.timeScale`. Menus request the change and react to `OnPauseChanged`.
* **State machine** for the biofilm boss (`enum` + `switch`).
* **Inheritance** for pickables (abstract `Pickable` with one overridden effect per pickable).
* **Composition** for death effects: each enemy's death VFX is a prefab assigned in its `EnemyDataSo`.
* **Marker components** (`PlayerMarker`, `EnemyMarker`) instead of string tags.
* **Animator state hashes** in `AnimatorStates` and scene names in `SceneNames`, both as constants.
* **Data-driven UI:** shop cards and Atlas cards are instantiated from a list of ScriptableObjects.
* **Guard flags** (`gameEnded`, `isPicked`, `isDead`, `hasStarted`) make sure each event happens only once.
* The final score is saved and sent to PlayFab after the end delay, so the points from the last enemy are always included. The Game Over leaderboard waits until PlayFab confirms the submitted score before loading, so a new record shows up right away.

## Controls

|Action|Keys|
|-|-|
|Move|A / D|
|Jump|Space (press again in the air to double jump)|
|Whip attack|J / Left click|
|Attack up|W + J|
|Attack down|S + J|
|Shoot reactive oxygen|K|
|Respiratory Burst|W + K|
|Heal|Hold L|
|Pause|Esc|

## Assignment → CYTØ

|Assignment requirement|In CYTØ|
|-|-|
|Damage the enemies|Whip attack, reactive oxygen shot, Respiratory Burst|
|Health bar|Membrane capsules|
|Heal|Hold L (uses ATP), Glucose|
|Pickable: Heal|Glucose|
|Pickable: Damage|IFN-γ|
|Pickable: Invulnerability|Heat Shock Proteins|
|Pickable: Reward (coins)|Amino Acids|
|Pickable: Key (optional)|Antigen Fragment|
|Extra: Double Jump|Base double jump|
|Extra: Triple Jump through a Power-up|Calcium Pulse|
|Extra: Shop|Bone Marrow Shop|
|Extra: PlayFab API|Online leaderboard|
|Death feedback (particles + animation)|Death VFX prefabs with animation and particles|
|Data in ScriptableObjects|`…DataSo` assets|
|Save data in PlayerPrefs|`SaveDataSo`|
|Audio Mixer (Master, Music, FX, UI)|Shared AudioMixer + Settings sliders|

## Credits

* Game Dev / Game Designer — Yeimy Rojas.
* Artist / Animator — Aurora Salazar.
* Music and sounds — procedurally generated with the assistance of Claude (AI) and selected by Yeimy Rojas.

## Notes

During the development of this project, artificial intelligence tools were used as support for resolving questions, understanding concepts, and reviewing code. AI was used as a tutor: it explained programming structures, possible solutions, and in some new topics (such as PlayFab) it guided the syntax. The code was written by the author, step by step, based on her own understanding and adapted to the needs of the project.

Link itch.io: https://yeimy-rojas-midnightbaker.itch.io/cyto



Contact:
Yeimy Rojas — The Midnight Baker.
https://www.artstation.com/yeimy24401
yeimy.rojas.24401@gmail.com
www.linkedin.com/in/yeimy-alexandra-rojas-castellanos-midnightbaker
https://orcid.org/0009-0000-7481-0223

