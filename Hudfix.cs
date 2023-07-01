using System;
using RavenM;
using BepInEx;
using UnityEngine;
using Unity;
using HarmonyLib;
using Ravenfield;

namespace rmspecopshudfixp2
{
    [BepInPlugin("org.personperhaps.hudfix", "hudfix", "1.0.0.0")]
    [BepInDependency("RavenM", BepInDependency.DependencyFlags.HardDependency)]
    public class Hudfix : BaseUnityPlugin
    {
        void Start()
        {
            Debug.Log("UIFIX ACTIVE");
            var harmony = new Harmony("org.personperhaps.hudfix");
            // or implying current assembly:
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(GameManager), "StartGame")]
        public class FinalizeStartPatch
        {
            // Maps sometimes have their own vehicles. We need to tag them.
            static void Prefix()
            {
                if (LobbySystem.instance.InLobby && !LobbySystem.instance.IsLobbyOwner)
                {
                    Debug.Log("NOT HOST");
                    return;
                }
            }
        }
        [HarmonyPatch(typeof(DetectionUi), nameof(DetectionUi.StartDetection))]
        public class StartDetectionPatch
        {
            // Maps sometimes have their own vehicles. We need to tag them.
            static void Prefix()
            {
                if (LobbySystem.instance.InLobby && !LobbySystem.instance.IsLobbyOwner)
                {
                    return;
                }
            }
        }
        [HarmonyPatch(typeof(DetectionBlip), "LateUpdate")]
        public class DetectionBlipPatch
        {
            // Maps sometimes have their own vehicles. We need to tag them.
            static void Prefix()
            {
                if (LobbySystem.instance.InLobby && !LobbySystem.instance.IsLobbyOwner)
                {
                    return;
                }
            }
        }
        [HarmonyPatch(typeof(DetectionIndicator), "LateUpdate")]
        public class DetectionIndicatorPatch
        {
            // Maps sometimes have their own vehicles. We need to tag them.
            static void Prefix()
            {
                if (LobbySystem.instance.InLobby && !LobbySystem.instance.IsLobbyOwner)
                {
                    return;
                }
            }
        }
    }
}
