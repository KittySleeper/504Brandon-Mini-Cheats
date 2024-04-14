using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using GorillaLocomotion;
using UnityEngine.UIElements;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using StupidTemplate.Notifications;
using StupidTemplate.Menu;

namespace StupidTemplate.Mods
{
    internal class SafetyShit
    {
        static float timerForReconnect = 0;
        static string roomKickedFrom;
        static public GorillaScoreBoard[] leaderBoards;
        public static void RpcFlush()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;

            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }

        public static void AntiReport()
        {
            if (GetIndex("Anti Report Reconnect").enabled)
            {
                if (Time.time >= timerForReconnect)
                {
                    PhotonNetwork.JoinRoom(roomKickedFrom);
                    PhotonNetwork.InRoom.Equals(true);
                    roomKickedFrom = null;
                    timerForReconnect = 0;
                }
            }

            try
            {
                leaderBoards = Object.FindObjectsOfType<GorillaScoreBoard>();

                foreach (GorillaScoreBoard board in leaderBoards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (line.linePlayer == NetworkSystem.Instance.LocalPlayer) {
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    if (Vector3.Distance(vrrig.rightHandTransform.position, line.reportButton.gameObject.transform.position) < 0.35f || Vector3.Distance(vrrig.leftHandTransform.position, line.reportButton.gameObject.transform.position) < 0.35f)
                                    {
                                        PhotonNetwork.Disconnect();
                                        NotifiLib.SendNotification(vrrig.playerText.text + " tried to report you in " + PhotonNetwork.CurrentRoom.Name);
                                        if (GetIndex("Anti Report Reconnect").enabled)
                                        {
                                            NotifiLib.SendNotification("Reconnecting soon...");
                                            roomKickedFrom = PhotonNetwork.CurrentRoom.Name;
                                            timerForReconnect = Time.time + 0.5f;
                                        }
                                        RpcFlush();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}