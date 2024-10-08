﻿using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using conpancka.Utils;
using LethalModDataLib.Attributes;
using LethalModDataLib.Enums;
using UnityEngine;
using TerminalApi.Classes;
using static TerminalApi.TerminalApi;

namespace LethalAchievements
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("atomic.terminalapi", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("MaxWasUnavailable.LethalModDataLib", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "conpancka.LethalAchievements";
        private const string modName = "Lethal Achievements";
        private const string modVersion = "1.0.0";
        private readonly Harmony harmony = new Harmony(modGUID);
        public static Plugin instance;
        internal static ManualLogSource mls;

        private const string assetBundleName = "achievementpopupbundle";
        private const string prefabName = "AchievementPopup";

        private AssetBundle assetBundle;
        private GameObject achievementPopupPrefab;

        private ConfigEntry<float> notifScale;
        public ConfigEntry<bool> soundOn;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            
            AchievementManager.Initialize();

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            
            mls.LogInfo("Loading Asset Bundle...");
            assetBundle = AssetUtils.LoadAssetBundleFromEmbeddedResources(assetBundleName);
            achievementPopupPrefab = assetBundle.LoadAsset<GameObject>(prefabName);

            notifScale = base.Config.Bind(
                "General",
                "NotificationScale",
                0.4f,
                "The scale of the notification popup on screen"
            );

            soundOn = base.Config.Bind(
                "General",
                "NotificationSoundOn",
                true,
                "Set to true if you want it to play sound when you get an achievement, or set to false if you don't want the sound"
            );
            
            AddCommand("Achievements", new CommandInfo()
            {
                DisplayTextSupplier = () =>
                    "ACHIEVEMENT LIST\n\n" +
                    "View your locked and unlocked achievements\n\n" +
                    "Achievement Completion: " + Percentage() + "%\n" +
                    "____________________________\n\n\n" +
                    $"Not The Bees!: {AchievementManager.notTheBeesText}\n" +
                    $"Target Acquired: {AchievementManager.targetAcquiredText}\n" +
                    $"Comedy Gold: {AchievementManager.comedyGoldText}\n" +
                    $"Employee Of The Month: {AchievementManager.employeeOfTheMonthText}\n" +
                    $"Pest Control: {AchievementManager.pestControlText}\n" +
                    $"This, Is My Boomstick!: {AchievementManager.thisIsMyBoomstickText}\n" +
                    $"Don't Blink: {AchievementManager.dontBlinkText}\n" +
                    $"You Monster!: {AchievementManager.youMonsterText}" +
                    "\n\n",
                Description = "To view your unlocked achievements.",
                Category = "Other"
            });
            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
            mls.LogInfo($"{modName} version {modVersion} has been loaded!");
        }

        public void ShowAchievementPopup(string name, string description, Sprite icon)
        {
            GameObject canvas = GameObject.Find("/Systems/UI/Canvas");
            GameObject popupInstance = Instantiate(achievementPopupPrefab, canvas.transform);
            popupInstance.transform.localScale = Vector3.one * notifScale.Value;
            AchievementPopupUI popupUI = popupInstance.GetComponent<AchievementPopupUI>();
            popupUI.SetDetails(name, description, icon);
        }

        private static string Percentage() => ((int)(0.5f + ((100f * AchievementManager.completion) / 8f))).ToString();
    }
}