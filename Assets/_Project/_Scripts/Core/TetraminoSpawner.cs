using UnityEngine;

namespace _Project._Scripts.Core
{
    public class TetraminoSpawner : MonoBehaviour
    {
        [SerializeField] private TetraminoConfig _config;
        
        private void Start()
        {
            var piece = new Tetramino(TetraminoType.L, _config);

            foreach (var cell in piece.Cells)
            {
                Debug.Log(cell);
            }
            
            piece.Rotate();
            
            foreach (var cell in piece.Cells)
            {
                Debug.Log(cell);
            }
            
            piece.Rotate();
            
            foreach (var cell in piece.Cells)
            {
                Debug.Log(cell);
            }
        }
    }
}