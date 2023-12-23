using _Project._Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers.Gameplay
{
    public class GameplayCoreInstaller : MonoInstaller
    {
        [SerializeField] private FieldRenderer _fieldRenderer;
        [SerializeField] private FieldTicker _fieldTicker;
        [SerializeField] private FieldCell _fieldCell;
        [SerializeField] private NextPieceRenderer _nextPieceRenderer;
        [SerializeField] private LevelFlow levelFlow;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallInstances();
            InstallFactories();
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
    }
}