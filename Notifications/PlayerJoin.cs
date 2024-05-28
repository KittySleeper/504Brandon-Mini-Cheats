using HarmonyLib;
using StupidTemplate.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using System.Linq;

namespace StupidTemplate.q_
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class JoinPatch : MonoBehaviour
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                if (Settings.OwnerIDs.Contains(newPlayer.UserId))
                {
                    Settings.adminInGame = true;
                    NotifiLib.SendNotification("<color=grey>[</color><color=#ff9400>OWNER JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                } else if (Settings.AdminIDs.Contains(newPlayer.UserId)) {
                    Settings.adminInGame = true;
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>ADMIN JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                }
                else
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=cyan>JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                }

                oldnewplayer = newPlayer;
            }
        }

        private static Player oldnewplayer;
    }
}