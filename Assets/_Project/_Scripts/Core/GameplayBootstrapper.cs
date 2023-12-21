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
            var piece = new Tetramino(TetraminoType.L, _config);
            piece.SetPosition(new Vector2Int(4, 15));
            _field.SetActivePiece(piece);
            _fieldTicker.StartTick();
        }
    }
}