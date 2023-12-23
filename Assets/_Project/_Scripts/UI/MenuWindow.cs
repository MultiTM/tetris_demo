using _Project._Scripts.Infrastructure.GameStates;

namespace _Project._Scripts.UI
{
    public class MenuWindow : UIWindow
    {
        public void StartGame()
        {
            _game.EnterState<InitGameplayState>();
        }
    }
}