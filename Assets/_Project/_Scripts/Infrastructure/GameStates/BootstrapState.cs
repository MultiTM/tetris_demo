using _Project._Scripts.Services;

namespace _Project._Scripts.Infrastructure
{
    public class BootstrapState : GameStateBase
    {
        private SceneLoader _sceneLoader;
        private CoroutineRunner _coroutineRunner;

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