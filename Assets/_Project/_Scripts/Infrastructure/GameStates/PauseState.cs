using _Project._Scripts.Core.Input;

namespace _Project._Scripts.Infrastructure
{
    public class PauseState : GameStateBase
    {
        private LevelFlowProvider _provider;
        
        public PauseState(LevelFlowProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelFlow.InputSwitcher.SwitchInputScheme(InputState.Pause);
        }
    }
}