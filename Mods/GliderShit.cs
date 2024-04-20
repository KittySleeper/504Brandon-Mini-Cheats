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
using StupidTemplate.Menu;
using HarmonyLib;

namespace StupidTemplate.Mods
{
    internal class GliderShit
    {
        public static VRRig player;
        public static GameObject GunThingie;
        public static void TpGlider(bool hold = false)
        {
            foreach (GliderHoldable glider in UnityEngine.GameObject.FindObjectsOfType<GliderHoldable>())
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby && glider.photonView.Owner != PhotonNetwork.LocalPlayer)
                {
                    glider.OnGrab(null, null);
                    glider.OnHover(null, null);
                }

                if (ControllerInputPoller.instance.leftGrab && hold)
                {
                    glider.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                    glider.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation;
                }

                if (ControllerInputPoller.instance.leftGrab && !hold)
                {
                    glider.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                }
            }
        }

        public static void BreakGliders()
        {
            foreach (GliderHoldable glider in UnityEngine.GameObject.FindObjectsOfType<GliderHoldable>())
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby && glider.photonView.Owner != PhotonNetwork.LocalPlayer) {
                    glider.OnGrab(null, null);
                    glider.OnHover(null, null);
                }

                glider.Respawn();
            }
        }

        public static void BlindGun()
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
                    {
                        player = possibly;
                    }
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

            if (player != null)
            {
                foreach (GliderHoldable glider in UnityEngine.GameObject.FindObjectsOfType<GliderHoldable>())
                {
                    if (PhotonNetwork.InRoom || PhotonNetwork.InLobby && glider.photonView.Owner != PhotonNetwork.LocalPlayer)
                    {
                        glider.OnGrab(null, null);
                        glider.OnHover(null, null);
                    }

                    glider.transform.position = player.transform.position;
                }
            }
        }

        public static void GliderGun()
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
                    GliderHoldable glider = GameObject.Find("GliderHoldable").GetComponent<GliderHoldable>();
                    if (PhotonNetwork.InRoom || PhotonNetwork.InLobby && glider.photonView.Owner != PhotonNetwork.LocalPlayer)
                    {
                        glider.OnGrab(null, null);
                        glider.OnHover(null, null);
                    }

                    glider.transform.position = GunThingie.transform.position;

                    GunThingie.GetComponent<ColorChanger>().colorInfo = new ExtGradient
                    {
                        colors = new GradientColorKey[] { new GradientColorKey(Color.green, 1f) }
                    };
                } else {
                    GunThingie.GetComponent<ColorChanger>().colorInfo = newBackroundColor;
                }
            }
            else
            {
                UnityEngine.Object.Destroy(GunThingie);
            }
        }
    }
}
