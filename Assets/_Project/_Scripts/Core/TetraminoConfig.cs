using UnityEngine;

namespace _Project._Scripts.Core
{
    [CreateAssetMenu(fileName = "TetraminoConfig", menuName = "Game Settings/Tetramino Config", order = 1)]
    public class TetraminoConfig : ScriptableObject
    {
        [SerializeField] private TetraminoConfigItem[] _configItems;

        public TetraminoConfigItem[] ConfigItems => _configItems;
    }
}