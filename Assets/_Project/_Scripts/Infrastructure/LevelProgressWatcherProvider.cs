namespace _Project._Scripts.Infrastructure
{
    public class LevelProgressWatcherProvider
    {
        public LevelProgressWatcher LevelProgressWatcher
        {
            get;
            private set;
        }

        public void InitForLevel(LevelProgressWatcher levelProgressWatcher)
        {
            LevelProgressWatcher = levelProgressWatcher;
        }
    }
}