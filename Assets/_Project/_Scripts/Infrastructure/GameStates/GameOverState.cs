using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure
{
    public class GameOverState : GameStateBase
    {
        private LevelProgressWatcherProvider _provider;

        public GameOverState(LevelProgressWatcherProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelProgressWatcher.UIManager.ShowWindow<GameOverWindow>();
        }

        public override void Exit()
        {
            _provider.LevelProgressWatcher.UIManager.HideWindow<GameOverWindow>();
        }
    }
}