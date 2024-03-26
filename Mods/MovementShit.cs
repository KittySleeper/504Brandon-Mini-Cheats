using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using GorillaLocomotion;
using UnityEngine.UIElements;
using ExitGames.Client.Photon.StructWrapping;

namespace StupidTemplate.Mods
{
    internal class MovementShit
    {
        public static GameObject platL;
        public static GameObject platR;
        public static GameObject GunThingie;

        public static void PlatformMonk() //imma be honest this took way to long to code the plats wouldent destroy for some reason-
        {
            if (ControllerInputPoller.instance.leftGrab && platL == null)
            {
                platL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                platL.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                platL.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                colorChanger.colorInfo = newBackroundColor;
                colorChanger.Start();
            }
            else if (!ControllerInputPoller.instance.leftGrab && platL != null)
            {
                Object.Destroy(platL);
                platL = null;
            }

            if (ControllerInputPoller.instance.rightGrab && platR == null)
            {
                platR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                platR.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                platR.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                colorChanger.colorInfo = newBackroundColor;
                colorChanger.Start();
            }
            else if (!ControllerInputPoller.instance.rightGrab && platR != null)
            {

                Object.Destroy(platR);
                platR = null;
            }
        }

        public static void FlyMonke()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void NoClip()
        {
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = ControllerInputPoller.instance.leftControllerIndexFloat !> 0.1f;
                }
            }
        }

        public static void TPGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && GunThingie == null)
                {
                    GunThingie = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(GunThingie.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(GunThingie.GetComponent<SphereCollider>());
                    GunThingie.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

                    ColorChanger colorChanger = GunThingie.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = newBackroundColor;
                    colorChanger.Start();
                }
                GunThingie.transform.position = raycastHit.point;
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
                {
                    Player.Instance.transform.position = GunThingie.transform.position;
                }
            }
            else
            {
                Object.Destroy(GunThingie);
            }
        }

        public static void TeleportToRandom()
        {
            foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider.enabled = !ControllerInputPoller.instance.leftControllerPrimaryButton;
            }

            if (ControllerInputPoller.instance.leftControllerPrimaryButton) {
                Player.Instance.transform.position = RigManager.GetRandomVRRig(false).transform.position;
            }
        }
    }
}