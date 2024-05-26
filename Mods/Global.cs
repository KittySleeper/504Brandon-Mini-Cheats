using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using GorillaNetworking;
using StupidTemplate.Menu;
using System.Diagnostics;

namespace StupidTemplate.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
        }

        public static void JoinDiscord()
        {
            Process.Start("https://discord.gg/Qfmz6kjhqN");
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

            FileUtils.MakeTXTFile("MODS", ModList);
        }

        public static void DoSettingsShit()
        {
            if (FileUtils.ReadTXTFile("MENU_COLORS") == null)
                FileUtils.MakeTXTFile("MENU_COLORS", mainColor + "\n" + secondColor + "\n" + mainBorderColor + "\n" + secondBorderColor + "\n" + buttonColor + "\n" + buttonEnabledColor + "\n" + buttonTextColor + "\n" + buttonTextEnabledColor);

            mainColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[0]);
            secondColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[1]);
            mainBorderColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[2]);
            secondBorderColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[3]);
            buttonColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[4]);
            buttonEnabledColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[5]);
            buttonTextColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[6]);
            buttonTextEnabledColor = int.Parse(FileUtils.ReadTXTFile("MENU_COLORS").Split("\n")[7]);
            SettingsMods.setTheme();

            if (FileUtils.ReadTXTFile("HITSOUND") == null)
                FileUtils.MakeTXTFile("HITSOUND", "0");

            hitSoundValue = int.Parse(FileUtils.ReadTXTFile("HITSOUND"));

            if (FileUtils.ReadTXTFile("MOVEMENT") == null)
                FileUtils.MakeTXTFile("MOVEMENT", "2\n1\n1\n1");

            platformShapeInt = int.Parse(FileUtils.ReadTXTFile("MOVEMENT").Split("\n")[0]);
            flySpeed = int.Parse(FileUtils.ReadTXTFile("MOVEMENT").Split("\n")[1]);
            veolocityMultiplyer = int.Parse(FileUtils.ReadTXTFile("MOVEMENT").Split("\n")[2]);

            if (FileUtils.ReadTXTFile("themes/BORDERTHEME") == null)
                FileUtils.MakeTXTFile("themes/BORDERTHEME", "0");

            BorderPNGTheme = int.Parse(FileUtils.ReadTXTFile("themes/BORDERTHEME"));

            if (FileUtils.ReadTXTFile("themes/THEME") == null)
                FileUtils.MakeTXTFile("themes/THEME", "0");

            PNGTheme = int.Parse(FileUtils.ReadTXTFile("themes/THEME"));

            if (FileUtils.ReadTXTFile("themes/THEMES") == null)
                FileUtils.MakeTXTFile("themes/THEMES", "Normal");

            if (FileUtils.ReadTXTFile("FONT") == null)
                FileUtils.MakeTXTFile("FONT", "0");

            currentFontNum = int.Parse(FileUtils.ReadTXTFile("FONT"));

            if (FileUtils.ReadTXTFile("MODS") == null)
                FileUtils.MakeTXTFile("MODS", "Should Save Mods\nFPS Counter\nDisconnect Button\nNotifications\nRight Hand\nMenu Border\nAnti Report");

            rightHanded = FileUtils.ReadTXTFile("MODS").Contains("Right Handed");
        }
    }
}
