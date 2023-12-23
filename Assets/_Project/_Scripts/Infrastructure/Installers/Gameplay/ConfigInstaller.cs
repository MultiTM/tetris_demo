using _Project._Scripts.Settings;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers.Gameplay
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private FieldSettings _fieldSettings;
        [SerializeField] private TetraminoConfig _tetraminoConfig;
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private DifficultyConfig _difficultyConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<FieldSettings>().FromScriptableObject(_fieldSettings).AsSingle();
            Container.Bind<TetraminoConfig>().FromScriptableObject(_tetraminoConfig).AsSingle();
            Container.Bind<ScoreConfig>().FromScriptableObject(_scoreConfig).AsSingle();
            Container.Bind<DifficultyConfig>().FromScriptableObject(_difficultyConfig).AsSingle();
        }
    }
}