using HarmonyLib;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(TimeOfDay))]
    internal class EmployeeOfTheMonth
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(TimeOfDay.SetNewProfitQuota))]
        static void EmployeeOfTheMonthPatch()
        {
            AchievementManager.EmployeeOfTheMonth();
        }
    }
}