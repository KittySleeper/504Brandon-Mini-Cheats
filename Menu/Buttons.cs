using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "PC EMULATION", toolTip = "Here Monke."},
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Miscellaneous Mods", method =() => SettingsMods.MiscellaneousMods(), isTogglable = false, toolTip = "Miscellaneous Mods."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => SettingsMods.Movement(), isTogglable = false, toolTip = "Movement Mods."},
                new ButtonInfo { buttonText = "Rig Mods", method =() => SettingsMods.Rig(), isTogglable = false, toolTip = "Rig Mods."},
                new ButtonInfo { buttonText = "Cheat Mods", method =() => SettingsMods.Cheats(), isTogglable = false, toolTip = "Cheat Mods."},
                new ButtonInfo { buttonText = "Glider Mods", method =() => SettingsMods.Glider(), isTogglable = false, toolTip = "Glider Mods."},
                new ButtonInfo { buttonText = "Projectile Mods", method =() => SettingsMods.Projectile(), isTogglable = false, toolTip = "Projectile Mods."},
                new ButtonInfo { buttonText = "Bug And Bat Mods", method =() => SettingsMods.BugBat(), isTogglable = false, toolTip = "Doug And Matt Mods."},
                new ButtonInfo { buttonText = "Saftey Mods", method =() => SettingsMods.Safety(), isTogglable = false, toolTip = "Saftey Mods."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Menu Theme Presets", method =() => SettingsMods.Themes(), isTogglable = false, toolTip = "Presets For All Of The Themes."},
                new ButtonInfo { buttonText = "Change First Menu Color", method =() => SettingsMods.setTheme("firstColor"), isTogglable = false, toolTip = "Changes The First Color Of The Menu."},
                new ButtonInfo { buttonText = "Change Second Menu Color", method =() => SettingsMods.setTheme("secondColor"), isTogglable = false, toolTip = "Changes The Second Color Of The Menu."},
                new ButtonInfo { buttonText = "Change Button Color", method =() => SettingsMods.setTheme("buttonColor"), isTogglable = false, toolTip = "Changes The Button Color."},
                new ButtonInfo { buttonText = "Change Enabled Button Color", method =() => SettingsMods.setTheme("buttonEnabledColor"), isTogglable = false, toolTip = "Changes The Enabled Button Color."},
                new ButtonInfo { buttonText = "Change Text Color", method =() => SettingsMods.setTheme("buttonTextColor"), isTogglable = false, toolTip = "Changes The Text Color."},
                new ButtonInfo { buttonText = "Change Enabled Text Color", method =() => SettingsMods.setTheme("buttonTextEnabledColor"), isTogglable = false, toolTip = "Changes The Enabled Text Color."},
                //new ButtonInfo { buttonText = "Change Page Layout", method =() => SettingsMods.ChangePageLayout(), isTogglable = false, toolTip = "Changes How You Change The Pages."},
                new ButtonInfo { buttonText = "Long Menu", method =() => SettingsMods.LongMenu(), isTogglable = false, toolTip = "You Ruined The Silly."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand.", enabled = true},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},                new ButtonInfo { buttonText = "Anti Report Reconnect", toolTip = "Makes It So You Reconnect After Geting Kicked Out From Anti Report."},
                new ButtonInfo { buttonText = "Sound When You Tap The Menu", overlapText = "Sound When You Tap The Menu [" + hitSoundNames[hitSoundValue] + "]", method =() => SettingsMods.ChangeHandTapValue(), isTogglable = false},
                new ButtonInfo { buttonText = "Should Save Mods", enableMethod =() => SettingsMods.enableModSaving(), disableMethod =() => SettingsMods.disableModSaving(), toolTip = "Do you like mod saving or nah."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Platform Settings", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the platfrorm settings for the menu."},
            },

            new ButtonInfo[] { // Platform Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Invis Platforms", toolTip = "Invisible Platforms."},
                new ButtonInfo { buttonText = "Platform Shape", overlapText = "Platform Shape [" + platformShapes[platformShapeInt] + "]", method =() => SettingsMods.ChangePlatformShape(), isTogglable = false, toolTip = "Change your platform shape."},
                new ButtonInfo { buttonText = "Trigger Platforms", toolTip = "Use Platforms By Pressing Your Triggers."},
            },

            new ButtonInfo[] { // Theme Presets
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "504Brandon Theme", method =() => SettingsMods.themePreset("brandon"), isTogglable = false},
                new ButtonInfo { buttonText = "GodzillaGang Theme", method =() => SettingsMods.themePreset("godzilla"), isTogglable = false},
                new ButtonInfo { buttonText = "♡Monke♡ Theme", method =() => SettingsMods.themePreset("monke"), isTogglable = false},
                new ButtonInfo { buttonText = "Rainbow Menu", method =() => SettingsMods.RainbowTheme(), isTogglable = false, toolTip = "Makes the menu gay."},
            },

            new ButtonInfo[] { // Misc Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Fuck Leaderboard", method=() => RandomShit.fuckLeaderBoard(), toolTip= "Kinda breaks leaderboard name."},
                new ButtonInfo { buttonText = "Make QuitBox Platform", enableMethod=() => RandomShit.MakeQuitBoxPlatform(), disableMethod=() => RandomShit.DeleteQuitBoxPlatform(), toolTip= "Makes it so the quitbox is just a bit platform you can sit on."},
                new ButtonInfo { buttonText = "Ban Self", method=() => RandomShit.BanSelf(), toolTip= "Why did i add this?"},
                new ButtonInfo { buttonText = "umi ツ | #FREEMSMS", toolTip= "Useless...."},
            },
            new ButtonInfo[] { // Movement Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "NoClip [<color=#ff9400>LT</color>]", method=() => MovementShit.NoClip(), toolTip= "Go Through Shit."},
                new ButtonInfo { buttonText = "Platforms", method=() => MovementShit.PlatformMonk(), toolTip= "Just Platform Monke."},
                new ButtonInfo { buttonText = "Fly [<color=#ff9400>A</color>]", method=() => MovementShit.FlyMonke(), toolTip= "Fly Arround."},
                new ButtonInfo { buttonText = "TP Gun", method=() => MovementShit.TPGun(), toolTip= "Aim And Teleport."},
                new ButtonInfo { buttonText = "TP To Random [<color=#ff9400>X</color>]", method=() => MovementShit.TeleportToRandom(), toolTip= "Teleports You To Somone Random."},
                new ButtonInfo { buttonText = "Low Gravity [<color=#ff9400>LG</color>]", method=() => MovementShit.GravityMod(-0.5f), toolTip= "Makes The Gravity Low."},
                new ButtonInfo { buttonText = "Mosa Speed Boost", method=() => MovementShit.SpeedBoost(7.5f), disableMethod=() => MovementShit.SpeedBoost(6.5f), toolTip= "Mosa Speed Boost."},
                new ButtonInfo { buttonText = "Mega Speed Boost", method=() => MovementShit.SpeedBoost(11f), disableMethod=() => MovementShit.SpeedBoost(6.5f), toolTip= "Mosa Speed Boost."},
            },

            new ButtonInfo[] { // Rig Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Fly Gun", method=() => RigShit.FlyGun(), toolTip= "Fly Arround Using A Gun Lmao."},
                new ButtonInfo { buttonText = "Fly To Player Gun", method=() => RigShit.FlyToPlayerGun(), toolTip= "Fly To A Player Using A Gun Lmao."},
                new ButtonInfo { buttonText = "Ghost Monke [<color=#ff9400>X</color>]", method=() => RigShit.ghostMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Freeze Your Rig."},
                new ButtonInfo { buttonText = "Invis Monke [<color=#ff9400>X</color>]", method=() => RigShit.invisMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Make Your Rig Invisible."},
                new ButtonInfo { buttonText = "Lag Monke", method=() => RigShit.lagMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Makes You Look Laggy But You Arent Acctually Lagging."},
                new ButtonInfo { buttonText = "Wtf Monke [<color=#ff9400>RT</color>]", method=() => RigShit.WTFMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "I Dont Even Know Man."},
                new ButtonInfo { buttonText = "Spaz Monke [<color=#ff9400>RT</color>]", method=() => RigShit.spazMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Basically Wtf Monke But Uhm Not As Wild."},
                new ButtonInfo { buttonText = "Heli Monke", method=() => RigShit.heliMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Basically Wtf Monke But Uhm Not As Wild."},
            },

            new ButtonInfo[] { // Cheat Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tag Gun", method =() => AdvantageShit.TagGun(), toolTip = "Aim And Tag."},
                new ButtonInfo { buttonText = "Tag All", method=() => AdvantageShit.tagAll(), toolTip= "Tag Everyone."},
                new ButtonInfo { buttonText = "Chams", enableMethod=() => AdvantageShit.Chams(), disableMethod=() => AdvantageShit.KillChams(), toolTip= "See people through shit."},
            },

            new ButtonInfo[] { // Glider Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Break Gliders", method=() => GliderShit.BreakGliders(), toolTip= "Break Gliders."},
                new ButtonInfo { buttonText = "Gliders Aura [<color=#ff9400>LG</color>]", method =() => GliderShit.TpGlider(), toolTip = "Teleports all gliders to you."},
                new ButtonInfo { buttonText = "Hold Gliders [<color=#ff9400>LG</color>]", method =() => GliderShit.TpGlider(true), toolTip = "Hold all gliders."},
                new ButtonInfo { buttonText = "Glider Gun", method =() => GliderShit.GliderGun(), toolTip = "Teleports all gliders to the gun."},
                new ButtonInfo { buttonText = "Blind Gun", method=() => GliderShit.BlindGun(), toolTip= "Blind People."},
            },

           new ButtonInfo[] { // Projectile Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Snowball Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer(), toolTip= "Spam Snowballs."},
                new ButtonInfo { buttonText = "Ballon Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer("WaterBalloon", true), toolTip= "Spam Ballons."},
                new ButtonInfo { buttonText = "Rock Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer("LavaRock"), toolTip= "Spam Rocks."},
                new ButtonInfo { buttonText = "Gift Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer("ThrowableGift"), toolTip= "Spam Gifts (bro thinks hes santa)."},
                new ButtonInfo { buttonText = "Mentos Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer("ScienceCandy"), toolTip= "Spam Mentos."},
                new ButtonInfo { buttonText = "Fish Food Spammer [<color=#ff9400>RG</color>]", method=() => ProjectileShit.ProjectileSpammer("FishFood"), toolTip= "Spam Fish Food."},
                new ButtonInfo { buttonText = "Piss [<color=#ff9400>RG</color>]", method=() => ProjectileShit.Urine(), toolTip= "Piss on children (can i say that?)."},
                new ButtonInfo { buttonText = "Cum [<color=#ff9400>RG</color>]", method=() => ProjectileShit.Semen(), toolTip= "Cum on children (yea i cant say that-)."},
                new ButtonInfo { buttonText = "Vomit [<color=#ff9400>RG</color>]", method=() => ProjectileShit.Vomit(), toolTip= "Vomit on children."},
                new ButtonInfo { buttonText = "Shit [<color=#ff9400>RG</color>]", method=() => ProjectileShit.Feces(), toolTip= "Shit on children."},
            },

           new ButtonInfo[] { // Bug And Bat Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Break Bug", method=() => DougAndMattShit.BreakBug(), disableMethod=() => DougAndMattShit.FixBug(), toolTip= "Break Bug."},
                new ButtonInfo { buttonText = "Break Bat", method=() => DougAndMattShit.BreakBat(), disableMethod=() => DougAndMattShit.FixBat(), toolTip= "Break Bat."},
                new ButtonInfo { buttonText = "Grab Bug [<color=#ff9400>LG</color>]", method=() => DougAndMattShit.GrabBug(), disableMethod=() => DougAndMattShit.FixBug(), toolTip= "Grab the bug."},
                new ButtonInfo { buttonText = "Grab Bat [<color=#ff9400>RG</color>]", method=() => DougAndMattShit.GrabBat(), disableMethod=() => DougAndMattShit.FixBat(), toolTip= "Grab the bat."},
                new ButtonInfo { buttonText = "Give Bug", method=() => DougAndMattShit.GiveBug(), disableMethod=() => DougAndMattShit.FixBug(), toolTip= "Give the bug."},
                new ButtonInfo { buttonText = "Give Bat", method=() => DougAndMattShit.GiveBat(), disableMethod=() => DougAndMattShit.FixBat(), toolTip= "Give the bat."},
                new ButtonInfo { buttonText = "Fast Bug", method=() => DougAndMattShit.FastBug(), disableMethod=() => DougAndMattShit.FixBug(), toolTip= "Make Da Bug Fast."},
                new ButtonInfo { buttonText = "Fast Bat", method=() => DougAndMattShit.FastBat(), disableMethod=() => DougAndMattShit.FixBat(), toolTip= "Make Da Bat Fast."},
                new ButtonInfo { buttonText = "RC Bug [<color=#ff9400>J</color>]", method=() => DougAndMattShit.ControlBug(), disableMethod=() => DougAndMattShit.FixBug(), toolTip= "Control the bug."},
            },

            new ButtonInfo[] { // Safety Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Flush Rpc", method =() => SafetyShit.RpcFlush(), isTogglable = false, toolTip = "Fake anti ban goes hard (/hj)."},
                new ButtonInfo { buttonText = "Anti Report", method =() => SafetyShit.AntiReport(), toolTip = "Kids cant report you anymore."},
            },
        };
    }
}
