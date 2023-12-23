using _Project._Scripts.Core.Input;
using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure.GameStates
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
            _provider.LevelFlow.InputSwitcher.SwitchInputScheme(InputState.GameOver);
            _provider.LevelFlow.UIManager.ShowWindow<GameOverWindow>();
        }
    }
}