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
        public static void BreakBug()
        {
            ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.allowPlayerStealing = false;
            bug.maxDistanceFromOriginBeforeRespawn = float.NegativeInfinity;
        }
        public static void BreakBat()
        {
            ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.allowPlayerStealing = false;
            bug.maxDistanceFromOriginBeforeRespawn = float.NegativeInfinity;
        }
        public static void FixBug()
        {
            ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.allowPlayerStealing = true;
            bug.maxDistanceFromOriginBeforeRespawn = 50;
            bug.maxNaturalSpeed = 1;
        }
        public static void FixBat()
        {
            ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.allowPlayerStealing = true;
            bug.maxDistanceFromOriginBeforeRespawn = 50;
            bug.maxNaturalSpeed = 1;
        }
        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.allowPlayerStealing = false;
                bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                bug.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
            }
        }

        public static void GrabBat() // may or may not have just copy and pasted the code from the doug statement
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.allowPlayerStealing = false;
                bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                bug.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
            }
        }

        public static void GiveBug()
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
                ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.allowPlayerStealing = false;
                bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                bug.transform.position = player.leftHandTransform.transform.position;
            }
        }

        public static void GiveBat()
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
                ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.allowPlayerStealing = false;
                bug.maxDistanceFromOriginBeforeRespawn = float.PositiveInfinity;
                bug.transform.position = player.leftHandTransform.transform.position;
            }
        }

        public static void FastBug()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.maxNaturalSpeed = 50;
            }
        }

        public static void FastBat()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();

                if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                    bug.photonView.RequestOwnership();

                bug.maxNaturalSpeed = 50;
            }
        }

        public static void ControlBug()
        {
            GorillaSnapTurn turning = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<GorillaSnapTurn>();
            turning.turnAmount = 0f;

            ThrowableBug bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            Vector2 joy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;

            if (Mathf.Abs(joy.x) > 0.3 || Mathf.Abs(joy.y) > 0.3)
                bug.transform.position += new Vector3(joy.x - 0.4f, 0f, joy.y - 0.4f);

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.maxNaturalSpeed = 0.01f;
        }

        public static void ControlBat()
        {
            GorillaSnapTurn turning = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer").GetComponent<GorillaSnapTurn>();
            turning.turnAmount = 0f;

            ThrowableBug bug = GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>();
            Vector2 joy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;

            if (Mathf.Abs(joy.x) > 0.3 || Mathf.Abs(joy.y) > 0.3)
                bug.transform.position += new Vector3(joy.x - 0.4f, 0f, joy.y - 0.4f);

            if (PhotonNetwork.InLobby || PhotonNetwork.InRoom)
                bug.photonView.RequestOwnership();

            bug.maxNaturalSpeed = 0.01f;
        }
    }
}
