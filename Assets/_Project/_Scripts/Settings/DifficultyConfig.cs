using System;
using UnityEngine;

namespace _Project._Scripts.Settings
{
    [CreateAssetMenu(menuName = "Game Settings/Difficulty", fileName = "DifficultySettings", order = 1)]
    public class DifficultyConfig : ScriptableObject
    {
        [SerializeField] private DifficultyConfigItem[] _levels;

        public DifficultyConfigItem[] Levels => _levels;
    }

    [Serializable]
    public class DifficultyConfigItem
    {
        public int RemovedLinesRequired;
        public int Level;
        public float TickDuration;
    }
}