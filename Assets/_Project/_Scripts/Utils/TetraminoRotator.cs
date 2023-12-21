using UnityEngine;

namespace _Project._Scripts.Utils
{
    public static class TetraminoRotator
    {
        private static float Sin = Mathf.Sin(Mathf.PI / 2f);
        private static float Cos = Mathf.Cos(Mathf.PI / 2f);

        // Rotate cells positions using 2d rotation matrix
        public static Vector2Int[] Rotate(Vector2Int[] cells)
        {
            var newCells = new Vector2Int[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                var cell = cells[i];

                var x = cell.x * Cos + cell.y * Sin;
                var y = cell.x * -Sin + cell.y * Cos;
                newCells[i] = new Vector2Int(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
            }

            return newCells;
        }
    }
}