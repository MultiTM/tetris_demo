using System;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class Field
    {
        private int _width;
        private int _height;
        private FieldCellState[] _cells;
        private Tetramino _activePiece;
        private FieldRenderer _renderer;

        [Inject]
        private void Construct(FieldSettings fieldSettings, FieldRenderer renderer)
        {
            _width = fieldSettings.Width;
            _height = fieldSettings.Height;
            _renderer = renderer;
        }

        public void Init()
        {
            InitCells();
            _renderer.Init(_width, _height);
        }

        public void SetActivePiece(Tetramino piece)
        {
            _activePiece = piece;
            Render();
        }

        public void Tick()
        {
            _activePiece.SetPosition( _activePiece.Position + Vector2Int.down);
            Render();
        }

        public void RotatePiece()
        {
            _activePiece.Rotate();
            Render();
        }

        public void MovePiece(Vector2Int direction)
        {
            _activePiece.SetPosition(_activePiece.Position + direction);
            Render();
        }
        
        private void Render()
        {
            UpdateField();
            _renderer.Render(_cells);
        }

        private void UpdateField()
        {
            CleanUpMovingCells();
            UpdatePieceCells();
        }

        private void UpdatePieceCells()
        {
            foreach (var pieceCell in _activePiece.Cells)
            {
                var cellPosition = pieceCell + _activePiece.Position;
                if (cellPosition.x < 0 || cellPosition.y < 0 || cellPosition.x >= _width || cellPosition.y >= _height)
                {
                    continue;
                }

                _cells[cellPosition.x * _height + cellPosition.y] = FieldCellState.Moving;
            }
        }

        private void CleanUpMovingCells()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                if (_cells[i] == FieldCellState.Moving)
                {
                    _cells[i] = FieldCellState.Empty;
                }
            }
        }

        private void InitCells()
        {
            _cells = new FieldCellState[_width * _height];
            Array.Fill(_cells, FieldCellState.Empty);
        }
    }
}