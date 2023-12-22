namespace _Project._Scripts.Infrastructure
{
    public class LevelFlowProvider
    {
        public LevelFlow LevelFlow
        {
            get;
            private set;
        }

        public void InitForLevel(LevelFlow levelFlow)
        {
            LevelFlow = levelFlow;
        }
    }
}