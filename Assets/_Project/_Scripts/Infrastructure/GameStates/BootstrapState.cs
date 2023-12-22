using _Project._Scripts.Services;

namespace _Project._Scripts.Infrastructure
{
    public class BootstrapState : GameStateBase
    {
        private SceneLoader _sceneLoader;

        public BootstrapState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public override void Enter()
        {
            _sceneLoader.LoadGameplayScene();
        }
    }
}