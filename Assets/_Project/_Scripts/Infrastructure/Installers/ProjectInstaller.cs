using _Project._Scripts.Infrastructure;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Game>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
        Container.BindInterfacesAndSelfTo<PauseState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
    }
}
