﻿using System;
using System.Media;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using conpancka.Utils;
using LethalAchievements.Patches;
using UnityEngine;
using TerminalApi;
using TerminalApi.Classes;
using static TerminalApi.Events.Events;
using static TerminalApi.TerminalApi;

namespace LethalAchievements
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("atomic.terminalapi", BepInDependency.DependencyFlags.HardDependency)]
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
            TerminalManager.Initialize();

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
                {
                    // command contents
                    mls.LogError("Achievements command ran from terminal");
                    return "ACHIEVEMENT LIST\n\n" +
                           "Enter the name of a certain achievement to view more info about it\n" +
                           "____________________________\n\n\n" +
                           $"Comedy Gold: {AchievementManager.instance.comedyGoldText}\n" +
                           $"Not The Bees!: {AchievementManager.instance.notTheBeesText}\n" +
                           $"" +
                           "\n\n";
                },
                Description = "To view your unlocked achievements.",
                Category = "Other"
            });
            
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }

        public void ShowAchievementPopup(string name, string description, Sprite icon)
        {
            GameObject canvas = GameObject.Find("/Systems/UI/Canvas");
            GameObject popupInstance = Instantiate(achievementPopupPrefab, canvas.transform);
            popupInstance.transform.localScale = Vector3.one * notifScale.Value;
            AchievementPopupUI popupUI = popupInstance.GetComponent<AchievementPopupUI>();
            popupUI.SetDetails(name, description, icon);
            mls.LogInfo($"Loaded achievement popup with the name: '{name}' and the description: '{description}'.");
        }
    }
}