using _Project._Scripts.Core.Input;
using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure.GameStates
{
    public class GameplayState : GameStateBase
    {
        private LevelFlowProvider _provider;

        public GameplayState(LevelFlowProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelFlow.InputSwitcher.SwitchInputScheme(InputState.Gameplay);
            _provider.LevelFlow.UIManager.ShowWindow<HUDWindow>();
            _provider.LevelFlow.FieldTicker.StartTick();
        }

        public override void Exit()
        {
            _provider.LevelFlow.FieldTicker.StopTick();
        }
    }
}