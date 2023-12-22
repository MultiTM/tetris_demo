using _Project._Scripts.Core;
using _Project._Scripts.Settings;
using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private FieldRenderer _fieldRenderer;
        [SerializeField] private FieldTicker _fieldTicker;
        [SerializeField] private InputHandler _inputHandler;
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
        [SerializeField] private GameOverWindow _gameOverWindow;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallInstances();
            InstallConfigs();
            InstallFactories();
            InstallUI();
        }

        private void InstallUI()
        {
            Container.BindInterfacesAndSelfTo<UIManager>().FromInstance(_uiManager).AsSingle();
            Container.BindInterfacesAndSelfTo<HUDWindow>().FromInstance(_hudWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<MenuWindow>().FromInstance(_menuWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverWindow>().FromInstance(_gameOverWindow).AsSingle();
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
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
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