namespace _Project._Scripts.Infrastructure
{
    public interface IGameState : IState
    {
        void Init(StateMachine<IGameState> stateMachine);
    }
}