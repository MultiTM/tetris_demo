using _Project._Scripts.Core;
using _Project._Scripts.Core.Input;
using _Project._Scripts.Settings;
using _Project._Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private FieldRenderer _fieldRenderer;
        [SerializeField] private FieldTicker _fieldTicker;
        [SerializeField] private GameplayInputHandler _gameplayInputHandler;
        [SerializeField] private MenuInputHandler _menuInputHandler;
        [SerializeField] private GameOverInputHandler _gameOverInputHandler;
        [SerializeField] private PauseInputHandler _pauseInputHandler;
        [SerializeField] private FieldSettings _fieldSettings;
        [SerializeField] private TetraminoConfig _tetraminoConfig;
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private DifficultyConfig _difficultyConfig;
        [SerializeField] private FieldCell _fieldCell;
        [SerializeField] private NextPieceRenderer _nextPieceRenderer;
        [SerializeField] private LevelFlow levelFlow;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private HUDWindow _hudWindow;
        [SerializeField] private MenuWindow _menuWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private GameOverWindow _gameOverWindow;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallInstances();
            InstallConfigs();
            InstallFactories();
            InstallUI();
            InstallInput();
        }

        private void InstallInput()
        {
            Container.Bind<InputSwitcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuInputHandler>().FromInstance(_menuInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayInputHandler>().FromInstance(_gameplayInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverInputHandler>().FromInstance(_gameOverInputHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<PauseInputHandler>().FromInstance(_pauseInputHandler).AsSingle();
        }

        private void InstallUI()
        {
            Container.BindInterfacesAndSelfTo<UIManager>().FromInstance(_uiManager).AsSingle();
            Container.BindInterfacesAndSelfTo<HUDWindow>().FromInstance(_hudWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<MenuWindow>().FromInstance(_menuWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverWindow>().FromInstance(_gameOverWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<PauseWindow>().FromInstance(_pauseWindow).AsSingle();
        }

        private void InstallCore()
        {
            Container.BindInterfacesAndSelfTo<Field>().AsSingle();
            Container.Bind<PieceGenerator>().AsSingle();
            Container.Bind<PieceQueue>().AsSingle();
            Container.Bind<ScoreCounter>().AsSingle();
            Container.Bind<DifficultyManager>().AsSingle();
        }

        private void InstallInstances()
        {
            Container.Bind<NextPieceRenderer>().FromInstance(_nextPieceRenderer).AsSingle();
            Container.Bind<FieldRenderer>().FromInstance(_fieldRenderer).AsSingle();
            Container.Bind<FieldTicker>().FromInstance(_fieldTicker).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelFlow>().FromInstance(levelFlow).AsSingle();
        }

        private void InstallFactories()
        {
            Container.BindFactory<FieldCell, FieldCell.Factory>().FromComponentInNewPrefab(_fieldCell);
            Container.BindFactory<Vector2Int[], Tetramino, Tetramino.Factory>();
        }

        private void InstallConfigs()
        {
            Container.Bind<FieldSettings>().FromScriptableObject(_fieldSettings).AsSingle();
            Container.Bind<TetraminoConfig>().FromScriptableObject(_tetraminoConfig).AsSingle();
            Container.Bind<ScoreConfig>().FromScriptableObject(_scoreConfig).AsSingle();
            Container.Bind<DifficultyConfig>().FromScriptableObject(_difficultyConfig).AsSingle();
        }
    }
}