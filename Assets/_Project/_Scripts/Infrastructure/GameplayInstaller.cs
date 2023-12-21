using _Project._Scripts.Core;
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
        
        public override void InstallBindings()
        {
            Container.Bind<Field>().AsSingle();
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
            Container.Bind<FieldRenderer>().FromInstance(_fieldRenderer).AsSingle();
            Container.Bind<FieldTicker>().FromInstance(_fieldTicker).AsSingle();
            Container.Bind<FieldSettings>().FromScriptableObject(_fieldSettings).AsSingle();
            Container.Bind<TetraminoConfig>().FromScriptableObject(_tetraminoConfig).AsSingle();
            Container.BindFactory<FieldCell, FieldCell.Factory>().FromComponentInNewPrefab(_fieldCell);
            Container.BindFactory<TetraminoType, Tetramino, Tetramino.Factory>();
        }
    }
}