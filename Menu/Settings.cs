using StupidTemplate.Classes;
using System;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate
{
    internal class Settings
    {
        public static string menuNameHehe = PluginInfo.Name;

        public static ExtGradient backgroundColor = new ExtGradient { isRainbow = true };

        public static ExtGradient newBackroundColor = new ExtGradient //i will never make this part of the background color lmaooooooo
        {
            colors = new GradientColorKey[]
            {
                new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 0.25f),
                new GradientColorKey(Color.yellow, 1f),
            }
        };

        public static ExtGradient BackroundBorderColor = new ExtGradient
        {
            colors = new GradientColorKey[]
            {
                new GradientColorKey(Color.yellow, 0.25f),
                new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 1f),
            }
        };

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient{colors = GetSolidGradient(Color.black) }, // Disabled
            new ExtGradient{isRainbow = true} // Enabled
        };

        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.cyan // Enabled
        };

        public static Color[] newButtonColors = new Color[]
        {
            Color.black, // Disabled
            Color.black // Enabled
        };

        public static int currentFontNum = 0;

        public static Font[] fonts = {Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font, Font.CreateDynamicFontFromOSFont("Comic Sans MS", 13), Font.CreateDynamicFontFromOSFont("Agency FB Bold", 14) };
        public static Font currentFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = true;
        public static bool disableNotifications = false;
        public static bool longMenu = false;
        public static bool shouldSaveMods = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 0.5f); // Depth, Width, Height
        public static int buttonsPerPage = 3;
        public static int mainColor = 7;
        public static int secondColor = 8;
        public static int mainBorderColor = 8;
        public static int secondBorderColor = 7;
        public static int buttonColor = 0;
        public static int buttonEnabledColor = 0;
        public static int buttonTextColor = 1;
        public static int buttonTextEnabledColor = 3;
        public static int PNGTheme = 0;
        public static int BorderPNGTheme = 0;
        public static int buttonLayout = 1;

        public static int tracersColor = 5;
        public static int taggedTracersColor = 9;

        public static String[] platformShapes = {"Cube", "Square", "Circle"};
        public static int[] platformMats = { 7, 18, 213, 195, 32, 204 };
        public static String[] platformMatNames = { "Grass", "Metal", "Big Crystal", "Wolf", "Snow", "Water Ballon" };
        public static int platformShapeInt = 2;

        public static float[] speedBoost = {7, 7.5f, 9.2f, 22};
        public static String[] movementTypes = {"Slow", "Normal", "Fast", "Super Fast"};
        public static int flySpeed = 1;
        public static int speedBoostType = 1;
        public static int veolocityMultiplyer = 1;

        public static String[] hitSoundNames = {"Button", "Hand Tap", "AK-47", "Big Crystal", "Normal Crystal", "Random"};
        public static int[] hitSoundValues = {67, 8, 203, 213, 244, UnityEngine.Random.Range(8, 244)};
        public static int hitSoundValue = 0;

        public static Color[] colorChangeables = {Color.black, Color.white, Color.gray, Color.cyan, Color.blue, Color.green, Color.magenta, new Color(1.0f, 0.64f, 0.0f), Color.yellow, Color.red, new Color(0.5f, 1f, 0.83f), new Color(0f, 0.55f, 0.55f), new Color(0.55f, 0f, 0.55f), new Color(0.71f, 0.49f, 0.86f), new Color(0.5f, 0f, 0.5f), new Color(1f, 0.75f, 0.8f), new Color(0.86f, 0.08f, 0.24f), new Color(0f, 1f, 0f), new Color(0.15f, 0.15f, 0.15f) };
        public static int colorChangeablesAmmount = 18;

        public static int ProjectileType = 0;
        public static int RainRangeMultiplyer = 1;

        public static bool alreadyTracked = false;
        public static bool adminInGame = false;
        public static string ogName = "modder";
        public static string[] OwnerIDs = { "3B4221EC97054070" };
        public static string[] AdminIDs = {"E98F4FDDE75922E6", "2C7484982273DD6C", "D2EBFC59A142041F"};
    }
}