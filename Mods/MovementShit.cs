using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;
using UnityEngine;
using GorillaLocomotion;
using UnityEngine.UIElements;
using ExitGames.Client.Photon.StructWrapping;
using StupidTemplate.Menu;
using UnityEngine.Assertions.Must;
using StupidTemplate.Notifications;

namespace StupidTemplate.Mods
{
    internal class MovementShit
    {
        public static GameObject platL;
        public static GameObject platR;
        public static GameObject GunThingie;

        public static void PlatformMonk() //imma be honest this took way to long to code the plats wouldent destroy for some reason-
        {
            bool[] controls;

            if (GetIndex("Trigger Platforms").enabled)
                controls = new bool[] {ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f, ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f};
            else
                controls = new bool[] {ControllerInputPoller.instance.leftGrab, ControllerInputPoller.instance.rightGrab};

            if (controls[0] && platL == null)
            {
                PrimitiveType[] platformShapeObjects = {PrimitiveType.Cube, PrimitiveType.Cube, PrimitiveType.Sphere};

                platL = GameObject.CreatePrimitive(platformShapeObjects[platformShapeInt]);
                if (platformShapeInt == 1)
                    platL.transform.localScale = new Vector3(0.25f, 0.015f, 0.25f);
                else
                    platL.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                platL.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                platL.GetComponent<Renderer>().forceRenderingOff = GetIndex("Invis Platforms").enabled;

                ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                colorChanger.colorInfo = newBackroundColor;
                colorChanger.Start();
            }
            else if (!controls[0] && platL != null)
            {
                Object.Destroy(platL);
                platL = null;
            }

            if (controls[1] && platR == null)
            {
                PrimitiveType[] platformShapeObjects =  { PrimitiveType.Cube, PrimitiveType.Cube, PrimitiveType.Sphere };

                platR = GameObject.CreatePrimitive(platformShapeObjects[platformShapeInt]);
                if (platformShapeInt == 1)
                    platR.transform.localScale = new Vector3(0.25f, 0.015f, 0.25f);
                else
                    platR.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                platR.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                platR.GetComponent<Renderer>().forceRenderingOff = GetIndex("Invis Platforms").enabled;

                ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                colorChanger.colorInfo = newBackroundColor;
                colorChanger.Start();
            }
            else if (!controls[1] && platR != null)
            {

                Object.Destroy(platR);
                platR = null;
            }
        }

        public static void FlyMonke()
        {
            float[] flySpeeds = {2f, 15f, 50f};
            
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * flySpeeds[flySpeed];
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void NoClip()
        {
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = ControllerInputPoller.instance.leftControllerIndexFloat < 0.1f;
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

               /*GameObject line = new GameObject();
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.startColor = colorChangeables[tracersColor];
                liner.endColor = colorChangeables[tracersColor];
                liner.startWidth = 0.055f;
                liner.endWidth = 0.055f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, Player.Instance.rightControllerTransform.position);
                liner.SetPosition(1, GunThingie.transform.position);
                liner.material.shader = Shader.Find("GUI/Text Shader");
                ColorChanger colorChangerl = line.AddComponent<ColorChanger>();
                colorChangerl.colorInfo = newBackroundColor;
                colorChangerl.Start();
                UnityEngine.Object.Destroy(line, Time.deltaTime);*/

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0f)
                {
                    Player.Instance.transform.position = GunThingie.transform.position;
                    GunThingie.GetComponent<ColorChanger>().colorInfo = new ExtGradient
                    {
                        colors = new GradientColorKey[] {new GradientColorKey(Color.green, 1f)}
                    };
                } else {
                    GunThingie.GetComponent<ColorChanger>().colorInfo = newBackroundColor;
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

        public static void SpeedBoost(float speed)
        {
            Player.Instance.maxJumpSpeed = speed;
            Player.Instance.jumpMultiplier = speed - 1.5f;
        }

        static Vector3 normGrav = Physics.gravity;
        public static void GravityMod(float GravEffect)
        {
            if (ControllerInputPoller.instance.leftGrab)
                Physics.gravity = new Vector3(0f, GravEffect, 0f);
            else
                Physics.gravity = normGrav;
        }
        static float timeTilVeoClick = 0;
        static int veoMode = 0;
        public static void VeoMonk()
        {
            string[] veoModes = {"left", "up", "down", "right"};
            if (Time.time > timeTilVeoClick && ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
            {
                veoMode++;

                if (veoMode > 3)
                    veoMode = 0;

                timeTilVeoClick = Time.time + 0.2f;

                NotifiLib.SendNotification("<color=grey>[</color><color=#ff9400>MOD</color><color=grey>]</color> <color=white> VEOLOCITY IS NOW " + veoModes[veoMode].ToUpper() + "</color>");
            }

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
            {
                if (veoMode == 0)
                    Player.Instance.GetComponent<Rigidbody>().transform.position += Vector3.left * veolocityMultiplyer;

                if (veoMode == 1)
                    Player.Instance.GetComponent<Rigidbody>().transform.position += Vector3.up * veolocityMultiplyer;

                if (veoMode == 2)
                    Player.Instance.GetComponent<Rigidbody>().transform.position += Vector3.down * veolocityMultiplyer;

                if (veoMode == 3)
                    Player.Instance.GetComponent<Rigidbody>().transform.position += Vector3.right * veolocityMultiplyer;
            }
        }
    }
}