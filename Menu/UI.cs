using UnityEngine;
using BepInEx;
using StupidTemplate.Classes;
using System.Linq;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Diagnostics;
using ExitGames.Client.Photon;
using GorillaNetworking;
using static UnityEngine.UI.GridLayoutGroup;
using System.EnterpriseServices;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Voice.Unity;
using Oculus.Platform.Models;
using HarmonyLib;
using UnityEngine.UIElements;
using static UnityEngine.GUI;

namespace StupidTemplate.Menu
{
    public class UI : MonoBehaviour
    {
        public static string whoReported = "NOBODY HAS REPORTED YO GOOFY ASS";
        public static string lastRoom = "HASNT BEEN IN ROOM";
        public static int UIPage = 0;
        public static float leftCooldown = 0;
        public static float rightCooldown = 0;
        public static string modsOn = "";
        private bool showGUI = true;

        private Rect ModGUI = new Rect(20, 20, 300, 255);
        public void OnGUI()
        {
            resetGUIColors();

            foreach (ButtonInfo[] buttons in Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.enabled)
                        modsOn += "\n" + button.buttonText;
                }
            }

            GUI.Label(new Rect(new Rect(40, 5, 99999, 99999)), modsOn);

            modsOn = "";

            if (showGUI)
            {
                ModGUI = GUI.Window(0, ModGUI, MenuGUIShit, PluginInfo.Name + "\nFPS:" + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString());

                if (GUI.Button(new Rect(ModGUI.x + 110, ModGUI.y - 24, 80, 22), "Disconnect"))
                {
                    PhotonNetwork.Disconnect();
                }

                resetGUIColors();

                int lastPage = ((Buttons.buttons[buttonsType].Length + 9 - 1) / 9) - 1;

                if (UnityInput.Current.GetKey(KeyCode.Q) && Time.time > leftCooldown)
                {
                    UIPage--;
                    leftCooldown = Time.time + 0.2f;

                    if (UIPage == -1)
                        UIPage = lastPage;
                }

                if (UnityInput.Current.GetKey(KeyCode.E) && Time.time > rightCooldown)
                {
                    UIPage++;
                    rightCooldown = Time.time + 0.2f;

                    if (UIPage > lastPage)
                        UIPage = 0;
                }
            }
        }
        void MenuGUIShit(int windowID)
        {
            ButtonInfo[] activeButtons = Buttons.buttons[buttonsType].Skip(UIPage * 9).Take(9).ToArray();

            for (int i = 0; i < activeButtons.Length; i++)
            {
                if (activeButtons[i].enabled)
                {
                    GUI.backgroundColor = newButtonColors[1];
                    GUI.contentColor = textColors[1];
                }
                else
                {
                    GUI.backgroundColor = newButtonColors[0];
                    GUI.contentColor = textColors[0];
                }

                string buttonText;

                if (activeButtons[i].overlapText != null && activeButtons[i].overlapText != "")
                    buttonText = activeButtons[i].overlapText;
                else
                    buttonText = activeButtons[i].buttonText;

                if (GUI.Button(new Rect(12, 35 + i * 22, 275, 20), buttonText))
                {
                    Toggle(activeButtons[i].buttonText);
                    Global.playSound(hitSoundValues[hitSoundValue], true, 1);
                }
            }

            if (GUI.Button(new Rect(12, 35 + activeButtons.Length * 22, 275, 20), "Close GUI"))
            {
                showGUI = false;
            }

            GUI.DragWindow(new Rect(0, 0, 300, 20));
        }
        Texture2D MenuBGThing(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
        public static void resetGUIColors()
        {
            GUI.contentColor = textColors[0];
            GUI.skin.font = currentFont;
            GUI.backgroundColor = newButtonColors[0];
        }
    }
}