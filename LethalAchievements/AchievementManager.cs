using conpancka.Utils;
using UnityEngine;

namespace LethalAchievements
{
    public class AchievementManager
    {
        public static AchievementManager instance;

        private bool comedyGoldUnlocked = false;
        public string comedyGoldText = "Locked";
        
        private bool notTheBeesUnlocked = false;
        public string notTheBeesText = "Locked";
        
        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new AchievementManager();
            }
        }
        
        public void ComedyGold()
        {
            if (!comedyGoldUnlocked)
            {
                string name = "Comedy Gold";
                string desc = "Find a mask";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("ComedyGold.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                comedyGoldUnlocked = true;
            }
            else
            {
                Plugin.mls.LogWarning("Comedy Gold achievement is already unlocked!");

                comedyGoldText = "Unlocked";
            }
        }
        
        public void NotTheBees()
        {
            if (!comedyGoldUnlocked)
            {
                string name = "Not The Bees!";
                string desc = "Successfully complete a hive run";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("NotTheBees.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                comedyGoldUnlocked = true;
            }
            else
            {
                Plugin.mls.LogWarning("Comedy Gold achievement is already unlocked!");

                comedyGoldText = "Unlocked";
            }
        }
    }
}