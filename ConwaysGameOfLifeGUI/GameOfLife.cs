using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLifeGUI.EvolutionRules;

namespace ConwaysGameOfLifeGUI
{
    public class GameOfLife
    {
        private Grid _grid;
        private readonly DeadEvolutionRules _deadEvolutionRules;
        private readonly LiveEvolutionRules _liveEvolutionRules;
        public IEnumerable<Cell> LivingCells => _grid.GetLivingCells();

        public GameOfLife()
        {
            _deadEvolutionRules = new DeadEvolutionRules();
            _liveEvolutionRules = new LiveEvolutionRules();
        }

        public void Evolve()
        {
            var allDeadNeighboursOfLiveCells = new List<Cell>();
            var allLiveNeighboursOfLiveCells = new List<Cell>();

            foreach (var cell in LivingCells)
            {
                allDeadNeighboursOfLiveCells.AddRange(_grid.GetDeadNeighboursOfALivingCell(cell));
                allLiveNeighboursOfLiveCells.AddRange(_grid.GetLiveNeighboursOfALivingCell(cell));
            }

            var cellsThatShouldLive = _liveEvolutionRules.GetDeadCellsThatShouldLive(allDeadNeighboursOfLiveCells);
            var cellsThatShouldDie = _deadEvolutionRules.GetLiveCellsThatShouldDie(allLiveNeighboursOfLiveCells);
            var newLivingCells = GetNewLivingCells(cellsThatShouldDie, cellsThatShouldLive);

            UpdateGrid(newLivingCells);
        }

        private List<Cell> GetNewLivingCells(List<Cell> cellsThatShouldDie, List<Cell> cellsThatShouldLive)
        {
            return LivingCells
                .Where(livingCell => !cellsThatShouldDie
                    .Any(dyingCell => livingCell.Row == dyingCell.Row && livingCell.Column == dyingCell.Column))
                .Concat(cellsThatShouldLive).ToList();
        }

        private void UpdateGrid(List<Cell> newLivingCells)
        {
            _grid.Clear();
            newLivingCells.ForEach(cell => { _grid.AddCell(cell); });
        }

        public void UpdateGridSize(int height, int width)
        {
            _grid.UpdateGridSize(height, width);
        }

        public void SetGrid(int height, int width)
        {
            _grid = new Grid(height, width);
        }

        public void AddCellToGrid(Cell cell)
        {
            _grid.AddCell(cell);
        }

        public void ClearGrid()
        {
            _grid.Clear();
        }

        public void RemoveCellToGrid(Cell cell)
        {
            _grid.RemoveCell(cell);
        }
    }
}
