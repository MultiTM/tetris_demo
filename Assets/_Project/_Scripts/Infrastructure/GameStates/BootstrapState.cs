using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class BootstrapState : GameStateBase
    {
        public override void Enter()
        {
            Debug.Log("Enter bootstrap state");
        }

        public override void Exit()
        {
            Debug.Log("Exit bootstrap state");
        }
    }
}