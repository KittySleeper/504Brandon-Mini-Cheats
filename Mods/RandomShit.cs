using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using GorillaLocomotion;
using UnityEngine.UIElements;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using StupidTemplate.Notifications;
using System;
using System.Runtime.InteropServices;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    internal class RandomShit
    {
        static GameObject newQuitBox;
        public static void fuckLeaderBoard()
        {
            /*String[] Names = {"HACKED", "THIS IS MINE", "L LEMMING", "ERROR", "HIDE AWAY", "404", "SEROXEN", "RATTED", "L", "504MINICHEATSONTOPONG", "LEMMING", "PBBV", "STATUE", "DAISY09", "RUN", "ECHO", "Name", "NULL", "gorilla", "???", "HIM", ""};

            int RandomNumber = Random.Range(0, Names.Length);

            Global.SetName(Names[RandomNumber]); will make this fully break leaderboard soon :3*/
        }

        public static void BanSelf()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }

        public static void MakeQuitBoxPlatform()
        {
            GameObject oldStinkyQuitBox = UnityEngine.GameObject.Find("QuitBox");

            if (newQuitBox == null)
            {
                newQuitBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newQuitBox.transform.localScale = oldStinkyQuitBox.transform.localScale + new Vector3(0.10f, 0.10f, 0.10f);
                newQuitBox.transform.position = oldStinkyQuitBox.transform.position;

                ColorChanger colorChanger = newQuitBox.AddComponent<ColorChanger>();
                colorChanger.colorInfo = newBackroundColor;
                colorChanger.Start();
            }
        }

        public static void DeleteQuitBoxPlatform()
        {
            UnityEngine.GameObject.Destroy(newQuitBox);
            newQuitBox = null;
        }
    }
}
