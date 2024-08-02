using conpancka.Utils;
using UnityEngine;

namespace LethalAchievements
{
    public class AchievementManager
    {
        public static AchievementManager instance;

        // comedy gold
        private static bool comedyGoldUnlocked;
        public static string comedyGoldText = "Locked";
        
        // not the bees
        private static bool notTheBeesUnlocked;
        public static string notTheBeesText = "Locked";
        
        // employee of the month
        private static bool employeeOfTheMonthUnlocked;
        public static string employeeOfTheMonthText = "Locked";
        
        // target acquired
        private static bool targetAcquiredUnlocked;
        public static string targetAcquiredText = "Locked";
        
        // this is my boomstick
        private static bool thisIsMyBoomstickUnlocked;
        public static string thisIsMyBoomstickText = "Locked";
        
        // pest control
        private static bool pestControlUnlocked;
        public static string pestControlText = "Locked";
        
        
        
        // pest control
        private static bool pieceOfCakeUnlocked;
        public static string pieceOfCakeText = "Locked";
        
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
        
        public static void EmployeeOfTheMonth()
        {
            if (!employeeOfTheMonthUnlocked)
            {
                string name = "Employee Of The Month";
                string desc = "Complete your first quota";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("EmployeeOfTheMonth.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                employeeOfTheMonthUnlocked = true;
                
                employeeOfTheMonthText = "Unlocked";
            }
        }
        
        public static void TargetAcquired()
        {
            if (!targetAcquiredUnlocked)
            {
                string name = "Target Acquired";
                string desc = "Get killed by a turret";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("TargetAcquired.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                targetAcquiredUnlocked = true;
                
                targetAcquiredText = "Unlocked";
            }
        }
        
        public static void ThisIsMyBoomstick()
        {
            if (!thisIsMyBoomstickUnlocked)
            {
                string name = "This, Is My Boomstick!";
                string desc = "Fire a Nutcracker's shotgun";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("ThisIsMyBoomstick.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                thisIsMyBoomstickUnlocked = true;
                
                thisIsMyBoomstickText = "Unlocked";
            }
        }
        
        public static void PestControl()
        {
            if (!pestControlUnlocked)
            {
                string name = "Pest Control";
                string desc = "Kill a hoarding bug";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("PestControl.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                pestControlUnlocked = true;
                
                pestControlText = "Unlocked";
            }
        }
        
        
        
        
        public static void PieceOfCake()
        {
            if (comedyGoldUnlocked || notTheBeesUnlocked || employeeOfTheMonthUnlocked || targetAcquiredUnlocked || thisIsMyBoomstickUnlocked || pestControlUnlocked/*|| MORE THINGS*/)
            {
                if (!pieceOfCakeUnlocked)
                {
                    string name = "Piece Of Cake";
                    string desc = "Unlock every other achievement";
                    Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("PieceOfCake.png");

                    Plugin.instance.ShowAchievementPopup(name, desc, icon);

                    pieceOfCakeUnlocked = true;

                    pieceOfCakeText = "Unlocked";
                }
            }
        }
    }
}