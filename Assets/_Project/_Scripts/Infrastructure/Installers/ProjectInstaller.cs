using _Project._Scripts.Infrastructure.GameStates;
using _Project._Scripts.Services;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameStates();
            InstallServices();
        }

        private void InstallServices()
        {
            Container.Bind<LevelFlowProvider>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void InstallGameStates()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<PauseState>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitGameplayState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
        }
    }
}
