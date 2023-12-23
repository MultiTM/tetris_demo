using _Project._Scripts.Infrastructure.GameStates;

namespace _Project._Scripts.UI
{
    public class GameOverWindow : UIWindow
    {
        public void GoToMenu()
        {
            _game.EnterState<MenuState>();
        }
    }
}