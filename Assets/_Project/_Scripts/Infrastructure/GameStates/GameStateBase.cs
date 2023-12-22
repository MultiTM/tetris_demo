namespace _Project._Scripts.Infrastructure
{
    public class GameStateBase : IGameState
    {
        protected StateMachine<IGameState> _stateMachine;
        
        public void Init(StateMachine<IGameState> stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}