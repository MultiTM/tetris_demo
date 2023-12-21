using _Project._Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Field _field;
        [SerializeField] private FieldSettings _fieldSettings;
        [SerializeField] private FieldCell _fieldCell;
        
        public override void InstallBindings()
        {
            Container.Bind<Field>().FromInstance(_field).AsSingle();
            Container.Bind<FieldSettings>().FromScriptableObject(_fieldSettings).AsSingle();
            Container.BindFactory<FieldCell, FieldCell.Factory>().FromComponentInNewPrefab(_fieldCell).AsSingle();
        }
    }
}