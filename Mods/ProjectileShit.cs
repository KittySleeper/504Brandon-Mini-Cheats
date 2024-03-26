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

namespace StupidTemplate.Mods
{
    internal class ProjectileShit
    {
        static float projDebounce = 0f;
        static float projDebounceType = 0.1f;
        public static void BetaFireProjectile(string projectileName, Vector3 position, Vector3 velocity)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            if (Time.time > projDebounce)
            {
                try
                {
                    Vector3 startpos = position;
                    Vector3 charvel = velocity;

                    Vector3 oldVel = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                    SnowballThrowable fart = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>();
                    Vector3 oldPos = fart.transform.position;
                    fart.randomizeColor = true;
                    fart.transform.position = startpos;
                    //fart.projectilePrefab.tag = projectileName;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = charvel;
                    //GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, color);
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                    //fart.OnRelease(null, null);
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = oldVel;
                    fart.transform.position = oldPos;
                    fart.randomizeColor = false;
                }
                catch { }
                if (projDebounceType > 0f)
                {
                    projDebounce = Time.time + projDebounceType;
                }
            }
        }

        public static void ShootProjectile()
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0f)
                BetaFireProjectile("Snowball", GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, Player.Instance.currentVelocity + (GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").up));
        }
    }
}