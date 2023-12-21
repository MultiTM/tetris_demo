using System;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode[] _moveLeftKeys;
        [SerializeField] private KeyCode[] _moveRightKeys;
        [SerializeField] private KeyCode[] _rotateKeys;

        private Field _field;

        [Inject]
        private void Construct(Field field)
        {
            _field = field;
        }

        private void Update()
        {
            ExecuteOnAnyKeyDown(_rotateKeys, () => _field.TryRotatePiece());
            ExecuteOnAnyKeyDown(_moveLeftKeys, () => _field.TryMovePiece(Vector2Int.left));
            ExecuteOnAnyKeyDown(_moveRightKeys, () => _field.TryMovePiece(Vector2Int.right));
        }

        private void ExecuteOnAnyKeyDown(KeyCode[] keys, Action action)
        {
            foreach (var key in keys)   
            {
                if (Input.GetKeyDown(key))
                {
                    action?.Invoke();
                    return;
                }
            }
        }
    }
}