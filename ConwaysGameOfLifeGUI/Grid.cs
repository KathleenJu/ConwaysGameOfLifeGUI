using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeGUI
{
    public class Grid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private readonly List<Cell> _livingCells;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            _livingCells = new List<Cell>();
        }

        public IEnumerable<Cell> GetLivingCells()
        {
            return _livingCells;
        }

        public void AddCell(Cell cell)
        {
            if (!_livingCells.Any(c => c.Equals(cell)))
            {
                _livingCells.Add(cell);
            }
        }

        public void UpdateGridSize(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public void Clear()
        {
            _livingCells.Clear();
        }

        public IEnumerable<Cell> GetLiveNeighboursOfLivingCell(Cell cellTarget)
        {
            var allNeighbourOfCell = GetAllNeighboursOfLivingCell(cellTarget);
            return allNeighbourOfCell.Where(neighbourCell => _livingCells.Any(livingCell => livingCell.Equals(neighbourCell)));
        }

        public IEnumerable<Cell> GetDeadNeighboursOfLivingCell(Cell cellTarget)
        {
            var allNeighbourOfCell = GetAllNeighboursOfLivingCell(cellTarget);
            return allNeighbourOfCell.Where(neighbourCell => !_livingCells.Any(livingCell => livingCell.Equals(neighbourCell)));
        }

        public IEnumerable<Cell> GetAllNeighboursOfLivingCell(Cell cellTarget)
        {
            var neighbourCells = new List<Cell>();
            for (var row = cellTarget.Row - 1; row <= cellTarget.Row + 1; row++)
            {
                var actualRow = row < 0 ? Height - 1 : row;
                actualRow = row > Height - 1 ? 0 : actualRow;
                for (var col = cellTarget.Column - 1; col <= cellTarget.Column + 1; col++)
                {
                    var actualCol = col < 0 ? Width - 1 : col;
                    actualCol = col > Width - 1 ? 0 : actualCol;
                    neighbourCells.Add(new Cell(actualRow, actualCol));
                }
            }

            return neighbourCells.Where(cell => !cell.Equals(cellTarget));
        }
    }
}
