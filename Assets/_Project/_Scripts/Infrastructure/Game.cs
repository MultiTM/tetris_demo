using System.Collections.Generic;

namespace _Project._Scripts.Infrastructure
{
    public class Game : StateMachine<IGameState>
    {
        public Game(List<IGameState> states) : base(states)
        {
            EnterState<BootstrapState>();
        }
    }
}