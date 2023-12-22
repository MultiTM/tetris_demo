using UnityEngine;

namespace _Project._Scripts.Infrastructure
{
    public class MenuState : GameStateBase
    {
        private LevelProgressWatcherProvider _provider;

        public MenuState(LevelProgressWatcherProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.LevelProgressWatcher.Field.Init();
            
            _stateMachine.EnterState<GameplayState>();
        }

    }
}