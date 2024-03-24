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
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.Movement(), isTogglable = false, toolTip = "Movement Mods."},
                new ButtonInfo { buttonText = "Rig", method =() => SettingsMods.Rig(), isTogglable = false, toolTip = "Rig Mods."},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Change Menu Theme", method =() => SettingsMods.setTheme(), isTogglable = false, toolTip = "Changes The Menu Theme."},
                new ButtonInfo { buttonText = "Long Menu", method =() => SettingsMods.LongMenu(), isTogglable = false, toolTip = "You Ruined The Silly."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },

            new ButtonInfo[] { // Movement Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "NoClip [<color=#ff9400>LT</color>]", method=() => MovementShit.NoClip(), toolTip= "Go Through Shit."},
                new ButtonInfo { buttonText = "Platforms [<color=#ff9400>G</color>]", method=() => MovementShit.PlatformMonk(), toolTip= "Just Platform Monke."},
                new ButtonInfo { buttonText = "Fly [<color=#ff9400>A</color>]", method=() => MovementShit.FlyMonke(), toolTip= "Fly Arround."},
                new ButtonInfo { buttonText = "TP Gun", method=() => MovementShit.TPGun(), toolTip= "Aim And Teleport."},
                new ButtonInfo { buttonText = "TP To Random", method=() => MovementShit.TeleportToRandom(), isTogglable=false, toolTip= "Teleports You To Somone Random."},
            },

            new ButtonInfo[] { // Rig Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Fly Gun", method=() => RigShit.FlyGun(), toolTip= "Fly Arround Using A Gun Lmao."},
                new ButtonInfo { buttonText = "Ghost Monke [<color=#ff9400>X</color>]", method=() => RigShit.ghostMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Freeze Your Rig."},
                new ButtonInfo { buttonText = "Lag Monke", method=() => RigShit.lagMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Makes You Look Laggy But You Arent Acctually Lagging."},
                new ButtonInfo { buttonText = "Wtf Monke [<color=#ff9400>RT</color>]", method=() => RigShit.WTFMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "I Dont Even Know Man."},
                new ButtonInfo { buttonText = "Spaz Monke [<color=#ff9400>RT</color>]", method=() => RigShit.spazMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Basically Wtf Monke But Uhm Not As Wild."},
                new ButtonInfo { buttonText = "Heli Monke", method=() => RigShit.heliMonke(), disableMethod=() => RigShit.fixRig(), toolTip= "Basically Wtf Monke But Uhm Not As Wild."},
            },
        };
    }
}
