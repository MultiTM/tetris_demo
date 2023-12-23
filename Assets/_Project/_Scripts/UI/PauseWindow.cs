using _Project._Scripts.Infrastructure.GameStates;
using TMPro;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class PauseWindow : UIWindow
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private TextMeshProUGUI _levelLabel;
        [SerializeField] private TextMeshProUGUI _linesRemovedLabel;
        
        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            _uiManager.OnModelChanged += OnModelChanged;
        }

        private void OnModelChanged(UIDataModel dataModel)
        {
            _scoreLabel.text = dataModel.Score.ToString();
            _levelLabel.text = dataModel.Level.ToString();
            _linesRemovedLabel.text = dataModel.LinesRemoved.ToString();
        }

        public void Restart()
        {
            _game.EnterState<InitGameplayState>();
        }

        public void Resume()
        {
            _game.EnterState<GameplayState>();
        }

        public void GoToMenu()
        {
            _game.EnterState<MenuState>();
        }
    }
}