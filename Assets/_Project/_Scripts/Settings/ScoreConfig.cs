using UnityEngine;

namespace _Project._Scripts.Settings
{
    [CreateAssetMenu(fileName = "ScoreSettings", menuName = "Game Settings/Score Settinsg", order = 1)]
    public class ScoreConfig : ScriptableObject
    {
        [SerializeField] private int _pointsPerRemovedLine = 100;
        [SerializeField] private int _pointsPerPlacedPiece = 10;

        public int PointsPerRemovedLine => _pointsPerRemovedLine;
        public int PointsPerPlacedPiece => _pointsPerPlacedPiece;
    }
}