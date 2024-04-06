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

namespace StupidTemplate.Mods
{
    internal class ProjectileShit
    {
        static float projDebounce = 0f;

        static float projDebounceType = 0.1f;
        public static void SlingshotSpam()
        {
            bool rightGrab = ControllerInputPoller.instance.rightGrab;
            if (rightGrab)
            {
                Vector3 position = Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = Player.Instance.currentVelocity;
                Vector3 forward = Player.Instance.rightControllerTransform.transform.forward;
                BetaFireProjectile("SlingshotProjectile", position, forward, new Color32(250, 250, 250, byte.MaxValue), false);
            }
            bool leftGrab = ControllerInputPoller.instance.leftGrab;
            if (leftGrab)
            {
                Vector3 position2 = Player.Instance.leftControllerTransform.transform.position;
                Vector3 currentVelocity2 = Player.Instance.currentVelocity;
                Vector3 forward2 = Player.Instance.leftControllerTransform.transform.forward;
                BetaFireProjectile("SlingshotProjectile", position2, forward2, new Color32(250, 250, 250, byte.MaxValue), false);
            }
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00004718 File Offset: 0x00002918
        public static void BetaFireProjectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
        {
            bool flag = Time.time > projDebounce;
            if (flag)
            {
                Vector3 velocity2 = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity;
                SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>();
                Vector3 position2 = component.transform.position;
                component.randomizeColor = true;
                GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(false, color);
                component.transform.position = position;
                component.projectilePrefab.tag = projectileName;
                component.OnRelease(null, null);
                SafetyShit.RpcFlush();
                component.transform.position = position2;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity2;
                component.randomizeColor = false;
                component.projectilePrefab.tag = "SnowballProjectile";
                bool flag2 = projDebounceType > 0f && !noDelay;
                if (flag2)
                {
                    projDebounce = Time.time + projDebounceType;
                }
            }
        }
    }
}