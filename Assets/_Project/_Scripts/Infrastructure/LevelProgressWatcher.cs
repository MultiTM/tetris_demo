using System;
using _Project._Scripts.Core;
using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class LevelProgressWatcher : MonoBehaviour, IInitializable, IDisposable
    {
        private Game _game;
        private LevelProgressWatcherProvider _provider;
        private Field _field;
        private FieldTicker _fieldTicker;
        private UIManager _uiManager;

        public Field Field => _field;
        public FieldTicker FieldTicker => _fieldTicker;
        public UIManager UIManager => _uiManager;

        [Inject]
        private void Construct(Game game, LevelProgressWatcherProvider provider, Field field, FieldTicker fieldTicker, UIManager uiManager)
        {
            _provider = provider;
            _field = field;
            _fieldTicker = fieldTicker;
            _game = game;
            _uiManager = uiManager;
        }

        public void Initialize()
        {
            _provider.InitForLevel(this);
            _field.OnGameOver += OnGameOver;
            
            _game.EnterState<MenuState>();
        }

        private void OnGameOver()
        {
            _game.EnterState<GameOverState>();
        }

        public void Dispose()
        {
            _field.OnGameOver -= OnGameOver;
        }
    }
}