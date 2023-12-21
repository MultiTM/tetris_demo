using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        private TetraminoConfig _config;
        private Field _field;
        
        [Inject]
        private void Construct(Field field, TetraminoConfig config)
        {
            _config = config;
            _field = field;
        }
        
        private void Start()
        {
            _field.Init();
            var piece = new Tetramino(TetraminoType.L, _config);
            piece.SetPosition(new Vector2Int(4, 15));
            _field.SetActivePiece(piece);
        }
    }
}