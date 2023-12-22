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
        private FieldCell[,] _cells;
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
            RemoveCells();
            _cells = new FieldCell[_width, _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var cell = _fieldCellFactory.Create();
                    cell.transform.SetParent(_cellRoot);
                    cell.transform.localPosition = new Vector3(x, y, 0);
                    cell.SetState(FieldCellState.Empty);

                    _cells[x, y] = cell;
                }
            }

            // move cell root to center
            var offset = new Vector3(_width / 2f, _height / 2f, 0f) * -1f
                         + new Vector3(0.5f, 0.5f, 0f);
            _cellRoot.localPosition = offset;
        }

        private void RemoveCells()
        {
            var childCount = _cellRoot.childCount;
            if (childCount == 0)
            {
                return;
            }
            
            for (int i = childCount - 1; i >= 0; i--)
            {
                Destroy(_cellRoot.GetChild(i).gameObject);
            }
        }

        public void Render(FieldCellState[,] cellStates)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var cellView = _cells[x, y];
                    cellView.SetState(cellStates[x, y]);
                }
            }
        }
    }
}