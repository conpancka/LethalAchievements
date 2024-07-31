using conpancka.Utils;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GrabObject")]
        static void ComedyGoldPatch(PlayerControllerB __instance)
        {
            Plugin.mls.LogInfo("ComedyGoldPatch invoked.");

            var field = AccessTools.Field(typeof(PlayerControllerB), "currentlyGrabbingObject");
            if (field == null) return;

            var grabbableObject = field.GetValue(__instance) as GrabbableObject;
            if (grabbableObject == null) return;

            Plugin.mls.LogInfo($"itemName: {grabbableObject.itemProperties.itemName}");

            if (grabbableObject.itemProperties.itemName == "Comedy" || grabbableObject.itemProperties.itemName == "Tragedy")
            {
                AchievementManager.instance.ComedyGold();
            }
        }
    }
}
