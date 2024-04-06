using StupidTemplate.Classes;
using StupidTemplate.Menu;
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
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
        }

        public static void MiscellaneousMods()
        {
            buttonsType = 5;
        }

        public static void Movement()
        {
            buttonsType = 6;
        }

        public static void Rig() {
            buttonsType = 7;
        }

        public static void Safety()
        {
            buttonsType = 8;
        }

        public static void Cheats()
        {
            buttonsType = 9;
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
            ButtonInfo button = Buttons.buttons[4][2];

            platformShapeInt++;
            if (platformShapeInt > 2)
                platformShapeInt = 0;

            PlayerPrefs.SetInt("platformShapeInt", platformShapeInt);
            PlayerPrefs.Save();

            button.overlapText = "Platform Shape [" + platformShapes[platformShapeInt] + "]";
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
                menuSize = new Vector3(0.1f, 1.5f, 0.5f); // Depth, Width, Height
                buttonsPerPage = 3;
                PlayerPrefs.SetInt("longMenu", 0);
            }

            PlayerPrefs.Save();

            RecreateMenu();
        }

        public static void setTheme(bool change = true)
        {
            if (change)
            {
                theme++;
                if (theme > 5)
                    theme = 1;
            }

            PlayerPrefs.SetInt("themeInt", theme);
            PlayerPrefs.Save();

            if (theme == 1) //Default Theme
            {
                newBackroundColor = new ExtGradient
                {
                    colors = new GradientColorKey[]
                {
                    new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 0f),
                    new GradientColorKey(Color.yellow, 1f),
                }
                };
            }

            if (theme == 2) //Default Theme With Black
            {
                newBackroundColor = new ExtGradient
                {
                    colors = new GradientColorKey[]
                {
                    new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 0f),
                    new GradientColorKey(Color.black, 1f),
                }
                };
            }

            if (theme == 3) //Red Theme
            {
                newBackroundColor = new ExtGradient
                {
                    colors = new GradientColorKey[]
                {
                    new GradientColorKey(Color.red, 0f),
                    new GradientColorKey(Color.black, 1f),
                }
                };
            }

            if (theme == 4) //Magenta Theme
            {
                newBackroundColor = new ExtGradient
                {
                    colors = new GradientColorKey[]
                    {
                    new GradientColorKey(Color.magenta, 0f),
                    new GradientColorKey(Color.black, 1f),
                    }
                };
            }

            if (theme == 5) //Shiba Gold Ahh Theme
            {
                newBackroundColor = new ExtGradient
                {
                    colors = new GradientColorKey[]
                    {
                    new GradientColorKey(Color.yellow, 0f),
                    new GradientColorKey(Color.black, 1f),
                    }
                };
            }

            RecreateMenu(); //so the theme sets
        }
    }
}
