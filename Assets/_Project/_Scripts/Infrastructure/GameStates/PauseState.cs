using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class PauseState : GameStateBase
    {
        public override void Enter()
        {
            Debug.Log("Enter pause state");
        }

        public override void Exit()
        {
            Debug.Log("Exit pause state");
        }
    }
}