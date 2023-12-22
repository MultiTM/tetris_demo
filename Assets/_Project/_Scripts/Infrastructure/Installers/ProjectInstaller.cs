using _Project._Scripts.Infrastructure;
using _Project._Scripts.Services;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallGameStates();
        InstallServices();
    }

    private void InstallServices()
    {
        Container.Bind<LevelProgressWatcherProvider>().AsSingle();
        Container.Bind<SceneLoader>().AsSingle();
    }

    private void InstallGameStates()
    {
        Container.Bind<Game>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
        Container.BindInterfacesAndSelfTo<PauseState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
    }
}
