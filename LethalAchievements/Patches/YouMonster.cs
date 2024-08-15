using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(Shovel))]
    internal class YouMonster
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Shovel.HitShovel))]
        static void YouMonsterPatch()
        {
            // trigger if hit player
            AchievementManager.YouMonster();
        }
    }
}