using _Project._Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        protected Game _game;
        protected UIManager _uiManager;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }

        public virtual void Init(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}