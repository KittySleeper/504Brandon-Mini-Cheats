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
        public static void fuckLeaderBoard()
        {
            String[] Names = {"HACKED", "THIS IS MINE", "L LEMMING", "ERROR", "HIDE AWAY", "404", "SEROXEN", "RATTED", "L", "504MINICHEATSONTOPONG", "LEMMING", "PBBV", "STATUE", "DAISY09", "RUN", "ECHO", "Name", "NULL", "gorilla", "???", "HIM", ""};

            int RandomNumber = Random.Range(0, Names.Length);

            Global.SetName(Names[RandomNumber]);
        }

        public static void BanSelf()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }
    }
}
