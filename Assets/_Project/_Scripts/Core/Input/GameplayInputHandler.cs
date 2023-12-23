using _Project._Scripts.Infrastructure;
using _Project._Scripts.Infrastructure.GameStates;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core.Input
{
    public class GameplayInputHandler : InputHandlerBase
    {
        [SerializeField] private KeyCode[] _moveLeftKeys;
        [SerializeField] private KeyCode[] _moveRightKeys;
        [SerializeField] private KeyCode[] _rotateKeys;
        [SerializeField] private KeyCode[] _dropKeys;
        [SerializeField] private KeyCode[] _pauseKeys;

        private Field _field;
        private Game _game;
        
        public override InputState State => InputState.Gameplay;
        
        [Inject]
        private void Construct(Field field, Game game)
        {
            _field = field;
            _game = game;
        }

        protected override void Update()
        {
            ExecuteOnKeyDown(_rotateKeys, () => _field.TryRotatePiece());
            ExecuteOnKeyDown(_moveLeftKeys, () => _field.TryMovePiece(Vector2Int.left));
            ExecuteOnKeyDown(_moveRightKeys, () => _field.TryMovePiece(Vector2Int.right));
            ExecuteOnKeyDown(_dropKeys, () => _field.DropPiece());
            ExecuteOnKeyDown(_pauseKeys, () => _game.EnterState<PauseState>());
        }
    }
}