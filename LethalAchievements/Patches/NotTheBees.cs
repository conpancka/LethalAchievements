using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(GrabbableObject))]
    internal class NotTheBees
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(GrabbableObject.DiscardItem))]
        static void NotTheBeesPatch(GrabbableObject __instance)
        {
            if (__instance.itemProperties.itemName == "Hive" && __instance.isInShipRoom)
            {
                AchievementManager.NotTheBees();
            }
        }
    }
}