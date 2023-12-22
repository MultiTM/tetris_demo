using System.Linq;
using UnityEngine;

namespace _Project._Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        private UIWindow[] _windows;
        
        public void ShowWindow<T>() where T : UIWindow
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

        public void HideWindow<T>() where T : UIWindow
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