using _Project._Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public abstract class UIWindow : MonoBehaviour
    {
        protected Game _game;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
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