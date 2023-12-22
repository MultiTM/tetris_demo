using System;
using TMPro;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class HUDWindow : UIWindow
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private TextMeshProUGUI _levelLabel;
        [SerializeField] private TextMeshProUGUI _linesLabel;
        
        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            _uiManager.OnModelChanged += OnModelChanged;
        }

        private void OnModelChanged(UIDataModel dataModel)
        {
            _scoreLabel.text = dataModel.Score.ToString();
            _levelLabel.text = dataModel.Level.ToString();
            _linesLabel.text = dataModel.Lines.ToString();
        }
    }
}