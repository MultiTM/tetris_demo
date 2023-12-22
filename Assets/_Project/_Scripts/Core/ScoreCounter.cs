using _Project._Scripts.UI;

namespace _Project._Scripts.Core
{
    public class ScoreCounter
    {
        private const int PointsPerRemovedLine = 100;
        private const int PointsPerPlacedPiece = 10;
        
        private UIManager _uiManager;
        private int _score = 0;
        private int _lines = 0;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _uiManager.SetScoreValue(_score);
            }
        }
        
        public int Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                _uiManager.SetLinesValue(_lines);
            }
        }

        public ScoreCounter(UIManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void Init()
        {
            Score = 0;
            Lines = 0;
        }

        public void LineRemoved()
        {
            Lines++;
            Score += PointsPerRemovedLine;
        }

        public void PiecePlaced()
        {
            Score += PointsPerPlacedPiece;
        }
    }
}