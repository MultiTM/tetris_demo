using UnityEngine;

namespace _Project._Scripts.Core
{
    [CreateAssetMenu(fileName = "FieldSettings", menuName = "Game Settings/Field Settings", order = 0)]
    public class FieldSettings : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private FieldCell _fieldCellPrefab;

        public int Width => _width;
        public int Height => _height;
        public FieldCell FieldCellPrefab => _fieldCellPrefab;
    }
}