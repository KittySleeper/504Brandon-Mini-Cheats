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

namespace StupidTemplate.Menu
{
    [BepInPlugin("504brandon", "504mcgui", "1.0.0")]
    public class UI : BaseUnityPlugin
    {
        // Random
        public static bool showGUI = true;
        public static string whoReported = "NOBODY HAS REPORTED YO GOOFY ASS";
        public static string lastRoom = "HASNT BEEN IN ROOM";
        public static int UIPage = 0;
        public static float leftCooldown = 0;
        public static float rightCooldown = 0;
        public void OnGUI()
        {
            if (showGUI)
            {
                GUI.contentColor = textColors[0];
                GUI.backgroundColor = newButtonColors[0];

                if (rightHanded)
                    GUI.Box(new Rect(2005, 40, 500, 230), PluginInfo.Name + " <color=grey>[</color><color=white>" + (UIPage + 1).ToString() + "</color><color=grey>]</color>" + "\n" + "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString());
                else
                    GUI.Box(new Rect(40, 40, 500, 230), PluginInfo.Name + " <color=grey>[</color><color=white>" + (UIPage + 1).ToString() + "</color><color=grey>]</color>" + "\n" + "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString());

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
                            if (player.IsMasterClient)
                                GUI.contentColor = Color.cyan;
                            else
                                GUI.contentColor = textColors[0];

                            GUI.Label(new Rect(new Rect(2005, 300 + (28 * playerList), 500, 360)), player.NickName);

                            GUI.contentColor = textColors[0];

                            if (player != PhotonNetwork.LocalPlayer)
                            {
                                if (GUI.Button(new Rect(2075 + (8 * player.NickName.Length), 300 + (28 * playerList), 40, 25), "Mute"))
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

                                if (GUI.Button(new Rect(2120 + (8 * player.NickName.Length), 300 + (28 * playerList), 40, 25), "ID"))
                                {
                                    TXTHandler.MakeTXTFile(player.NickName + " INFO", player.NickName.ToUpper() + " - " + player.UserId.ToUpper() + "\nCAUGHT IN: " + PhotonNetwork.CurrentRoom.Name.ToUpper(), true);
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
                            if (player.IsMasterClient)
                                GUI.contentColor = Color.cyan;
                            else
                                GUI.contentColor = textColors[0];
                            GUI.Label(new Rect(new Rect(40, 300 + (28 * playerList), 500, 360)), player.NickName);

                            GUI.contentColor = textColors[0];

                            if (GUI.Button(new Rect(120 + (8 * player.NickName.Length), 300 + (28 * playerList), 40, 25), "Mute"))
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

                            if (GUI.Button(new Rect(170 + (8 * player.NickName.Length), 300 + (28 * playerList), 40, 25), "ID"))
                            {
                                TXTHandler.MakeTXTFile(player.NickName + " INFO", player.NickName.ToUpper() + " - " + player.UserId.ToUpper() + "\nCAUGHT IN: " + PhotonNetwork.CurrentRoom.Name.ToUpper(), true);
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

                    if (rightHanded)
                    {
                        if (GUI.Button(new Rect(2015, 85 + i * 20, 480, 20), activeButtons[i].buttonText)) //cool lol
                        {
                            Toggle(activeButtons[i].buttonText);
                            Global.playSound(hitSoundValues[hitSoundValue], true, 1);
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(50, 85 + i * 20, 480, 20), activeButtons[i].buttonText)) //cool lol
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
            }
        }
    }
}