using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public class UIManager : MonoBehaviour, IInitializable, IDisposable
    {
        private IUIWindow[] _windows;
        private UIDataModel _dataModel;

        public event Action<UIDataModel> OnModelChanged; 
        
        [Inject]
        private void Construct(List<IUIWindow> windows)
        {
            _windows = windows.ToArray();
            _dataModel = new UIDataModel();
        }
        
        public void Initialize()
        {
            foreach (var window in _windows)
            {
                window.Init(this);
            }
            
            OnModelChanged?.Invoke(_dataModel);
        }
        
        public void ShowWindow<T>() where T : IUIWindow
        {
            var targetWindow = _windows.FirstOrDefault(x => x.GetType() == typeof(T));

            if (targetWindow == null)
            {
                Debug.LogWarning("Trying to open non-existent window");
                return;
            }

            HideAllWindows();
            targetWindow.Show();
        }

        public void HideWindow<T>() where T : IUIWindow
        {
            var targetWindow = _windows.FirstOrDefault(x => x.GetType() == typeof(T));

            if (targetWindow == null)
            {
                Debug.LogWarning("Trying to open non-existent window");
                return;
            }
            
            targetWindow.Hide();
        }

        public void ResetDataModel()
        {
            _dataModel = new UIDataModel();
            OnModelChanged?.Invoke(_dataModel);
        }

        private void HideAllWindows()
        {
            foreach (var window in _windows)
            {
                window.Hide();
            }
        }

        public void SetScoreValue(int score)
        {
            _dataModel.Score = score;
            OnModelChanged?.Invoke(_dataModel);
        }
        
        public void SetLinesValue(int lines)
        {
            _dataModel.LinesRemoved = lines;
            OnModelChanged?.Invoke(_dataModel);
        }
        
        public void SetLevelValue(int level)
        {
            _dataModel.Level = level;
            OnModelChanged?.Invoke(_dataModel);
        }

        public void Dispose()
        {
            OnModelChanged = null;
        }
    }
}