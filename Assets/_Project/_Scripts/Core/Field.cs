using System.Linq;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class Field : MonoBehaviour
    {
        private int _width;
        private int _height;
        private FieldCell.Factory _fieldCellFactory;
        private FieldCell[] _cells;
        private Tetramino _activePiece;
        private TetraminoConfig _config;

        [Inject]
        private void Construct(FieldSettings fieldSettings, FieldCell.Factory fieldCellFactory, TetraminoConfig config)
        {
            _width = fieldSettings.Width;
            _height = fieldSettings.Height;
            _fieldCellFactory = fieldCellFactory;
            _config = config;
        }

        public void SetActivePiece(Tetramino piece)
        {
            _activePiece = piece;
            UpdateView();
        }

        [ContextMenu("Tick")]
        public void Tick()
        {
            _activePiece.SetPosition( _activePiece.Position + Vector2Int.down);
            UpdateView();
        }

        [ContextMenu("Rotate")]
        public void RotatePiece()
        {
            _activePiece.Rotate();
            UpdateView();
        }
        
        private void UpdateView()
        {
            var movingCells = _cells.Where(x => x.State == FieldCellState.Moving);
            foreach (var cell in movingCells)   
            {
                cell.SetState(FieldCellState.Empty);
            }

            foreach (var cell in _activePiece.Cells)
            {
                var position = cell + _activePiece.Position;
                if (position.x < 0 || position.y < 0 || position.x >= _width || position.y >= _height)
                {
                    Debug.Log("Skip Render pos: " + position);
                    continue;
                }
                
                Debug.Log("Render pos: " + position);
                _cells[position.x * _height + position.y].SetState(FieldCellState.Moving);
            }
        }

        private void Start()
        {
            CreateCells();
            CreateDebugPiece();
        }

        private void CreateDebugPiece()
        {
            var piece = new Tetramino(TetraminoType.L, _config);
            piece.SetPosition(new Vector2Int(4, 22));
            SetActivePiece(piece);
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
    }
}