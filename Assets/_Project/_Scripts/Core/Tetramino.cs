using System.Linq;
using _Project._Scripts.Utils;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Tetramino
    {
        private TetraminoType _type;
        private Vector2Int _position;
        private Vector2Int[] _cells;

        public Vector2Int[] Cells => _cells;
        public Vector2Int Position => _position;

        public Tetramino(TetraminoType type, TetraminoConfig config)
        {
            _type = type;
            _cells = config.ConfigItems.First(x => x.Type == type).Cells;
        }

        public void SetPosition(Vector2Int position)
        {
            _position = position;
        }

        public void Rotate()
        {
            _cells = TetraminoRotator.Rotate(_cells);
        }
    }
}