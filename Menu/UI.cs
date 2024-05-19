using UnityEngine;
using BepInEx;
using StupidTemplate.Classes;
using System.Linq;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Menu
{
    [BepInPlugin("504brandon", "504mcgui", "1.0.0")]
    public class UI : BaseUnityPlugin
    {
        // Random
        public static bool showGUI = true;
        public static string whoReported = "NOBODY HAS REPORTED YO GOOFY ASS";
        public static string lastRoom = "HASNT BEEN IN ROOM";
        public void OnGUI()
        {
            if (showGUI)
            {
                GUI.contentColor = textColors[0];
                GUI.backgroundColor = newButtonColors[0];

                if (rightHanded)
                    GUI.Box(new Rect(2005, 40, 500, 360), PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>" + "\n" + "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString());
                else
                    GUI.Box(new Rect(40, 40, 500, 360), PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>" + "\n" + "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString());

                if (rightHanded)
                    GUI.Label(new Rect(new Rect(2005, 380, 500, 360)), descriptionText);
                else
                    GUI.Label(new Rect(new Rect(40, 380, 500, 360)), descriptionText);

                GUI.Label(new Rect(new Rect(10, 1410, 500, 360)), lastRoom + " " + whoReported);

                // buttons
                /*if (GUI.Button(new Rect(50, 90, 100, 20), "Disconnect")) //cool lol
                {
                    PhotonNetwork.Disconnect();
                }

                if (GUI.Button(new Rect(50, 110, 100, 20), "JoinPublic"))
                {
                    PhotonNetwork.JoinRandomRoom();
                }*/

                ButtonInfo[] activeButtons = Buttons.buttons[buttonsType].Skip(pageNumber * 15).Take(15).ToArray();

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

                /*if (UnityInput.Current.GetKey(KeyCode.E))
                {
                    Main.pageNumber++;
                }

                if (UnityInput.Current.GetKey(KeyCode.Q))
                {
                    Main.pageNumber--;
                }*/
            }
        }
    }
}