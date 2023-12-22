using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure
{
    public class GameOverState : GameStateBase
    {
        private LevelFlowProvider _provider;

        public GameOverState(LevelFlowProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelFlow.UIManager.ShowWindow<GameOverWindow>();
        }

        public override void Exit()
        {
            _provider.LevelFlow.UIManager.HideWindow<GameOverWindow>();
        }
    }
}