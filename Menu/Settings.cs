using StupidTemplate.Classes;
using System;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient { isRainbow = true };

        public static ExtGradient newBackroundColor = new ExtGradient //im too lazy to replace backround color itself rn okay?
        {
            colors = new GradientColorKey[]
            {
                new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 0.25f),
                new GradientColorKey(Color.yellow, 1f),
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

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

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
        public static int buttonColor = 0;
        public static int buttonEnabledColor = 0;
        public static int buttonTextColor = 1;
        public static int buttonTextEnabledColor = 3;
        public static int buttonLayout = 1;

        public static String[] platformShapes = {"Cube", "Square", "Circle"};
        public static int platformShapeInt = 0;

        public static String[] hitSoundNames = {"Hand Tap", "AK-47", "Big Crystal", "Normal Crystal", "Random"};
        public static int[] hitSoundValues = {8, 203, 213, 244, UnityEngine.Random.Range(8, 244)};
        public static int hitSoundValue = 0;

        public static Color[] colorChangeables = {Color.black, Color.white, Color.gray, Color.cyan, Color.blue, Color.green, Color.magenta, new Color(1.0f, 0.64f, 0.0f), Color.yellow, Color.red};
        public static int colorChangeablesAmmount = 9;
    }
}