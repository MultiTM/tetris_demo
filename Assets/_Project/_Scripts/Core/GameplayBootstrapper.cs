using System.Linq;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        private TetraminoConfig _config;
        private Field _field;
        private FieldTicker _fieldTicker;
        
        [Inject]
        private void Construct(Field field, FieldTicker fieldTicker, TetraminoConfig config)
        {
            _config = config;
            _field = field;
            _fieldTicker = fieldTicker;
        }
        
        private void Start()
        {
            _field.Init();
            _fieldTicker.StartTick();
        }
    }
}