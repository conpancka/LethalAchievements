using conpancka.Utils;
using LethalModDataLib.Attributes;
using LethalModDataLib.Enums;
using UnityEngine;

namespace LethalAchievements
{
    public class AchievementManager
    {
        private static AchievementManager instance;

        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static int completion = 0;
        
        // comedy gold
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool comedyGoldUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string comedyGoldText = "Locked";
        
        // not the bees
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool notTheBeesUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string notTheBeesText = "Locked";
        
        // employee of the month
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool employeeOfTheMonthUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string employeeOfTheMonthText = "Locked";
        
        // target acquired
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool targetAcquiredUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string targetAcquiredText = "Locked";
        
        // this is my boomstick
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool thisIsMyBoomstickUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string thisIsMyBoomstickText = "Locked";
        
        // pest control
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool pestControlUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string pestControlText = "Locked";
        
        // dont blink
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool dontBlinkUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string dontBlinkText = "Locked";
        
        // you monster
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        private static bool youMonsterUnlocked;
        [ModData(SaveWhen.OnSave, LoadWhen.OnLoad, SaveLocation.CurrentSave)]
        public static string youMonsterText = "Locked";
        
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

                completion++;
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
                
                completion++;
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
                
                completion++;
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
                
                completion++;
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
                
                completion++;
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
                
                completion++;
            }
        }
        
        public static void DontBlink()
        {
            if (!dontBlinkUnlocked)
            {
                string name = "Don't Blink";
                string desc = "Spot a Coilhead";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("DontBlink.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                dontBlinkUnlocked = true;
                
                dontBlinkText = "Unlocked";
                
                completion++;
            }
        }
        
        public static void YouMonster()
        {
            if (!youMonsterUnlocked)
            {
                string name = "You Monster!";
                string desc = "Hit another crewmate with a shovel";
                Sprite icon = AssetUtils.LoadSpriteFromEmbeddedResources("YouMonster.png");

                Plugin.instance.ShowAchievementPopup(name, desc, icon);
                
                youMonsterUnlocked = true;
                
                youMonsterText = "Unlocked";
                
                completion++;
            }
        }
    }
}