using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers.Gameplay
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private HUDWindow _hudWindow;
        [SerializeField] private MenuWindow _menuWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private GameOverWindow _gameOverWindow;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIManager>().FromInstance(_uiManager).AsSingle();
            Container.BindInterfacesAndSelfTo<HUDWindow>().FromInstance(_hudWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<MenuWindow>().FromInstance(_menuWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverWindow>().FromInstance(_gameOverWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<PauseWindow>().FromInstance(_pauseWindow).AsSingle();
        }
    }
}