using GameNetcodeStuff;
using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(ShotgunItem))]
    internal class ThisIsMyBoomstick
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(ShotgunItem.ShootGun))]
        static void ThisIsMyBoomstickPatch()
        {
                AchievementManager.ThisIsMyBoomstick();
        }
    }
}