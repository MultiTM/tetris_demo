using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class MenuState : GameStateBase
    {
        public override void Enter()
        {
            Debug.Log("Enter menu state");
        }

        public override void Exit()
        {
            Debug.Log("Exit menu state");
        }
    }
}