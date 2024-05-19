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
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace StupidTemplate.Mods
{
    internal class DougAndMattShit
    {
        public static VRRig player;
        public static GameObject GunThingie;
        public static ThrowableBug Bug;
        public static ThrowableBug Bat;

        public static void SetBug()
        {
            if (Bug == null)
            {
                Bug = UnityEngine.GameObject.FindFirstObjectByType<ThrowableBug>();
            }

            try
            {
                if (Bug.photonView.Owner != PhotonNetwork.LocalPlayer)
                    Bug.OnOwnershipTransferred(PhotonNetwork.LocalPlayer, RigManager.GetPlayerFromVRRig(Bug.ownerRig));
            } catch
            {

            }
        }
        public static void BreakBug()
        {
            Bug.allowPlayerStealing = false;
            Bug.maxDistanceFromOriginBeforeRespawn = float.NegativeInfinity;
        }
        public static void FixBug()
        {
            Bug.allowPlayerStealing = true;
            Bug.maxDistanceFromOriginBeforeRespawn = 50;
            Bug.maxNaturalSpeed = 1;
        }
        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Bug.allowPlayerStealing = false;
                Bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                Bug.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
            }
        }
        public static void GiveBug() //lol
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
                Bug.allowPlayerStealing = false;
                Bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                Bug.transform.position = player.leftHandTransform.transform.position;
            }
        }
        public static void FastBug()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Bug.maxNaturalSpeed = 50;
            }
        }

        public static void ControlBug()
        {
            GorillaSnapTurn turning = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<GorillaSnapTurn>();
            turning.turnAmount = 0f;

            Vector2 joy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;

            if (Mathf.Abs(joy.x) > 0.3 || Mathf.Abs(joy.y) > 0.3)
                Bug.transform.position += new Vector3(joy.x - 0.4f, 0f, joy.y - 0.4f);

            Bug.maxNaturalSpeed = 0.01f;
        }
    }
}
