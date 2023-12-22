using _Project._Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core.Input
{
    public class GameOverInputHandler : InputHandlerBase
    {
        [SerializeField] private KeyCode[] _goToMenuKeys;

        private Game _game;
        
        public override InputState State => InputState.GameOver;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }

        protected override void Update()
        {
            ExecuteOnKeyDown(_goToMenuKeys, () => _game.EnterState<MenuState>());
        }
    }
}