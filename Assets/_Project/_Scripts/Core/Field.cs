using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class Field : MonoBehaviour
    {
        private int _width;
        private int _height;
        private FieldCell.Factory _fieldCellFactory;
        private FieldCell[,] _cells;

        [Inject]
        private void Construct(FieldSettings fieldSettings, FieldCell.Factory fieldCellFactory)
        {
            _width = fieldSettings.Width;
            _height = fieldSettings.Height;
            _fieldCellFactory = fieldCellFactory;
        }

        private void Start()
        {
            CreateCells();
        }

        private void CreateCells()
        {
            _cells = new FieldCell[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _cells[x, y] = _fieldCellFactory.Create();
                    _cells[x, y].transform.SetParent(transform);
                    _cells[x, y].transform.localPosition = new Vector3(x, y, 0);
                    _cells[x, y].SetState(FieldCellState.Empty);
                }
            }
        }
    }
}