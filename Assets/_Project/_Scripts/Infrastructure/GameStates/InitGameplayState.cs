namespace _Project._Scripts.Infrastructure.GameStates
{
    public class InitGameplayState : GameStateBase
    {
        private LevelFlowProvider _provider;

        public InitGameplayState(LevelFlowProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            InitGameplay();
            _stateMachine.EnterState<GameplayState>();
        }

        private void InitGameplay()
        {
            _provider.LevelFlow.Field.Init();
            _provider.LevelFlow.ScoreCounter.Init();
            _provider.LevelFlow.DifficultyManager.UpdateDifficultyLevel();
        }
    }
}