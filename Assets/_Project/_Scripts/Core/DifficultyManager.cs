using _Project._Scripts.Settings;
using _Project._Scripts.UI;

namespace _Project._Scripts.Core
{
    public class DifficultyManager
    {
        private UIManager _uiManager;
        private DifficultyConfig _config;
        private FieldTicker _fieldTicker;

        private int _currentLevel = 0;
        
        public DifficultyManager(UIManager uiManager, DifficultyConfig config, FieldTicker fieldTicker)
        {
            _config = config;
            _fieldTicker = fieldTicker;
            _uiManager = uiManager;
        }

        public void Init()
        {
            _currentLevel = 0;
        }
        
        public void TryIncreaseDifficulty(int removedLines)
        {
            if (_config.Levels[_currentLevel + 1].RemovedLinesRequired <= removedLines)
            {
                _currentLevel++;
            }
            
            _uiManager.SetLevelValue(_currentLevel);
            var tickDuration = GetLevelTickDuration(_currentLevel);
            _fieldTicker.SetTickDuration(tickDuration);
        }

        private float GetLevelTickDuration(int currentLevel)
        {
            var levelConfig = _config.Levels[currentLevel];
            return levelConfig.TickDuration;
        }
    }
}