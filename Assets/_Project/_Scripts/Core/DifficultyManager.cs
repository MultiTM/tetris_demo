using System.Linq;
using _Project._Scripts.Settings;
using _Project._Scripts.UI;

namespace _Project._Scripts.Core
{
    public class DifficultyManager
    {
        private UIManager _uiManager;
        private DifficultyConfig _config;
        private ScoreCounter _scoreCounter;
        private FieldTicker _fieldTicker;
        
        public DifficultyManager(UIManager uiManager, DifficultyConfig config, ScoreCounter scoreCounter, FieldTicker fieldTicker)
        {
            _config = config;
            _scoreCounter = scoreCounter;
            _fieldTicker = fieldTicker;
            _uiManager = uiManager;
        }
        
        public void UpdateDifficultyLevel()
        {
            var removedLines = _scoreCounter.LinesRemoved;
            var level = GetLevel(removedLines);
            _uiManager.SetLevelValue(level.Level);
            _fieldTicker.SetTickDuration(level.TickDuration);
        }

        private DifficultyConfigItem GetLevel(int removedLines)
        {
            DifficultyConfigItem level = null;
            for (int i = _config.Levels.Count() - 1; i >= 0; i--)
            {
                if (_config.Levels[i].RemovedLinesRequired <= removedLines)
                {
                    level = _config.Levels[i];
                    break;
                }
            }

            if (level == null)
            {
                level = _config.Levels.First();
            }

            return level;
        }
    }
}