using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using GorillaNetworking;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
        }

        public static void playSound(int ID = 0, bool left = false, float volume = 0.5f)
        {
            if (PhotonNetwork.InRoom)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]{
                        ID,
                        left,
                        volume
                    });
                SafetyShit.RpcFlush();
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(ID, left, volume);
            }
        }

        public static void SetName(string PlayerName)
        {
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.NickName = PlayerName;
            PhotonNetwork.NetworkingClient.NickName = PlayerName;
            GorillaComputer.instance.currentName = PlayerName;
            GorillaComputer.instance.savedName = PlayerName;
            GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
            GorillaLocomotion.Player.Instance.name = PlayerName;
            PlayerPrefs.SetString("playerName", PlayerName);
            PlayerPrefs.Save();
        }
    }
}
