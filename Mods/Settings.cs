using BepInEx;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 3;
        }

        public static void PlatformSettings()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 4;
        }

        public static void ProjectileSettings()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 5;
        }

        public static void Themes()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 6;
        }

        public static void MiscellaneousMods()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 7;
        }

        public static void Movement()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 8;
        }

        public static void Rig()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 9;
        }

        public static void Cheats()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 10;
        }

        public static void OP()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 11;
        }

        public static void Forest()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 12;
        }

        public static void Clouds()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 13;
        }

        public static void Water()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 14;
        }

        public static void Projectile()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 15;
        }

        public static void Safety()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 16;
        }
        public static void AdminShit()
        {
            pageNumber = 0;
            curWatchMod = 0;
            buttonsType = 17;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void enableModSaving()
        {
            shouldSaveMods = true;
            PlayerPrefs.SetInt("shouldSaveMods", 1);
            PlayerPrefs.Save();
        }

        public static void disableModSaving()
        {
            shouldSaveMods = false;
            PlayerPrefs.SetInt("shouldSaveMods", 0);
            PlayerPrefs.Save();
        }

        public static void ChangePlatformShape()
        {
            ButtonInfo button = GetIndex("Platform Shape");

            platformShapeInt++;
            if (platformShapeInt > 2)
                platformShapeInt = 0;

            FileUtils.MakeTXTFile("MOVEMENT", platformShapeInt + "\n" + flySpeed + "\n" + speedBoostType + "\n" + veolocityMultiplyer);

            button.overlapText = "Platform Shape [" + platformShapes[platformShapeInt] + "]";
        }

        public static void ChangeSpeedBoostSpeed()
        {
            ButtonInfo button = GetIndex("SpeedBoost Speed");

            speedBoostType++;
            if (speedBoostType > 3)
                speedBoostType = 0;

            FileUtils.MakeTXTFile("MOVEMENT", platformShapeInt + "\n" + flySpeed + "\n" + speedBoostType + "\n" + veolocityMultiplyer);

            button.overlapText = "SpeedBoost Speed [" + movementTypes[speedBoostType] + "]";
        }

        public static void ChangeFlightSpeed()
        {
            ButtonInfo button = GetIndex("Fly Speed");

            flySpeed++;
            if (flySpeed > 2)
                flySpeed = 0;

            FileUtils.MakeTXTFile("MOVEMENT", platformShapeInt + "\n" + flySpeed + "\n" + speedBoostType + "\n" + veolocityMultiplyer);

            button.overlapText = "Fly Speed [" + movementTypes[flySpeed] + "]";
        }

        public static void ChangeVeolocityMultiplyer()
        {
            ButtonInfo button = GetIndex("Veolocity Monke Multiplyer");

            veolocityMultiplyer++;
            if (veolocityMultiplyer > 4)
                veolocityMultiplyer = 1;

            FileUtils.MakeTXTFile("MOVEMENT", platformShapeInt + "\n" + flySpeed + "\n" + speedBoostType + "\n" + veolocityMultiplyer);

            button.overlapText = "Veolocity Monke Multiplyer [" + veolocityMultiplyer + "]";
        }

        public static void ChangeHandTapValue()
        {
            ButtonInfo button = GetIndex("Sound When You Tap The Menu");

            hitSoundValue++;
            if (hitSoundValue > 4)
                hitSoundValue = 0;

            FileUtils.MakeTXTFile("HITSOUND", hitSoundValue.ToString());

            button.overlapText = "Sound When You Tap The Menu [" + hitSoundNames[hitSoundValue] + "]";
        }
        public static void ChangeProjectileType()
        {
            ButtonInfo button = GetIndex("Change Projectile Type");

            ProjectileType++;
            if (ProjectileType > 5)
                ProjectileType = 0;

            FileUtils.MakeTXTFile("PROJECTILE", ProjectileType + "\n" + RainRangeMultiplyer);

            button.overlapText = "Change Projectile Type [" + ProjectileShit.fullProjectileNames[ProjectileType] + "]";
        }
        public static void ChangeRainMulti()
        {
            ButtonInfo button = GetIndex("Change Rain Range");

            RainRangeMultiplyer++;
            if (RainRangeMultiplyer > 5)
                RainRangeMultiplyer = 1;

            FileUtils.MakeTXTFile("PROJECTILE", ProjectileType + "\n" + RainRangeMultiplyer);

            button.overlapText = "Change Rain Range [" + RainRangeMultiplyer + "]";
        }
        public static void LongMenu()
        {
            longMenu = true;

            buttonsPerPage = 8;
            menuSize = new Vector3(0.1f, 1f, 1f);

            RecreateMenu();
        }
        public static void DisableLongMenu() {
            longMenu = false;

            menuSize = new Vector3(0.1f, 1f, 0.5f); // Depth, Width, Height
            buttonsPerPage = 3;

            RecreateMenu();
        }
        public static void ChangePageLayout() //i just wanna handle everything else in main.cs cuz im lazy
        {
            buttonLayout++;
            if (buttonLayout > 3)
                buttonLayout = 1;

            PlayerPrefs.SetInt("buttonLayout", buttonLayout);
            PlayerPrefs.Save();
        }

        public static void themePreset(string theme)
        {
            if (theme == "brandon")
            {
                mainColor = 7;
                secondColor = 8;
                mainBorderColor = 8;
                secondBorderColor = 7;
                buttonColor = 0;
                buttonEnabledColor = 0;
                buttonTextColor = 1;
                buttonTextEnabledColor = 3;
            }
            else if (theme == "monke")
            {
                mainColor = 9;
                secondColor = 6;
                mainBorderColor = 6;
                secondBorderColor = 9;
                buttonColor = 0;
                buttonEnabledColor = 0;
                buttonTextColor = 4;
                buttonTextEnabledColor = 9;
            }
            else if (theme == "godzilla")
            {
                mainColor = 0;
                secondColor = 9;
                mainBorderColor = 9;
                secondBorderColor = 0;
                buttonColor = 0;
                buttonEnabledColor = 9;
                buttonTextColor = 9;
                buttonTextEnabledColor = 0;
            } else if (theme == "dark")
            {
                mainColor = 0;
                secondColor = 0;
                mainBorderColor = 18;
                secondBorderColor = 18;
                buttonColor = 0;
                buttonEnabledColor = 18;
                buttonTextColor = 1;
                buttonTextEnabledColor = 1;
            } else if (theme == "hacker")
            {
                mainColor = 0;
                secondColor = 5;
                mainBorderColor = 18;
                secondBorderColor = 18;
                buttonColor = 0;
                buttonEnabledColor = 0;
                buttonTextColor = 1;
                buttonTextEnabledColor = 5;
            }

            setTheme("preset");
        }

        public static void RainbowTheme() {
            newBackroundColor = new ExtGradient { isRainbow = true };
        }

        public static void SetPNGTheme()
        {
            PNGTheme++;
            if (PNGTheme > FileUtils.ReadTXTFile("themes/THEMES").Split("\n").Length - 1)
                PNGTheme = 0;

            FileUtils.MakeTXTFile("themes/THEME", PNGTheme.ToString());
        }

        public static void SetBorderPNGTheme()
        {
            BorderPNGTheme++;
            if (BorderPNGTheme > FileUtils.ReadTXTFile("themes/THEMES").Split("\n").Length - 1)
                BorderPNGTheme = 0;

            FileUtils.MakeTXTFile("themes/BORDERTHEME", BorderPNGTheme.ToString());
        }

        public static void ChangeFont()
        {
            currentFontNum++;
            if (currentFontNum > fonts.Length - 1)
                currentFontNum = 0;

            currentFont = fonts[currentFontNum];

            FileUtils.MakeTXTFile("FONT", currentFontNum.ToString());
        }

        static bool hasDoneHuntWatchShit = false;
        public static int curWatchMod = 0;
        static float timeTilPageSwitchWatch = 0;
        static float timeTilModClickWatch = 0;
        public static void WatchMenu()
        {
            GorillaTagger.Instance.offlineVRRig.EnableHuntWatch(true);

            GorillaHuntComputer watch = UnityEngine.Object.FindFirstObjectByType<GorillaHuntComputer>();

            string currentMod = Buttons.buttons[buttonsType][curWatchMod].buttonText;

            if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1 && Time.time > timeTilPageSwitchWatch)
            {
                curWatchMod--;

                if (curWatchMod < 0)
                    curWatchMod = Buttons.buttons[buttonsType].Length - 1;

                timeTilPageSwitchWatch = Time.time + 0.2f;
            }

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1 && Time.time > timeTilPageSwitchWatch)
            {
                curWatchMod++;

                if (curWatchMod > Buttons.buttons[buttonsType].Length - 1)
                    curWatchMod = 0;

                timeTilPageSwitchWatch = Time.time + 0.2f;
            }

            if (ControllerInputPoller.instance.rightControllerPrimaryButton && Time.time > timeTilModClickWatch)
            {
                Toggle(currentMod);

                timeTilModClickWatch = Time.time + 0.2f;
            }

            if (Buttons.buttons[buttonsType][curWatchMod].overlapText != null && Buttons.buttons[buttonsType][curWatchMod].overlapText != "")
                currentMod = Buttons.buttons[buttonsType][curWatchMod].overlapText;

            string defaultText = "504 [<color=#ff9400>" + DateTime.Now.Hour + "<color=white>:</color>" + DateTime.Now.Minute + "</color>]\n" + currentMod;

            if (Buttons.buttons[buttonsType][curWatchMod].enabled)
            {
                if (watch.text.text !=  defaultText + "\n[<color=green>ENABLED</color>]")
                    watch.text.text = defaultText + "\n[<color=green>ENABLED</color>]";
            } else
            {
                if (watch.text.text != defaultText + "\n[<color=red>DISABLED</color>]")
                    watch.text.text = defaultText + "\n[<color=red>DISABLED</color>]";
            }

            if (!Buttons.buttons[buttonsType][curWatchMod].isTogglable)
            {
                if (watch.text.text != defaultText)
                    watch.text.text = defaultText;
            }

            if (!hasDoneHuntWatchShit)
            {
                watch.hat.gameObject.SetActive(false);
                watch.badge.gameObject.SetActive(false);
                watch.face.gameObject.SetActive(false);
                watch.material.gameObject.SetActive(false);
                watch.leftHand.gameObject.SetActive(false);
                watch.rightHand.gameObject.SetActive(false);

                hasDoneHuntWatchShit = true;
            }
        }

        public static void setTheme(string changeing = "")
        {
            if (changeing == "firstColor")
            {
                mainColor++;
                if (mainColor > colorChangeablesAmmount)
                    mainColor = 0;
            } else if (changeing == "secondColor")
            {
                secondColor++;
                if (secondColor > colorChangeablesAmmount)
                    secondColor = 0;
            } else if (changeing == "firstBorderColor")
            {
                mainBorderColor++;
                if (mainBorderColor > colorChangeablesAmmount)
                    mainBorderColor = 0;
            } else if (changeing == "secondBorderColor")
            {
                secondBorderColor++;
                if (secondBorderColor > colorChangeablesAmmount)
                    secondBorderColor = 0;
            }
            else if (changeing == "buttonColor")
            {
                buttonColor++;
                if (buttonColor > colorChangeablesAmmount)
                    buttonColor = 0;
            } else if (changeing == "buttonEnabledColor")
            {
                buttonEnabledColor++;
                if (buttonEnabledColor > colorChangeablesAmmount)
                    buttonEnabledColor = 0;
            } else if (changeing == "buttonTextColor")
            {
                buttonTextColor++;
                if (buttonTextColor > colorChangeablesAmmount)
                    buttonTextColor = 0;
            } else if (changeing == "buttonTextEnabledColor")
            {
                buttonTextEnabledColor++;
                if (buttonTextEnabledColor > colorChangeablesAmmount)
                    buttonTextEnabledColor = 0;
            }

            if (GetIndex("Rainbow Menu").enabled)
                Toggle("Rainbow Menu");

            newBackroundColor = new ExtGradient
            {
                colors = new GradientColorKey[]
                {
                    new GradientColorKey(colorChangeables[mainColor], 0.25f),
                    new GradientColorKey(colorChangeables[secondColor], 1f),
                }
            };

            BackroundBorderColor = new ExtGradient
            {
                colors = new GradientColorKey[]
                {
                    new GradientColorKey(colorChangeables[mainBorderColor], 0.25f),
                    new GradientColorKey(colorChangeables[secondBorderColor], 1f),
                }
            };

            textColors = new Color[]
            {
                colorChangeables[buttonTextColor],
                colorChangeables[buttonTextEnabledColor]
            };

            newButtonColors = new Color[]
            {
                colorChangeables[buttonColor],
                colorChangeables[buttonEnabledColor]
            };

            if (changeing != "")
            {
                FileUtils.MakeTXTFile("MENU_COLORS", mainColor + "\n" + secondColor + "\n" + mainBorderColor + "\n" + secondBorderColor + "\n" + buttonColor + "\n" + buttonEnabledColor + "\n" + buttonTextColor + "\n" + buttonTextEnabledColor);
            }

            RecreateMenu();
        }
    }
}