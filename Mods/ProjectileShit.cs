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

namespace StupidTemplate.Mods
{
    internal class ProjectileShit
    {
        static float projDebounce = 0f;

        static float projDebounceType = 0.1f;
        public static void BetaFireProjectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
        {
            if (Time.time > projDebounce)
            {
                Vector3 startpos = position;
                Vector3 charvel = velocity;

                Vector3 oldVel = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = charvel;
                SnowballThrowable fart = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>();
                Vector3 oldPos = fart.transform.position;
                fart.randomizeColor = true;
                GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(false, color);
                fart.transform.position = startpos;
                fart.projectilePrefab.tag = projectileName;
                fart.OnRelease(null, null);
                fart.transform.position = oldPos;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = oldVel;
                fart.randomizeColor = false;
                fart.projectilePrefab.tag = "WaterballoonProjectile(Clone)";
                if (projDebounceType > 0f && !noDelay)
                {
                    projDebounce = Time.time + projDebounceType;
                }
            }
        }
        public static void projectileSpam(string Projectile = "SnowBall")
        {
            BetaFireProjectile(Projectile, GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.GetComponent<Rigidbody>().velocity, Color.white);
        }
    }
}