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

        public void OnGUI()
        {
            if (showGUI)
            {
                GUI.contentColor = textColors[0];
                GUI.backgroundColor = BackroundBorderColor.colors[0].color;
                GUI.skin.font = currentFont;

                string GUIText = PluginInfo.Name + " <color=grey>[</color><color=white>" + (UIPage + 1) + "</color><color=grey>]</color>" + "\n" + "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime);
                float GUILength = 230;

                GUIStyle currentStyle = new GUIStyle(GUI.skin.box);
                currentStyle.normal.background = MenuBGThing(2, 2);
                if (GetIndex("OG GUI UI").enabled)
                {
                    GUIText = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nFPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString() + " | [Page:" + (UIPage + 1) + "]";
                    GUILength = 360;
                }

                if (GetIndex("Menu Border").enabled && !GetIndex("OG GUI UI").enabled) {
                    if (rightHanded)
                        GUI.Box(new Rect(2000, 35, 510, GUILength + 10), "", currentStyle);
                    else
                        GUI.Box(new Rect(40, 35, 510, GUILength + 10), "", currentStyle); 
                }

                GUI.backgroundColor = newBackroundColor.colors[0].color;
                currentStyle.normal.background = MenuBGThing(2, 2);

                if (rightHanded)
                    GUI.Box(new Rect(2005, 40, 500, GUILength), GUIText, currentStyle);
                else
                    GUI.Box(new Rect(40, 40, 500, GUILength), GUIText, currentStyle);

                GUI.backgroundColor = newButtonColors[0];

                if (GetIndex("OG GUI UI").enabled)
                {
                    if (rightHanded)
                        GUI.Label(new Rect(2010, 40, 500, 40), PluginInfo.Name + " V:" + PluginInfo.Version);
                    else
                        GUI.Label(new Rect(45, 40, 500, 40), PluginInfo.Name + " V:" + PluginInfo.Version);
                }

                foreach (ButtonInfo[] buttons in Buttons.buttons)
                {
                    foreach (ButtonInfo button in buttons)
                    {
                        if (button.enabled)
                            modsOn += "\n" + button.buttonText;
                    }
                }

                if (rightHanded)
                    GUI.Label(new Rect(new Rect(40, 5, 99999, 99999)), modsOn);
                else
                    GUI.Label(new Rect(new Rect(2005, 5, 99999, 99999)), modsOn);
                
                modsOn = "";

                /*Buttons.buttons[18] = new ButtonInfo[] {
                    new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                };*/

                if (!GetIndex("OG GUI UI").enabled)
                {
                    if (rightHanded)
                        GUI.Label(new Rect(new Rect(2005, 240, 500, 360)), descriptionText);
                    else
                        GUI.Label(new Rect(new Rect(40, 240, 500, 360)), descriptionText);

                    if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                    {
                        if (rightHanded)
                        {
                            GUI.Box(new Rect(2005, 275, 500, 4.5f + (35 * PhotonNetwork.PlayerList.Length)), "Player List");
                            int playerList = -1;
                            foreach (Player player in PhotonNetwork.PlayerList)
                            {
                                playerList++;
                                GUI.contentColor = RigManager.GetVRRigFromPlayer(player).playerColor;

                                string trueName = player.NickName;

                                if (player.IsMasterClient)
                                    trueName += "-M";

                                GUI.Label(new Rect(2005, 300 + (28 * playerList), 500, 360), trueName);

                                GUI.contentColor = textColors[0];

                                if (player != PhotonNetwork.LocalPlayer)
                                {
                                    if (GUI.Button(new Rect(2075 + (8 * trueName.Length), 300 + (28 * playerList), 40, 25), "Mute"))
                                    {
                                        foreach (GorillaScoreBoard scoreBoard in SafetyShit.leaderBoards)
                                        {
                                            foreach (GorillaPlayerScoreboardLine line in scoreBoard.lines)
                                            {
                                                if (line.playerActorNumber == player.ActorNumber)
                                                    line.PressButton(false, GorillaPlayerLineButton.ButtonType.Mute);
                                            }
                                        }
                                    }

                                    if (GUI.Button(new Rect(2120 + (8 * trueName.Length), 300 + (28 * playerList), 40, 25), "ID"))
                                    {
                                        if (!Directory.Exists("BepInEx/plugins/504Brandon/PLAYER_IDS"))
                                        {
                                            UnityEngine.Debug.Log("MADE PLAYER IDS DIRECTORY");

                                            Directory.CreateDirectory("BepInEx/plugins/504Brandon/PLAYER_IDS");
                                        }

                                        FileUtils.MakeTXTFile("PLAYER_IDS/" + player.NickName + " INFO", player.NickName.ToUpper() + " - " + player.UserId.ToUpper() + "\nCAUGHT IN: " + PhotonNetwork.CurrentRoom.Name.ToUpper(), true);
                                    }
                                }
                            }
                        }
                        else
                        {
                            GUI.Box(new Rect(40, 275, 500, 4.5f + (35 * PhotonNetwork.PlayerList.Length)), "Player List");
                            int playerList = -1;
                            foreach (Player player in PhotonNetwork.PlayerList)
                            {
                                playerList++;

                                GUI.contentColor = RigManager.GetVRRigFromPlayer(player).playerColor;

                                string trueName = player.NickName;

                                if (player.IsMasterClient)
                                    trueName += "-M";

                                GUI.Label(new Rect(40, 300 + (28 * playerList), 500, 360), trueName);

                                GUI.contentColor = textColors[0];

                                if (GUI.Button(new Rect(120 + (8 * trueName.Length), 300 + (28 * playerList), 40, 25), "Mute"))
                                {
                                    foreach (GorillaScoreBoard scoreBoard in SafetyShit.leaderBoards)
                                    {
                                        foreach (GorillaPlayerScoreboardLine line in scoreBoard.lines)
                                        {
                                            if (line.playerActorNumber == player.ActorNumber)
                                                line.PressButton(false, GorillaPlayerLineButton.ButtonType.Mute);
                                        }
                                    }
                                }

                                if (GUI.Button(new Rect(170 + (8 * trueName.Length), 300 + (28 * playerList), 40, 25), "ID"))
                                {
                                    if (!Directory.Exists("BepInEx/plugins/504Brandon/PLAYER_IDS"))
                                    {
                                        UnityEngine.Debug.Log("MADE PLAYER IDS DIRECTORY");

                                        Directory.CreateDirectory("BepInEx/plugins/504Brandon/PLAYER_IDS");
                                    }

                                    FileUtils.MakeTXTFile("PLAYER_IDS/" + player.NickName + " INFO", player.NickName.ToUpper() + " - " + player.UserId.ToUpper() + "\nCAUGHT IN: " + PhotonNetwork.CurrentRoom.Name.ToUpper(), true);
                                }
                            }
                        }
                    }

                        GUI.Label(new Rect(new Rect(10, 1410, 500, 360)), lastRoom + " " + whoReported);

                        // buttons
                        if (GUI.Button(new Rect(2210, 2, 80, 34), "Disconnect")) //cool lol
                        {
                            PhotonNetwork.Disconnect();
                        }
                    }

                    ButtonInfo[] activeButtons = Buttons.buttons[buttonsType].Skip(UIPage * 8).Take(8).ToArray();

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

                        if (rightHanded)
                        {
                            if (GUI.Button(new Rect(2015, 85 + i * 20, 480, 20), buttonText)) //cool lol
                            {
                                Toggle(activeButtons[i].buttonText);
                                Global.playSound(hitSoundValues[hitSoundValue], true, 1);
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect(50, 85 + i * 20, 480, 20), buttonText)) //cool lol
                            {
                                Toggle(activeButtons[i].buttonText);
                                Global.playSound(hitSoundValues[hitSoundValue], true, 1);
                            }
                        }
                    }

                    int lastPage = ((Buttons.buttons[buttonsType].Length + 8 - 1) / 8) - 1;

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

                    if (GetIndex("OG GUI UI").enabled)
                    {
                        GUI.backgroundColor = Color.clear;
                        GUI.contentColor = Color.red;
                    if (rightHanded)
                    {
                        if (GUI.Button(new Rect(2470, 40, 30, 30), "X"))
                        {
                            showGUI = false;
                        }
                    } else
                    {
                        if (GUI.Button(new Rect(510, 40, 30, 30), "X"))
                        {
                            showGUI = false;
                        }
                    }
                }
            } else
            {
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.red;

                if (GUI.Button(new Rect(10, 10, 50, 50), "Open"))
                {
                    showGUI = true;
                }
            }
        }
        Texture2D MenuBGThing(int width, int height)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = GUI.backgroundColor;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}