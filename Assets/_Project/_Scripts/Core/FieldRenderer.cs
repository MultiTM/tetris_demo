using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class FieldRenderer : MonoBehaviour
    {
        [SerializeField] private Transform _cellRoot;
        
        private int _width;
        private int _height;
        private FieldCell.Factory _fieldCellFactory;
        private FieldCell[] _cells;
        private Tetramino _activePiece;

        [Inject]
        private void Construct(FieldCell.Factory fieldCellFactory)
        {
            _fieldCellFactory = fieldCellFactory;
        }

        public void Init(int width, int height)
        {
            _width = width;
            _height = height;
            
            CreateCells();
        }
        
        // To simplify solution we assume that each cell size in (1,1,1) to calculate offset
        private void CreateCells()
        {
            _cells = new FieldCell[_width * _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var cell = _fieldCellFactory.Create();
                    cell.transform.SetParent(_cellRoot);
                    cell.transform.localPosition = new Vector3(x, y, 0);
                    cell.SetState(FieldCellState.Empty);

                    _cells[x * _height + y] = cell;
                }
            }

            var offset = new Vector3(_width / 2f, _height / 2f, 0f) * -1f + new Vector3(0.5f, 0.5f, 0f); // move cell root to center
            _cellRoot.localPosition = offset;
        }

        public void Render(FieldCellState[] cellStates)
        {
            for (int i = 0; i < cellStates.Length; i++)
            {
                var cellView = _cells[i];
                cellView.SetState(cellStates[i]);
            }
        }
    }
}