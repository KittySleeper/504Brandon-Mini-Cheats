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
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            pageNumber = 0;
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            pageNumber = 0;
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            pageNumber = 0;
            buttonsType = 4;
        }

        public static void Themes()
        {
            pageNumber = 0;
            buttonsType = 5;
        }

        public static void MiscellaneousMods()
        {
            pageNumber = 0;
            buttonsType = 6;
        }

        public static void Movement()
        {
            pageNumber = 0;
            buttonsType = 7;
        }

        public static void Rig()
        {
            pageNumber = 0;
            buttonsType = 8;
        }

        public static void Cheats()
        {
            pageNumber = 0;
            buttonsType = 9;
        }

        public static void OP()
        {
            pageNumber = 0;
            buttonsType = 10;
        }

        public static void Glider()
        {
            pageNumber = 0;
            buttonsType = 11;
        }

        public static void Projectile()
        {
            pageNumber = 0;
            buttonsType = 12;
        }

        public static void BugBat()
        {
            pageNumber = 0;
            buttonsType = 13;
        }

        public static void Safety()
        {
            pageNumber = 0;
            buttonsType = 14;
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

            PlayerPrefs.SetInt("platformShapeInt", platformShapeInt);
            PlayerPrefs.Save();

            button.overlapText = "Platform Shape [" + platformShapes[platformShapeInt] + "]";
        }

        public static void ChangeHandTapValue()
        {
            ButtonInfo button = GetIndex("Sound When You Tap The Menu");

            hitSoundValue++;
            if (hitSoundValue > 4)
                hitSoundValue = 0;

            PlayerPrefs.SetInt("hitSoundValue", hitSoundValue);
            PlayerPrefs.Save();

            button.overlapText = "Sound When You Tap The Menu [" + hitSoundNames[hitSoundValue] + "]";
        }

        public static void LongMenu()
        {
            //it is no longer mini wtf
            longMenu = !longMenu;

            if (longMenu)
            {
                buttonsPerPage = 8;
                menuSize = new Vector3(0.1f, 1f, 1f);
                PlayerPrefs.SetInt("longMenu", 1);
            }
            else
            {
                menuSize = new Vector3(0.1f, 1f, 0.5f); // Depth, Width, Height
                buttonsPerPage = 3;
                PlayerPrefs.SetInt("longMenu", 0);
            }

            PlayerPrefs.Save();

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
                buttonColor = 0;
                buttonEnabledColor = 0;
                buttonTextColor = 1;
                buttonTextEnabledColor = 3;
            }
            else if (theme == "monke")
            {
                mainColor = 9;
                secondColor = 6;
                buttonColor = 0;
                buttonEnabledColor = 0;
                buttonTextColor = 4;
                buttonTextEnabledColor = 9;
            }
            else if (theme == "godzilla")
            {
                mainColor = 0;
                secondColor = 9;
                buttonColor = 0;
                buttonEnabledColor = 9;
                buttonTextColor = 9;
                buttonTextEnabledColor = 0;
            }

            setTheme("preset");
        }

        public static void RainbowTheme() {
            isRainbowMenu = !isRainbowMenu;

            if (isRainbowMenu)
            {
                newBackroundColor = new ExtGradient { isRainbow = true };
                PlayerPrefs.SetInt("isRainbowMenu", 1);
            }
            else
            {
                PlayerPrefs.SetInt("isRainbowMenu", 0);
                setTheme();
            }

            PlayerPrefs.Save();
        }

        public static void setTheme(string changeing = "")
        {
            isRainbowMenu = false;

            PlayerPrefs.SetInt("isRainbowMenu", 0);
            PlayerPrefs.Save();

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
            } else if (changeing == "buttonColor")
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

            newBackroundColor = new ExtGradient
            {
                colors = new GradientColorKey[]
                {
                    new GradientColorKey(colorChangeables[mainColor], 0.25f),
                    new GradientColorKey(colorChangeables[secondColor], 1f),
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
                PlayerPrefs.SetInt("mainThemeColor", mainColor);
                PlayerPrefs.SetInt("secondThemeColor", secondColor);
                PlayerPrefs.SetInt("buttonColor", buttonColor);
                PlayerPrefs.SetInt("buttonEnabledColor", buttonEnabledColor);
                PlayerPrefs.SetInt("buttonTextColor", buttonTextColor);
                PlayerPrefs.SetInt("buttonTextEnabledColor", buttonTextEnabledColor);
                PlayerPrefs.Save();
            }

            RecreateMenu();
        }
    }
}