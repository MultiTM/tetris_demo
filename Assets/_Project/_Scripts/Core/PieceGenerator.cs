using _Project._Scripts.Settings;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class PieceGenerator
    {
        private TetraminoConfig _config;
        private Tetramino.Factory _factory;

        public PieceGenerator(TetraminoConfig config, Tetramino.Factory factory)
        {
            _config = config;
            _factory = factory;
        }

        public Tetramino GetRandomPiece()
        {
            var pieceData = _config.ConfigItems[Random.Range(0, _config.ConfigItems.Length - 1)];
            var tetramino = _factory.Create(pieceData.Cells);

            return tetramino;
        }
    }
}