using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class GameOverState : GameStateBase
    {
        public override void Enter()
        {
            Debug.Log("Enter game over state");
        }

        public override void Exit()
        {
            Debug.Log("Exit game over state");
        }
    }
}