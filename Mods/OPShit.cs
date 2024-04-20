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
using ExitGames.Client.Photon;
using GorillaNetworking;
using Oculus.Platform;
using System.Collections.Generic;
using System;
using Photon.Realtime;

namespace StupidTemplate.Mods
{
    internal class OPShit
    {
        public static VRRig player;
        public static GameObject GunThingie;
        public static void ChangeGamemode(string gamemode = "casual")
        {
            if (gamemode == "infection")
            {
                Hashtable hashtable = new Hashtable { { "gameMode", "forestDEFAULTMODDED_MODDED_INFECTION" } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }
            else if (gamemode == "hunt")
            {
                Hashtable hashtable = new Hashtable { { "gameMode", "forestDEFAULTMODDED_MODDED_HUNTHUNT" } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }
            else
            {
                Hashtable hashtable = new Hashtable { { "gameMode", "forestDEFAULTMODDED_MODDED_CASUALCASUAL" } };
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }
        }

        public static void Lag()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    Hashtable hashtable = new Hashtable();
                    hashtable[0] = player.ActorNumber;
                    PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendReliable);
                    SafetyShit.RpcFlush();
                }
            }
        }

        public static void LagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && GunThingie == null)
                {
                    GunThingie = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(GunThingie.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(GunThingie.GetComponent<SphereCollider>());
                    GunThingie.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                    ColorChanger colorChanger = GunThingie.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = newBackroundColor;
                    colorChanger.Start();
                }
                GunThingie.transform.position = raycastHit.point;
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
                {
                    VRRig possibly = raycastHit.collider.GetComponentInParent<VRRig>();

                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                        player = possibly;

                    GunThingie.GetComponent<ColorChanger>().colorInfo = new ExtGradient
                    {
                        colors = new GradientColorKey[] { new GradientColorKey(Color.green, 1f) }
                    };
                }
                else
                {
                    GunThingie.GetComponent<ColorChanger>().colorInfo = newBackroundColor;
                }
            }
            else
            {
                UnityEngine.Object.Destroy(GunThingie);
            }

            if (player != null) //nah
            {
                Hashtable hashtable = new Hashtable();
                hashtable[(byte)0] = RigManager.GetPlayerFromVRRig(player).ActorNumber;
                PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendReliable);
                SafetyShit.RpcFlush();
            }
        }
    }
}