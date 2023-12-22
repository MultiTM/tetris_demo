using UnityEngine;

namespace _Project._Scripts.Core
{
    public class NextPieceRenderer : MonoBehaviour
    {
        [SerializeField] private FieldRenderer _renderer;
        [SerializeField] private int _width = 6;
        [SerializeField] private int _height = 6;

        private Vector2Int FieldCenter => new Vector2Int(Mathf.RoundToInt(_width / 2f), Mathf.RoundToInt(_height / 2f));

        public void Init()
        {
            _renderer.Init(_width, _height);
        }

        public void Render(Vector2Int[] cells)
        {
            var field = new FieldCellState[_width, _height];
            foreach (var cell in cells)
            {
                var cellPosition = cell + FieldCenter;
                field[cellPosition.x, cellPosition.y] = FieldCellState.Moving;
            }
            
            _renderer.Render(field);
        }
    }
}