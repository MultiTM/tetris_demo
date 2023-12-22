using _Project._Scripts.UI;

namespace _Project._Scripts.Infrastructure
{
    public class MenuState : GameStateBase
    {
        private LevelFlowProvider _provider;

        public MenuState(LevelFlowProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelFlow.Field.Init();
            _provider.LevelFlow.ScoreCounter.Init();
            _provider.LevelFlow.DifficultyManager.UpdateDifficultyLevel();
            _provider.LevelFlow.UIManager.ShowWindow<MenuWindow>();
        }
    }
}