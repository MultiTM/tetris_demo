using _Project._Scripts.UI;

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
            _provider.LevelProgressWatcher.UIManager.ShowWindow<HUDWindow>();
            _provider.LevelProgressWatcher.FieldTicker.StartTick();
        }

        public override void Exit()
        {
            _provider.LevelProgressWatcher.UIManager.HideWindow<HUDWindow>();
            _provider.LevelProgressWatcher.FieldTicker.StopTick();
        }
    }
}