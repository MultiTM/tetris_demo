using System;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class Field
    {
        private int _width;
        private int _height;
        private FieldCellState[,] _cells;
        private Tetramino _activePiece;
        private FieldRenderer _renderer;
        private PieceGenerator _pieceGenerator;

        [Inject]
        private void Construct(FieldSettings fieldSettings, FieldRenderer renderer, PieceGenerator pieceGenerator)
        {
            _width = fieldSettings.Width;
            _height = fieldSettings.Height;
            _renderer = renderer;
            _pieceGenerator = pieceGenerator;
        }

        public void Init()
        {
            InitCells();
            _renderer.Init(_width, _height);
            RequestActivePiece();
        }

        public void SetActivePiece(Tetramino piece)
        {
            _activePiece = piece;
            _activePiece.SetPosition(new Vector2Int(Mathf.RoundToInt(_width / 2f), _height - 2));
            Debug.Log(_activePiece.Position);
            Render();
        }

        public void Tick()
        {
            MovePiece(Vector2Int.down);
            CheckForFreezePiece();
            Render();
        }

        private void CheckForFreezePiece()
        {
            foreach (var pieceCell in _activePiece.Cells)
            {
                var cellPosition = pieceCell + _activePiece.Position;
                var isBottomLine = cellPosition.y == 0;
                if (isBottomLine)
                {
                    FreezeActivePiece();
                    return;
                }
                
                var isBlockUnder = _cells[cellPosition.x, cellPosition.y - 1] == FieldCellState.Frozen;
                if (isBlockUnder)
                {
                    FreezeActivePiece();
                    return;
                }
            }
        }

        private void FreezeActivePiece()
        {
            foreach (var pieceCell in _activePiece.Cells)
            {
                var cellPosition = pieceCell + _activePiece.Position;
                _cells[cellPosition.x, cellPosition.y] = FieldCellState.Frozen;
            }

            RequestActivePiece();
        }

        private void RequestActivePiece()
        {
            SetActivePiece(_pieceGenerator.GetRandomPiece());
        }

        public void RotatePiece()
        {
            // TODO: check is rotation possible
            _activePiece.Rotate();
            Render();
        }

        public void MovePiece(Vector2Int direction)
        {
            if (!CanMove(direction))
            {
                return;
            }
            
            _activePiece.SetPosition(_activePiece.Position + direction);
            Render();
        }

        private bool CanMove(Vector2Int direction)
        {
            foreach (var pieceCell in _activePiece.Cells)
            {
                var cellPosition = pieceCell + _activePiece.Position + direction;
                if (cellPosition.x < 0 || cellPosition.y < 0 || cellPosition.x >= _width || cellPosition.y >= _height)
                {
                    return false;
                }

                if (_cells[cellPosition.x, cellPosition.y] == FieldCellState.Frozen)
                {
                    return false;
                }
            }

            return true;
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
                if (_cells[cellPosition.x, cellPosition.y] == FieldCellState.Frozen)
                {
                    FreezeActivePiece();
                    return;
                }
                
                _cells[cellPosition.x, cellPosition.y] = FieldCellState.Moving;
            }
        }

        private void CleanUpMovingCells()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (_cells[x, y] == FieldCellState.Moving)
                    {
                        _cells[x, y] = FieldCellState.Empty;
                    }
                }
            }
        }

        private void InitCells()
        {
            _cells = new FieldCellState[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _cells[x, y] = FieldCellState.Empty;
                }
            }
        }
    }
}