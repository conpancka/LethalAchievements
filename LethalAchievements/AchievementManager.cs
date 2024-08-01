using conpancka.Utils;
using LethalModDataLib.Attributes;
using LethalModDataLib.Enums;
using UnityEngine;

namespace LethalAchievements
{
    public class AchievementManager
    {
        public static AchievementManager instance;

        // comedy gold
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave, ResetWhen.OnGameOver)]
        private static bool comedyGoldUnlocked = false;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave, ResetWhen.OnGameOver)]
        public static string comedyGoldText = "Locked";
        
        // not the bees
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave, ResetWhen.OnGameOver)]
        private static bool notTheBeesUnlocked = false;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave, ResetWhen.OnGameOver)]
        public static string notTheBeesText = "Locked";
        
        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new AchievementManager();
            }
        }
        
        public static void ComedyGold()
        {
            if (!comedyGoldUnlocked)
            {
                string name = "Comedy Gold";
                string desc = "Find a mask";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("ComedyGold.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                comedyGoldUnlocked = true;
                
                comedyGoldText = "Unlocked";
            }
        }
        
        public static void NotTheBees()
        {
            if (!notTheBeesUnlocked)
            {
                string name = "Not The Bees!";
                string desc = "Successfully complete a hive run";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("NotTheBees.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                notTheBeesUnlocked = true;
                
                notTheBeesText = "Unlocked";
            }
        }
    }
}