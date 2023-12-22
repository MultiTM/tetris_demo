using System;
using System.Linq;
using _Project._Scripts.Utils;
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
        private PieceQueue _pieceQueue;

        private Vector2Int PieceSpawnPoint => new Vector2Int(Mathf.RoundToInt(_width / 2f), _height - 1); // top center
        
        public event Action OnGameOver;

        [Inject]
        private void Construct(FieldSettings fieldSettings, FieldRenderer renderer, PieceQueue pieceQueue)
        {
            _width = fieldSettings.Width;
            _height = fieldSettings.Height;
            _renderer = renderer;
            _pieceQueue = pieceQueue;
        }

        public void Init()
        {
            InitCells();
            _pieceQueue.Init();
            _renderer.Init(_width, _height);
            
            RequestActivePiece();
        }

        public void SpawnPiece(Tetramino piece)
        {
            piece.SetPosition(PieceSpawnPoint);
            var cells = piece.Cells.Select(x => x + piece.Position).ToArray();
            if (!CanBePlaced(cells))
            {
                OnGameOver?.Invoke();
                return;
            }
            
            _activePiece = piece;
        }

        public void Tick()
        {
            TryMovePiece(Vector2Int.down);
            TryFreezePiece();
            TryRemoveLines();
            Render();
        }
        
        public void TryRotatePiece()
        {
            if (!CanRotate())
            {
                return;
            }
            _activePiece.Rotate();
            Render();
        }

        public void TryMovePiece(Vector2Int direction)
        {
            if (!CanMove(direction))
            {
                return;
            }
            
            _activePiece.SetPosition(_activePiece.Position + direction);
            Render();
        }

        public void DropPiece()
        {
            while (CanMove(Vector2Int.down))
            {
                TryMovePiece(Vector2Int.down);
            }
        }

        private void TryRemoveLines()
        {
            var fullLineIndex = GetFullLineIndex();
            if (fullLineIndex == -1)
            {
                return;
            }

            while (fullLineIndex != -1)
            {
                RemoveFullLine(fullLineIndex);
                MoveFieldDown(fullLineIndex);
                
                fullLineIndex = GetFullLineIndex();
            }
        }

        private void RemoveFullLine(int fullLineIndex)
        {
            for (int x = 0; x < _width; x++)
            {
                _cells[x, fullLineIndex] = FieldCellState.Empty;
            }
        }

        private void MoveFieldDown(int fullLineIndex)
        {
            for (int y = fullLineIndex; y < _height - 1; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _cells[x, y] = _cells[x, y + 1];
                }
            }
        }

        private int GetFullLineIndex()
        {
            for (int y = 0; y < _height; y++)
            {
                var isLineFull = true;
                for (int x = 0; x < _width; x++)
                {
                    if (_cells[x, y] != FieldCellState.Frozen)
                    {
                        isLineFull = false;
                        break;
                    }
                }

                if (isLineFull)
                {
                    return y;
                }
            }
            
            return -1;
        }

        private void TryFreezePiece()
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
            SpawnPiece(_pieceQueue.GetPiece());
        }

        private bool CanRotate()
        {
            var cellPositions = new Vector2Int[_activePiece.Cells.Length];
            for (int i = 0; i < _activePiece.Cells.Length; i++)
            {
                cellPositions[i] = _activePiece.Cells[i];
            }

            cellPositions = TetraminoRotator.Rotate(cellPositions);
            for (int i = 0; i < _activePiece.Cells.Length; i++)
            {
                cellPositions[i] += _activePiece.Position;
            }

            return CanBePlaced(cellPositions);
        }

        private bool CanMove(Vector2Int direction)
        {
            var cellPositions = new Vector2Int[_activePiece.Cells.Length];
            for (int i = 0; i < _activePiece.Cells.Length; i++)
            {
                cellPositions[i] = _activePiece.Position + _activePiece.Cells[i] + direction;
            }

            return CanBePlaced(cellPositions);
        }

        private bool CanBePlaced(Vector2Int[] cellPositions)
        {
            foreach (var cellPosition in cellPositions)
            {
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
            _cells = new FieldCellState[_width, _height]; // Empty is default value for enum
        }
    }
}