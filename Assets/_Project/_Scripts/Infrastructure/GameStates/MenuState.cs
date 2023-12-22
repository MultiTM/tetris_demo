using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class MenuState : GameStateBase
    {
        public override void Enter()
        {
            _stateMachine.EnterState<GameplayState>();
        }

    }
}