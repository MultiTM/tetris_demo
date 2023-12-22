using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure
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
            _provider.LevelFlow.UIManager.ShowWindow<HUDWindow>();
            _provider.LevelFlow.FieldTicker.StartTick();
        }

        public override void Exit()
        {
            _provider.LevelFlow.UIManager.HideWindow<HUDWindow>();
            _provider.LevelFlow.FieldTicker.StopTick();
        }
    }
}