using GameNetcodeStuff;
using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class ComedyGold
    {
        [HarmonyPostfix]
        [HarmonyPatch("GrabObject")]
        static void ComedyGoldPatch(PlayerControllerB __instance)
        {
            var field = AccessTools.Field(typeof(PlayerControllerB), "currentlyGrabbingObject");
            if (field == null) return;

            var grabbableObject = field.GetValue(__instance) as GrabbableObject;
            if (grabbableObject == null) return;

            if (grabbableObject.itemProperties.itemName == "Comedy" || grabbableObject.itemProperties.itemName == "Tragedy")
            {
                AchievementManager.ComedyGold();
            }
        }
    }
}
