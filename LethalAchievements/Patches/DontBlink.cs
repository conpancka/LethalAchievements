using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(SpringManAI))]
    internal class DontBlink
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        static void DontBlinkPatch(SpringManAI __instance)
        {
            FieldInfo hasStoppedField = typeof(SpringManAI).GetField("hasStopped", BindingFlags.NonPublic | BindingFlags.Instance);
            if (hasStoppedField != null)
            {
                bool hasStopped = (bool)hasStoppedField.GetValue(__instance);
                if (hasStopped)
                {
                    AchievementManager.DontBlink();
                }
            }
        }
    }
}