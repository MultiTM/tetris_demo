using System.Collections.Generic;

namespace _Project._Scripts.Core
{
    public class PieceQueue
    {
        private PieceGenerator _pieceGenerator;
        private NextPieceRenderer _nextPieceRenderer;

        private const int QueueSize = 1;
        private Queue<Tetramino> _pieces = new Queue<Tetramino>(QueueSize);

        public PieceQueue(PieceGenerator pieceGenerator, NextPieceRenderer nextPieceRenderer)
        {
            _pieceGenerator = pieceGenerator;
            _nextPieceRenderer = nextPieceRenderer;
            _nextPieceRenderer.Init();
        }

        public Tetramino GetPiece()
        {
            if (_pieces.Count == 0)
            {
                RequestRandomPiece();
            }
            
            var piece = _pieces.Dequeue();
            RequestRandomPiece();

            return piece;
        }

        private void RequestRandomPiece()
        {
            _pieces.Enqueue(_pieceGenerator.GetRandomPiece());
            Render();
        }

        private void Render()
        {
            var piece = _pieces.Peek();
            _nextPieceRenderer.Render(piece.Cells);
        }
    }
}