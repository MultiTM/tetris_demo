using System.Collections.Generic;

namespace _Project._Scripts.Infrastructure
{
    public class Game : StateMachine<IGameState>
    {
        public Game(List<IGameState> states) : base(states)
        {
            InitStates();
            EnterState<BootstrapState>();
        }
        
        private void InitStates()
        {
            foreach (var state in _states)
            {
                state.Init(this);
            }
        }
    }
}