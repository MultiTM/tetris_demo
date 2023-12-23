using System;
using _Project._Scripts.Core;
using _Project._Scripts.Core.Input;
using _Project._Scripts.Infrastructure.GameStates;
using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class LevelFlow : MonoBehaviour, IInitializable, IDisposable
    {
        private Game _game;
        private LevelFlowProvider _provider;
        private Field _field;
        private FieldTicker _fieldTicker;
        private UIManager _uiManager;
        private DifficultyManager _difficultyManager;
        private ScoreCounter _scoreCounter;
        private InputSwitcher _inputSwitcher;

        public Field Field => _field;
        public FieldTicker FieldTicker => _fieldTicker;
        public UIManager UIManager => _uiManager;
        public ScoreCounter ScoreCounter => _scoreCounter;
        public DifficultyManager DifficultyManager => _difficultyManager;
        public InputSwitcher InputSwitcher => _inputSwitcher;

        [Inject]
        private void Construct(Game game,
            LevelFlowProvider provider,
            Field field,
            FieldTicker fieldTicker,
            UIManager uiManager,
            DifficultyManager difficultyManager,
            ScoreCounter scoreCounter,
            InputSwitcher inputSwitcher)
        {
            _provider = provider;
            _field = field;
            _fieldTicker = fieldTicker;
            _game = game;
            _uiManager = uiManager;
            _difficultyManager = difficultyManager;
            _scoreCounter = scoreCounter;
            _inputSwitcher = inputSwitcher;
        }

        public void Initialize()
        {
            _provider.InitForLevel(this);
            _field.OnGameOver += OnGameOver;
            _field.OnPiecePlaced += _scoreCounter.PiecePlaced;
            _field.OnLineRemoved += _scoreCounter.LineRemoved;
            _field.OnLineRemoved += _difficultyManager.UpdateDifficultyLevel;
            
            _game.EnterState<MenuState>();
        }

        private void OnGameOver()
        {
            _game.EnterState<GameOverState>();
        }

        public void Dispose()
        {
            _field.OnGameOver -= OnGameOver;
            _field.OnPiecePlaced -= _scoreCounter.PiecePlaced;
            _field.OnLineRemoved -= _scoreCounter.LineRemoved;
            _field.OnLineRemoved -= _difficultyManager.UpdateDifficultyLevel;
        }
    }
}