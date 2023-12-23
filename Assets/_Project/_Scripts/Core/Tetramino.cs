using System;
using _Project._Scripts.Utils;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class Tetramino
    {
        private Vector2Int _position;
        private Vector2Int[] _cells;

        public Vector2Int[] Cells => _cells;
        public Vector2Int Position => _position;

        public Tetramino(Vector2Int[] cells)
        {
            _cells = new Vector2Int[cells.Length];
            Array.Copy(cells, _cells, cells.Length); // To avoid copying of array reference
        }

        public void SetPosition(Vector2Int position)
        {
            _position = position;
        }

        public void Rotate()
        {
            _cells = TetraminoRotator.Rotate(_cells);
        }

        public class Factory : PlaceholderFactory<Vector2Int[], Tetramino> { }
    }
}