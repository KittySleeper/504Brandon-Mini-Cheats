using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using GorillaNetworking;
using StupidTemplate.Menu;

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

        public static void SaveMods()
        {
            string ModList = "";
            foreach (ButtonInfo[] buttons in Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.enabled)
                        ModList += "\n" + button.buttonText;
                }
            }

            TXTHandler.MakeTXTFile("MODS", ModList);
        }

        public static void DoSettingsShit()
        {
            if (TXTHandler.ReadTXTFile("MENU_COLORS") == null)
                TXTHandler.MakeTXTFile("MENU_COLORS", mainColor + "\n" + secondColor + "\n" + buttonColor + "\n" + buttonEnabledColor + "\n" + buttonTextColor + "\n" + buttonTextEnabledColor);

            mainColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[0]);
            secondColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[1]);
            buttonColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[2]);
            buttonEnabledColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[3]);
            buttonTextColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[4]);
            buttonTextEnabledColor = int.Parse(TXTHandler.ReadTXTFile("MENU_COLORS").Split("\n")[5]);
            SettingsMods.setTheme();

            if (TXTHandler.ReadTXTFile("HITSOUND") == null)
                TXTHandler.MakeTXTFile("HITSOUND", "0");

            hitSoundValue = int.Parse(TXTHandler.ReadTXTFile("HITSOUND"));

            if (TXTHandler.ReadTXTFile("MODS") == null)
                TXTHandler.MakeTXTFile("MODS", "Should Save Mods\nFPS Counter\nDisconnect Button\nNotifications\nRight Hand\nAnti Report");

            rightHanded = TXTHandler.ReadTXTFile("MODS").Contains("Right Handed");
        }
    }
}
