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
    internal class WaterShit
    {
        public static void WaterSpam()
        {
            if (ControllerInputPoller.instance.leftGrab)
                WaterSplash(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation, 10f);
            if (ControllerInputPoller.instance.rightGrab)
                WaterSplash(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation, 10f);
        }
        public static void HellaWater()
        {
            WaterSplash(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.rotation, 999999f);
            WaterSplash(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.rotation, 999999f);
            WaterSplash(GorillaTagger.Instance.offlineVRRig.headMesh.transform.position, GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation, 999999f);
        }
        public static void WaterAll()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    WaterSplash(vrrig.leftHandTransform.position, vrrig.leftHandTransform.localRotation, 10f);
                    WaterSplash(vrrig.rightHandTransform.position, vrrig.rightHandTransform.localRotation, 10f);
                }
            }
        }
        public static void WaterSplash(Vector3 position, Quaternion rotation, float size)
        {
            GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", RpcTarget.All, new object[]
            {
                position,
                rotation,
                size,
                10f,
                true,
                true
            });
        }
    }
}
