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
                    new GradientColorKey(new Color(1.0f, 0.64f, 0.0f), 0f),
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

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;
        public static bool longMenu = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1.5f, 0.5f); // Depth, Width, Height
        public static int buttonsPerPage = 3;
        public static int theme = 1;

        public static String[] platformShapes = {"Square", "Circle"};
        public static int platformShapeInt = 0;
    }
}