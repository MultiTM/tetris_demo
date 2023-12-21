using System;
using UnityEngine;

namespace _Project._Scripts.Core
{
    [Serializable]
    public class TetraminoConfigItem
    {
        [SerializeField] private TetraminoType _type;
        [SerializeField] private Vector2Int[] _cells;

        public TetraminoType Type => _type;
        public Vector2Int[] Cells => _cells;
    }
}