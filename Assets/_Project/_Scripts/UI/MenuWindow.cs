using _Project._Scripts.Infrastructure;

namespace _Project._Scripts.UI
{
    public class MenuWindow : UIWindow
    {
        public void StartGame()
        {
            _game.EnterState<GameplayState>();
        }
    }
}