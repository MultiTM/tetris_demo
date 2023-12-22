using _Project._Scripts.Settings;
using _Project._Scripts.UI;

namespace _Project._Scripts.Core
{
    public class ScoreCounter
    {
        private UIManager _uiManager;
        private ScoreConfig _config;
        private int _score = 0;
        private int _linesRemoved = 0;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _uiManager.SetScoreValue(_score);
            }
        }
        
        public int LinesRemoved
        {
            get => _linesRemoved;
            set
            {
                _linesRemoved = value;
                _uiManager.SetLinesValue(_linesRemoved);
            }
        }

        public ScoreCounter(UIManager uiManager, ScoreConfig config)
        {
            _uiManager = uiManager;
            _config = config;
        }

        public void Init()
        {
            Score = 0;
            LinesRemoved = 0;
        }

        public void LineRemoved()
        {
            LinesRemoved++;
            Score += _config.PointsPerRemovedLine;
        }

        public void PiecePlaced()
        {
            Score += _config.PointsPerPlacedPiece;
        }
    }
}