using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class FieldRenderer : MonoBehaviour
    {
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
        
        private void CreateCells()
        {
            _cells = new FieldCell[_width * _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var cell = _fieldCellFactory.Create();
                    cell.transform.SetParent(transform);
                    cell.transform.localPosition = new Vector3(x, y, 0);
                    cell.SetState(FieldCellState.Empty);

                    _cells[x * _height + y] = cell;
                }
            }
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