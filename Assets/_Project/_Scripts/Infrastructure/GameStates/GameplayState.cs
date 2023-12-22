namespace _Project._Scripts.Infrastructure
{
    public class GameplayState : GameStateBase
    {
        private LevelProgressWatcherProvider _provider;

        public GameplayState(LevelProgressWatcherProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelProgressWatcher.FieldTicker.StartTick();
        }

        public override void Exit()
        {
            _provider.LevelProgressWatcher.FieldTicker.StopTick();
        }
    }
}