using _Project._Scripts.Core;
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
        [SerializeField] private FieldCell _fieldCell;
        [SerializeField] private NextPieceRenderer _nextPieceRenderer;
        [SerializeField] private LevelProgressWatcher _levelProgressWatcher;
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
            Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
            Container.BindInterfacesAndSelfTo<HUDWindow>().FromInstance(_hudWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<MenuWindow>().FromInstance(_menuWindow).AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverWindow>().FromInstance(_gameOverWindow).AsSingle();
        }

        private void InstallCore()
        {
            Container.Bind<Field>().AsSingle();
            Container.Bind<PieceGenerator>().AsSingle();
            Container.Bind<PieceQueue>().AsSingle();
        }

        private void InstallInstances()
        {
            Container.Bind<NextPieceRenderer>().FromInstance(_nextPieceRenderer).AsSingle();
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
            Container.Bind<FieldRenderer>().FromInstance(_fieldRenderer).AsSingle();
            Container.Bind<FieldTicker>().FromInstance(_fieldTicker).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelProgressWatcher>().FromInstance(_levelProgressWatcher).AsSingle();
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
        }
    }
}