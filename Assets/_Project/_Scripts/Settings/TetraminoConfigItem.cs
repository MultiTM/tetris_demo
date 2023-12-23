using System;
using _Project._Scripts.Core;
using UnityEngine;

namespace _Project._Scripts.Settings
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