using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FieldCell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private FieldCellState _state;

        public void SetState(FieldCellState state)
        {
            _state = state;
            UpdateRenderer();
        }

        private void OnValidate()
        {
            SetState(_state);
            _renderer ??= GetComponent<SpriteRenderer>();
        }

        private void UpdateRenderer()
        {
            switch (_state)
            {
                case FieldCellState.Empty:
                    _renderer.color = new Color(1f, 1f, 1f, 0.35f);
                    break;
                case FieldCellState.Moving:
                case FieldCellState.Frozen:
                default:
                    _renderer.color = new Color(1f, 1f, 1f, 1f);
                    break;
            }
        }

        public class Factory : PlaceholderFactory<FieldCell> { }
    }
}