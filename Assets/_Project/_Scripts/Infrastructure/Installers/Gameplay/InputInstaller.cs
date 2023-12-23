using _Project._Scripts.Core.Input;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers.Gameplay
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private GameplayInputHandler _gameplayInputHandler;
        [SerializeField] private MenuInputHandler _menuInputHandler;
        [SerializeField] private GameOverInputHandler _gameOverInputHandler;
        [SerializeField] private PauseInputHandler _pauseInputHandler;
        public override void InstallBindings()
        {
            Container.Bind<InputSwitcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuInputHandler>().FromInstance(_menuInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayInputHandler>().FromInstance(_gameplayInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverInputHandler>().FromInstance(_gameOverInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<PauseInputHandler>().FromInstance(_pauseInputHandler).AsSingle();
        }
    }
}