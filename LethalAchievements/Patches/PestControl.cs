using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class PestControl
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(HoarderBugAI.KillEnemy))]
        static void PestControlPatch()
        {
            AchievementManager.PestControl();
        }
    }
}