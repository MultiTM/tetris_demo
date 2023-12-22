using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        private IUIWindow[] _windows;
        
        [Inject]
        private void Construct(List<IUIWindow> windows)
        {
            _windows = windows.ToArray();
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

        private void HideAllWindows()
        {
            foreach (var window in _windows)
            {
                window.Hide();
            }
        }
    }
}