using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class GameplayState : GameStateBase
    {
        public override void Enter()
        {
            Debug.Log("Enter gameplay state");
        }

        public override void Exit()
        {
            Debug.Log("Exit gameplay state");
        }
    }
}