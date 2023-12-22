using _Project._Scripts.Infrastructure;
using Zenject;

namespace _Project._Scripts.Core.Input
{
    public class MenuInputHandler : InputHandlerBase
    {
        private Game _game;
        
        public override InputState State => InputState.Menu;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }
        
        protected override void Update()
        {
            ExecuteOnAnyKeyDown(() => _game.EnterState<GameplayState>());
        }
    }
}