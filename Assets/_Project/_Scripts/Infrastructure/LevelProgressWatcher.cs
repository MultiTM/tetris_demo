using _Project._Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class LevelProgressWatcher : MonoBehaviour, IInitializable
    {
        private Game _game;
        private LevelProgressWatcherProvider _provider;
        private Field _field;
        private FieldTicker _fieldTicker;

        public Field Field => _field;
        public FieldTicker FieldTicker => _fieldTicker;

        [Inject]
        private void Construct(Game game, LevelProgressWatcherProvider provider, Field field, FieldTicker fieldTicker)
        {
            _provider = provider;
            _field = field;
            _fieldTicker = fieldTicker;
            _game = game;
        }

        public void Initialize()
        {
            _provider.InitForLevel(this);
            _game.EnterState<MenuState>();
        }
    }
}