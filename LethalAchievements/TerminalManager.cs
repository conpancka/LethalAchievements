namespace LethalAchievements
{
    public class TerminalManager
    {
        public static AchievementManager instance;

        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new AchievementManager();
            }
        }
    }
}