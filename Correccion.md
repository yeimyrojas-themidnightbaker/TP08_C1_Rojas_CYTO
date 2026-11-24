# Corrección, TP08 Platformer 2D

- **Alumno/a:** Rojas
- **Entrega:** `TP08_C1_Rojas_CYTO`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP08:** 10

## 1. Checklist de requisitos

Las líneas que cito en toda la corrección son las de tus archivos con mis comentarios ya insertados.

### General

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| G1 | Repositorio `TP08_C1_Apellido_Titulo` | ✓ | Carpeta `TP08_C1_Rojas_CYTO`, y el remote de `.git/config` apunta a `TP08_C1_Rojas_CYTO` |
| G2 | Proyecto de Unity con el mismo nombre | ✓ | `TP08_C1_Rojas_CYTO.slnx`. El `productName` es `CYTØ` (`ProjectSettings/ProjectSettings.asset:16`) y en el README explicás por qué |
| G3 | Al menos 2 escenas: 1-MainMenu, 2-Gameplay | ✓ | `ProjectSettings/EditorBuildSettings.asset`: índice 0 `MainMenu.unity`, índice 1 `Gameplay.unity`, índice 2 `GameOver.unity` |
| V1 | Publicado en Itch.io y presentable | ✓ | Está publicado en itch.io (revisado el 2026-11-16) |
| V2 | Itch.io jugable en web y descargable para Windows | ✓ | Carga la build web y tiene descarga para Windows |

### Jugador

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| J1 | Se mueve a derecha e izquierda | ✓ | `Assets/Scripts/Player/PlayerMovement.cs:59-68` (input), `:118-128` (`rb.linearVelocity` en `FixedUpdate`) |
| J2 | Salta | ✓ | `PlayerMovement.cs:130-140` (`AddForce` Impulse), con salto variable en `CutJump` |
| J3 | Puede dañar enemigos | ✓ | `PlayerAttack.cs:57-104` (látigo), `PlayerShooter.cs:45-71` (proyectil y burst), `Projectile.cs:27-33` |
| J4 | Barra de vida | ✓ | `PlayerHealth.cs` + `Assets/Scripts/UI/UILife.cs` (cápsulas en el HUD) |
| J5 | Puede curarse | ✓ | `PlayerHealing.cs:29-49` (mantener L, cuesta ATP), `GlucosePickup.cs` |
| J6 | Todas las acciones animadas y con sonido | ✓ | `PlayerAnimation.cs` (Idle, Walk, Jump, Fall, Attack x3, Shoot, Ring, Hurt, Heal, Lysis), `PlayerAudio.cs` (pasos, salto, aterrizaje, ataque, disparo, burst, daño, muerte, curación) |

### Enemigos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| E1 | Dañan al jugador | ✓ | `PlayerHealth.cs:45-62` (contacto con `EnemyMarker`), `ToxicCocci.cs:44-52` (proyectil), `DamageZone.cs` |
| E2 | Barra de vida | ✓ | `UIEnemyHealthBar.cs` en `EnemyCluster.prefab`, `EnemyClusterSmall.prefab`, `EnemyToxicCocci.prefab` y en `Gameplay.unity` (barra del jefe, `BossArenaTrigger.cs:30`) |
| E3 | Feedback visual al morir (partículas + animación) | Parcial | `EnemyHealth.cs:46-49` instancia `DeathVfx`. Los 4 prefabs de muerte de `Assets/Prefabs/VFX/` tienen `Animator` pero ninguno tiene `ParticleSystem`. Tenés la animación y el flash de golpe (`EnemyHitFlash.cs`); te faltan las partículas |
| E4 | Todas las acciones animadas y con sonido | ✓ | `ToxicCocci.cs:37-52` (anticipación, disparo, `SpecialClip`), `ClusterSplit.cs:30-38` (animación y sonido de división), `EnemyAudio.cs` (golpe y muerte), `ShieldAnimation.cs` (grietas) |

### Pickables

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| K1 | Heal | ✓ | `GlucosePickup.cs`, `Assets/Prefabs/Pickables/GlucosePickable.prefab` |
| K2 | Damage (aumenta daño) | ✓ | `PowerUpPickup.cs` + `PlayerPowerUps.cs:27-29`, aplicado en `PlayerAttack.cs:90-93` (solo al látigo, mirá los hallazgos) |
| K3 | Invulnerability por x segundos | ✓ | `PlayerPowerUps.cs:30-31` (`Shield`), `PlayerHealth.cs:66`, con la duración en `PickableDataSo.powerUpDuration` |
| K4 | Reward: monedas para el shop | ✓ | `AminoacidPickable.cs`. Se acumulan en `SaveDataSo.CommitRun` y se gastan en `UIShop` / `SaveDataSo.TryBuy` |

### Sonido

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| S1 | AudioMixer con Master, Music, FX y UI | ✓ | `Assets/Audio/Mixer.mixer` con los grupos Master, Music, FX y UI y los parámetros expuestos `MasterVolume`, `MusicVolume`, `FXVolume`, `UIVolume` |
| S2 | Al menos 3 grupos con sliders en Settings | ✓ | `Assets/Prefabs/UI/SettingsPanel.prefab`: 4 `UISliderVolume` (channel 0 a 3), `AudioDataSo.SetVolumeOf` |
| S3 | Toda acción se refleja en sonido | ✓ | `PlayerAudio.cs`, `EnemyAudio.cs`, `Pickable.cs:27-30`, `GateAudio.cs`, `BtnClickSound.cs`, `UIShop.cs:46-49`, `BackgroundMusicPlayer.cs`, `ResultsSoundPlayer.cs` |

### Datos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| D1 | Configuraciones en ScriptableObject | ✓ | `PlayerDataSo`, `EnemyDataSo`, `PickableDataSo`, `LevelDataSo`, `GameDataSo`, `UIDataSo`, `ProjectileDataSo`, `ShopItemSo` y `AudioDataSo`, con sus `.asset` en `Assets/Data/` |
| D2 | Datos de partida en PlayerPrefs | ✓ | `SaveDataSo.cs:25-54` (BestScore, BestTime, TotalAminoacids), `:74-87` (upgrades), `:106-116` (Atlas), `AudioDataSo.cs:18-26` (volúmenes) |

### Extras (rojo)

| #  | Extra | Estado | Evidencia |
|----|-------|--------|-----------|
| X1 | Doble salto | ✓ | `Assets/Data/Player.asset`: `maxJumps: 2`, `PlayerMovement.cs:132` |
| X2 | Triple salto por power up | ✓ | `PlayerMovement.cs:171-176` + `extraJumps: 1`, pickable `CalciumPickable.prefab` |
| X3 | Tienda con monedas | ✓ | `UIShop.cs`, `UIShopItem.cs`, `SaveDataSo.TryBuy` y 4 `ShopItemSo` en `Assets/Data/Shop/`, aplicados en `PlayerHealth.cs:28-31`, `PlayerAttack.cs:30-33`, `PlayerEnergy.cs:20-23`, `EnemyLoot.cs:14-17` |
| X4 | Integración PlayFab | ✓ | `Assets/Scripts/Data/PlayFabSo.cs` (login, `UpdateStatistics`, `GetLeaderboard`), `UILeaderboard.cs` |
| X5 | Multijugador local | ✗ | No hay segundo jugador en `Gameplay.unity` ni en los scripts |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repo público | ✓ | El repositorio es público (revisado el 2026-11-16) |
| P3 | Nombre del repo | ✓ | `TP08_C1_Rojas_CYTO` |
| P4 | Código en inglés | ✓ | Clases, métodos, campos y enums en inglés en los 88 scripts. Los comentarios en español están permitidos |
| P5 | Un repo por TP, sin branches | ✓ | `git branch -a`: solo `main`. 81 commits desde el 2026-10-25, sin carpetas de otro TP |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Art/Animations/` | `Art/Animation/` | Está en singular, no penaliza |
| `Art/Audio/` | `Assets/Audio/` | El audio está en la raíz de `Assets/` en vez de dentro de `Art/` |
| `Art/Fonts/` | ✓ | |
| `Art/Materials/` | ✗ | Hay un `.mat` y un `.physicsMaterial2D` en `Assets/Settings/` |
| `Art/Sprites/` | ✓ | |
| `Data/` | ✓ | Todos tus `.asset` de SO están acá |
| `Prefabs/` | ✓ | Subcarpetas Audio, Enemies, Pickables, Projectile, UI, VFX |
| `Scenes/` | ✓ | |
| `Scripts/` | ✓ | Organizada por feature (Player, Enemies, UI, Data, etc.) |
| `Plugins/` | No aplica | `PlayFabSDK/` quedó en la raíz de `Assets/`, que es la ubicación por defecto del SDK |

Archivos mal ubicados:

- `Assets/Settings/ROSParticle.mat` tendría que ir en `Assets/Art/Materials/`.
- `Assets/Settings/PlayerNoFriction.physicsMaterial2D` tendría que ir en `Assets/Art/Materials/`.
- `Assets/Audio/` completa tendría que estar en `Assets/Art/Audio/`.

Ruido de repo: `Assets/Resources.meta` está versionado pero la carpeta `Assets/Resources/` no existe. `.gitattributes` no configura Git LFS para binarios. `Assets/Settings/Scenes/URP2DSceneTemplate.unity` es la plantilla de URP.

## 4. Qué le falta

- Agregar un `ParticleSystem` a los prefabs de muerte de `Assets/Prefabs/VFX/` (requisito E3).
- Corregir `UIPauseMenu.cs:50`, que hace `AddListener` en `OnDisable`.
- Evitar que `BiofilmBoss.StartFight` vuelva a `Shielded` si los escudos ya se rompieron.
- Calcular `IsWalking` con la velocidad real, para que no suenen pasos durante la curación.
- Extraer `AnyKeyHeld`/`AnyKeyDown`, que están repetidos en 5 clases.
- Mover los materiales y el audio a `Art/`.

## 5. Hallazgos de código

### Error (0)

### Bug (3)
- `Assets/Scripts/UI/UIPauseMenu.cs:50` En `OnDisable` hacés `btnBackSettings.onClick.AddListener` en vez de `RemoveListener`, y el listener se duplica cada vez que se habilita y deshabilita.
- `Assets/Scripts/Enemies/Boss/BiofilmBoss.cs:90` Si los 5 escudos se rompen antes de entrar al trigger de la arena, `StartFight` vuelve el estado a `Shielded`, deshabilita `coreCollider` y ya no se puede matar al jefe.
- `Assets/Scripts/Player/PlayerAudio.cs:17` Los pasos dependen de `IsWalking`, que solo mira el input. Suenan mientras el jugador se cura quieto o mientras empuja una pared.

### Warning (2)
- `Assets/Scripts/Player/PlayerMovement.cs:31` Comparás un float con `!= 0f` (también en la línea 80).
- `Assets/Scripts/Enemies/TypeOfEnemies/ClusterSplit.cs:40` Hay un `GetComponent<ClusterPatrol>()` sin chequeo sobre un `GameObject` genérico del SO.

### Suggestion (16)
- `Assets/Scripts/Player/PlayerMovement.cs:177` `AnyKeyHeld`/`AnyKeyDown` están duplicados en `PlayerAttack`, `PlayerShooter`, `PlayerHealing` y `GameManager`.
- `Assets/Scripts/Player/PlayerShooter.cs:61` El burst y el proyectil ignoran el boost de daño (IFN), que solo se aplica al látigo.
- `Assets/Scripts/Enemies/Boss/BiofilmBoss.cs:81` Hay null check en `animator` pero no en `animatorBody`.
- `Assets/Scripts/Enemies/Boss/ShieldAnimation.cs:20` Los números mágicos 2 y 1 dependen del `maxHealth` del escudo.
- `Assets/Scripts/Markers/PlayerMarker.cs:5` Quedaron el `Start` y el `Update` vacíos de la plantilla.
- `Assets/Scripts/Level/GateAudio.cs:7` El campo `saveData` no se usa.
- `Assets/Scripts/Level/AntigenGate.cs:63` Texto hardcodeado.
- `Assets/Scripts/Data/SaveDataSo.cs:63` `HasUpgrade` y `HasDiscovered` se pueden reducir a un `return ... == 1;`.
- `Assets/Scripts/Data/GameResultsSo.cs:7` Hay campos sin modificador de acceso explícito.
- `Assets/Scripts/Data/LevelDataSo.cs:8` Hay campos `int` expuestos como `float`.
- `Assets/Scripts/UI/UIAtlas.cs:23` La inicialización del detalle está dentro del `foreach` y el sprite se asigna dos veces en `ShowDetail`.
- `Assets/Scripts/UI/UIGameOverMenu.cs:29` Textos hardcodeados.
- `Assets/Scripts/UI/UILeaderboard.cs:57` `1.5f` es un número mágico.
- `Assets/Scripts/UI/UIPowerUpTimers.cs:19` Hay polling con `SetActive` en cada frame.
- `Assets/Scripts/UI/UIMainMenu.cs:1` `using System` sin usar.
- `Assets/Scripts/UI/UIPauseMenu.cs:1` `using System` sin usar.

## 6. Recomendaciones

1. Agregá un `ParticleSystem` a `VFXToxicDeath`, `VFXRacimoDeath`, `VFXBossCoreDefeated` y `VFXBossShieldDeath` para completar E3.
2. Cambiá `AddListener` por `RemoveListener` en `UIPauseMenu.cs:50`.
3. En `BiofilmBoss`, ignorá el daño a los escudos mientras el estado sea `Waiting`, o pasá directo a `Exposed` en `StartFight` si `shieldsRemaining <= 0`.
4. Calculá `IsWalking` con `rb.linearVelocity.x` y `!playerHealing.IsHealing`.
5. Sacá los helpers de input a una clase estática y eliminá las 5 copias.
6. Tipá `EnemyDataSo.SmallCluster` como `ClusterPatrol` para no depender de `GetComponent`.
7. Mové `ROSParticle.mat`, `PlayerNoFriction.physicsMaterial2D` y `Assets/Audio/` dentro de `Assets/Art/`.
