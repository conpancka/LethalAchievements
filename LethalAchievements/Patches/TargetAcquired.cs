using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace LethalAchievements.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class TargetAcquired
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(PlayerControllerB.KillPlayer))]
        static void TargetAcquiredPatch(Vector3 bodyVelocity, bool spawnBody, CauseOfDeath causeOfDeath, int deathAnimation, Vector3 positionOffset)
        {
            if(causeOfDeath == CauseOfDeath.Gunshots)
            {
                AchievementManager.TargetAcquired();
            }
        }
    }
}