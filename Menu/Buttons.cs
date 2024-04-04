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
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => SettingsMods.Movement(), isTogglable = false, toolTip = "Movement Mods."},
                new ButtonInfo { buttonText = "Rig Mods", method =() => SettingsMods.Rig(), isTogglable = false, toolTip = "Rig Mods."},
                new ButtonInfo { buttonText = "Cheat Mods", method =() => SettingsMods.Cheats(), isTogglable = false, toolTip = "Cheat Mods."},
                new ButtonInfo { buttonText = "Saftey Mods", method =() => SettingsMods.Safety(), isTogglable = false, toolTip = "Saftey Mods."},
                new ButtonInfo { buttonText = "Snowball Launcher [<color=#ff9400>RG</color>]", method=() => ProjectileShit.projectileSpam(), toolTip= "Shoot Snowballs."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Change Menu Theme", method =() => SettingsMods.setTheme(), isTogglable = false, toolTip = "Changes The Menu Theme."},
                new ButtonInfo { buttonText = "Long Menu", method =() => SettingsMods.LongMenu(), isTogglable = false, toolTip = "You Ruined The Silly."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Anti Report Reconnect", toolTip = "Makes It So You Reconnect After Geting Kicked Out From Anti Report."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Platform Settings", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the platfrorm settings for the menu."},
            },

            new ButtonInfo[] { // Platform Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Invis Platforms", toolTip = "Invisible Platforms."},
                new ButtonInfo { buttonText = "Platform Shape [" + platformShapes[platformShapeInt] + "]", method =() => SettingsMods.ChangePlatformShape(), isTogglable = false, toolTip = "Change your platform shape."},
                new ButtonInfo { buttonText = "Trigger Platforms", toolTip = "Use Platforms By Pressing Your Triggers."},
            },

            new ButtonInfo[] { // Movement Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "NoClip [<color=#ff9400>LT</color>]", method=() => MovementShit.NoClip(), toolTip= "Go Through Shit."},
                new ButtonInfo { buttonText = "Platforms [<color=#ff9400>G</color>]", method=() => MovementShit.PlatformMonk(), toolTip= "Just Platform Monke."},
                new ButtonInfo { buttonText = "Fly [<color=#ff9400>A</color>]", method=() => MovementShit.FlyMonke(), toolTip= "Fly Arround."},
                new ButtonInfo { buttonText = "TP Gun", method=() => MovementShit.TPGun(), toolTip= "Aim And Teleport."},
                new ButtonInfo { buttonText = "TP To Random [<color=#ff9400>X</color>]", method=() => MovementShit.TeleportToRandom(), toolTip= "Teleports You To Somone Random."},
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

           new ButtonInfo[] { // Safety Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Flush Rpc", method =() => SafetyShit.RpcFlush(), isTogglable = false, toolTip = "Fake anti ban goes hard (/hj)."},
                new ButtonInfo { buttonText = "Anti Report (forest)", method =() => SafetyShit.AntiReport(), toolTip = "Kids cant report you anymore (ONLY USE IN FOREST)."},
            },

           new ButtonInfo[] { // Cheat Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Tag Gun [<color=#ffcc00>D?/EX</color>]", method =() => AdvantageShit.TagGun(), toolTip = "Aim And Tag."},
                new ButtonInfo { buttonText = "Tag All", method=() => AdvantageShit.tagAll(), toolTip= "Tag Everyone."},
            },
        };
    }
}
