namespace _Project._Scripts.Infrastructure
{
    public class GameStateBase : IGameState
    {
        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}