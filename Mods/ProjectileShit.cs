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
    internal class ProjectileShit //MOST CODE HERE BY ryzr3
    {
        public static int projectileSpeedCycle = 0;
        public static float projectileSpeed = 0f;
        public static int projColorCycle = 0;
        public static float projDelay = 0f;
        public static float projShootDelay = 0.1f;
        public static int projShootDelayCycle = 0;
        public static Color32 projColor = Color.white;
        public static int projCycle = 0;
        public static void Projectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(gameObject, 0.1f);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            gameObject.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
            int[] array = new int[] {
                32,
                204,
                231,
                240,
                249,
                252
            };
            gameObject.AddComponent<GorillaSurfaceOverride>().overrideIndex = array[Array.IndexOf(fullProjectileNames, projectileName)];
            gameObject.GetComponent<Renderer>().enabled = false;
            if (Time.time > projDelay)
            {
                try
                {
                    Vector3 velocity2 = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                    string[] array2 = new string[] {
                        "LMACE.",
                        "LMAEX.",
                        "LMAGD.",
                        "LMAHQ.",
                        "LMAIE.",
                        "LMAIO."
                    };
                    SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + fullProjectileNames[Array.IndexOf(fullProjectileNames, projectileName)] + "LeftAnchor").transform.Find(array2[Array.IndexOf(fullProjectileNames, projectileName)]).GetComponent<SnowballThrowable>();
                    Vector3 position2 = component.transform.position;
                    component.randomizeColor = true;
                    component.transform.position = position;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity;
                    GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, color);
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = velocity2;
                    component.transform.position = position2;
                    component.randomizeColor = false;

                    SafetyShit.RpcFlush();
                }
                catch { }
                if (projShootDelay > 0f && !noDelay) {
                    projDelay = Time.time + projShootDelay;
                }
            }
        }
        public static string[] fullProjectileNames = new string[] {
            "Snowball",
            "WaterBalloon",
            "LavaRock",
            "ThrowableGift",
            "ScienceCandy",
            "FishFood"
        };
        public static void ProjectileSpammer(string projectile = "Snowball", bool randomColor = false)
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                int randomAhhInt = UnityEngine.Random.Range(0, colorChangeablesAmmount);

                if (randomColor)
                    Projectile(projectile, Player.Instance.rightControllerTransform.position, Player.Instance.rightControllerTransform.forward - Player.Instance.rightControllerTransform.up * projectileSpeed, colorChangeables[randomAhhInt], false);
                else
                    Projectile(projectile, Player.Instance.rightControllerTransform.position, Player.Instance.rightControllerTransform.forward - Player.Instance.rightControllerTransform.up * projectileSpeed, projColor, false);
            }
        }
        public static void Urine()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Projectile("Snowball", GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0f), GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f, new Color32(255, 255, 0, 255), false);
            }
        }
        public static void Feces()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Projectile("Snowball", GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.3f, 0f), new Vector3(0f, -1f, 0f), new Color32(99, 43, 0, 255), false);
            }
        }
        public static void Semen()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Projectile("Snowball", GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, -0.15f, 0f), GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f, new Color32(255, 255, 255, 255), false);
            }
        }
        public static void Vomit()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Projectile("Snowball", GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * 0.1f + GorillaTagger.Instance.headCollider.transform.up * -0.15f, GorillaTagger.Instance.headCollider.transform.forward * 8.33f, new Color32(0, 255, 0, 255), false);
            }
        }
    }
}