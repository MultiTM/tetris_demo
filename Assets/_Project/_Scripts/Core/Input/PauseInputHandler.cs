using _Project._Scripts.Infrastructure;
using _Project._Scripts.Infrastructure.GameStates;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core.Input
{
    public class PauseInputHandler : InputHandlerBase
    {
        [SerializeField] private KeyCode[] _exitToMenuKeys;
        [SerializeField] private KeyCode[] _resumeKeys;
        [SerializeField] private KeyCode[] _restartKeys;

        private Game _game;
        
        public override InputState State => InputState.Pause;
        
        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }


        protected override void Update()
        {
            ExecuteOnKeyDown(_resumeKeys, () => _game.EnterState<GameplayState>());
            ExecuteOnKeyDown(_restartKeys, () => _game.EnterState<InitGameplayState>());
            ExecuteOnKeyDown(_exitToMenuKeys, () => _game.EnterState<MenuState>());
        }
    }
}