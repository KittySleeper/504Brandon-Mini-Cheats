using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using GorillaLocomotion;
using UnityEngine.UIElements;
using ExitGames.Client.Photon.StructWrapping;

namespace StupidTemplate.Mods
{
    internal class RigShit
    {
        static Vector3 whereRigGo;
        public static GameObject GunThingie;
        public static void FlyGun()
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
                    GorillaTagger.Instance.offlineVRRig.enabled = false;

                    try
                    {
                        GorillaTagger.Instance.myVRRig.enabled = false;
                    }
                    catch
                    {
                    }
                    whereRigGo = GunThingie.transform.position;
                }
            }
            else
            {
                fixRig();
                Object.Destroy(GunThingie);
            }

            if (whereRigGo != null && !GorillaTagger.Instance.offlineVRRig.enabled)
            {
                GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, whereRigGo, (float)0.2);

                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.myVRRig.transform.position, whereRigGo, (float)0.2);
                }
                catch {
                }
            }
        }

        public static void WTFMonke()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
            {
                GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.Set(Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f));
                GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset.Set(Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f));
                GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset.Set(Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f), Random.Range(-0.75f, 0.80f));
                GorillaTagger.Instance.offlineVRRig.transform.rotation.Set(Random.Range(-180, 100), Random.Range(-180, 100), Random.Range(-180, 100), Random.Range(-180, 100));
                GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.Set(Random.Range(-180, 100), Random.Range(-180, 100), Random.Range(-180, 100));
                GorillaTagger.Instance.offlineVRRig.leftHand.trackingRotationOffset.Set(Random.Range(-180, 100), Random.Range(-180, 100), Random.Range(-180, 100));
                GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset.Set(Random.Range(-180, 100), Random.Range(-180, 100), Random.Range(-180, 100));
            }
        }

        public static void spazMonke()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
            {
                GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.Set(Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f));
                GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset.Set(Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f));
                GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset.Set(Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f), Random.Range(-0.10f, 0.10f));
            }
        }

        public static void heliMonke()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position += new Vector3(0, 0.020f, 0);
            GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));

            try
            {
                GorillaTagger.Instance.myVRRig.enabled = false;
                GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                GorillaTagger.Instance.myVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.myVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
            }
            catch {
            }
        }

        public static void lagMonke() //i mean the name explains it
        {
            bool flag = Random.Range(0, 100) >= 75;

            GorillaTagger.Instance.offlineVRRig.enabled = flag;
        }

        public static void ghostMonke()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = ControllerInputPoller.instance.leftControllerPrimaryButton;

            try
            {
                GorillaTagger.Instance.myVRRig.enabled = ControllerInputPoller.instance.leftControllerPrimaryButton;
            }
            catch
            {
            }
        }

        static Vector3 oldLHandTracking = GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset;
        static Vector3 oldRHandTracking = GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset;

        static Vector3 oldLHandTrackingRotation = GorillaTagger.Instance.offlineVRRig.leftHand.trackingRotationOffset;
        static Vector3 oldRHandTrackingRotation = GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset;

        public static void fixRig()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset.Set(0, 0, 0);
            GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset = oldLHandTracking;
            GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset = oldRHandTracking;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.Set(0, 0, 0);
            GorillaTagger.Instance.offlineVRRig.leftHand.trackingRotationOffset = oldLHandTrackingRotation;
            GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset = oldRHandTrackingRotation;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            try
            {
                GorillaTagger.Instance.myVRRig.enabled = true;
            }
            catch
            {
            }
        }
    }
}