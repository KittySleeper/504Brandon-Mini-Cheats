using BepInEx;
using StupidTemplate.Menu;
using System.ComponentModel;
using UnityEngine;

namespace StupidTemplate.q_
{
    [Description(StupidTemplate.PluginInfo.Description)]
    [BepInPlugin(StupidTemplate.PluginInfo.GUID, StupidTemplate.PluginInfo.Name, StupidTemplate.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }

        private void Start()
        {
            Debug.Log("started 504");
            GameObject UIHandler = new GameObject();
            UIHandler.AddComponent<UI>();
            UnityEngine.Object.DontDestroyOnLoad(UIHandler);
        }
    }
}
